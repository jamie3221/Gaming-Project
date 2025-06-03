using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnQuitButtonClicked()
    {
        // If we are running in the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If we are running in a built application, quit the application
        Application.Quit();
        #endif
    }
}
