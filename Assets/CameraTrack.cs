using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform target;           
    public float rotationSpeed = 5f;   
    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
