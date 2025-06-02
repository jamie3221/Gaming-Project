using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Vector3 targetPositionInScene2 = new Vector3(-41.56f, 30f, 51.3f);
    private bool isOnTransitionPlatform = false;
    private void Update()
    {
        if (isOnTransitionPlatform && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            TransferData.targetPosition = targetPositionInScene2;
            SceneManager.LoadScene("Scene 2");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Transition Platform"))
        {
            isOnTransitionPlatform = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Transition Platform"))
        {
            isOnTransitionPlatform = false;
        }
    }
}
