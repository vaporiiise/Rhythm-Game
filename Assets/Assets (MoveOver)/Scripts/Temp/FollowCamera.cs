using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;           // The target to follow
    public Vector3 offset = new Vector3(0, 5, -10); // Position offset
    public float smoothSpeed = 5f;     // Follow smoothing speed

    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial rotation of the camera
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly follow the target's position with the offset
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Keep the original rotation
        transform.rotation = initialRotation;
    }
}

