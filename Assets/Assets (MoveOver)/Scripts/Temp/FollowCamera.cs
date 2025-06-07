using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;                       // The target to follow
    public Vector3 offset = new Vector3(0, 5, -10); // Position offset
    public float smoothSpeed = 5f;                 // Follow smoothing speed
    public float xRotationAngle = 20f;             // X-axis tilt angle

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly follow the target with offset
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Only apply rotation along the X-axis (pitch)
        Quaternion currentRotation = transform.rotation;
        Vector3 euler = currentRotation.eulerAngles;
        euler.x = xRotationAngle; // Set only X rotation
        transform.rotation = Quaternion.Euler(euler);
    }
}

