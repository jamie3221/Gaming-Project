using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public string startscene = "Level 1";
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(startscene);
    }
}
