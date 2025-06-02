using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == "Scene 1")
            {
                SceneManager.LoadScene("Scene 2");
            }
            else if (currentSceneName == "Scene 2")
            {
                SceneManager.LoadScene("Scene 1");
            }
            else
            {
                Debug.LogWarning("No valid scene to transition to.");
            }
        }   
    }
}
