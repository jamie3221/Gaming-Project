using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(() =>
            {
                if (Application.isPlaying)
                {
                    Debug.Log("Quitting game...");
                    Application.Quit();
                }
            });
        }
        else
        {
            Debug.LogWarning("Quit button not assigned.");
        }
    }
}
