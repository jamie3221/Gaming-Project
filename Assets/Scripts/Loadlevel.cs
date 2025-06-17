using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public string sceneToLoad = "level"; // Change this to your target scene name

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(() =>
            {
                if (Application.isPlaying)
                {
                    Debug.Log("Starting game...");
                    SceneManager.LoadScene(sceneToLoad);
                }
            });
        }
        else
        {
            Debug.LogWarning("Start button not assigned.");
        }
    }
}
