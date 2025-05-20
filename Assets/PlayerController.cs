using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = true;

    void Update()
    {
        if (!canMove) return;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            canMove = false;
            Debug.Log("Player hit an obstacle!");
        }
    }
}
