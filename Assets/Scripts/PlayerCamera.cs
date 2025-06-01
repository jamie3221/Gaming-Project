using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
        public Transform target;
    public Vector3 offset = new Vector3(0, 5, -7);  // Behind and above the player
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
