using UnityEngine;

public class Note : MonoBehaviour
{
    public Transform hitZone;
    public float travelTime = 0.5f; // seconds to reach hit zone

    private Vector3 startPos;
    private Vector3 targetPos;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
        startPos = transform.position;
        targetPos = hitZone.position;
    }

    void Update()
    {
        float t = (Time.time - spawnTime) / travelTime;
        t = Mathf.Clamp01(t);
        transform.position = Vector3.Lerp(startPos, targetPos, t);
    }

    public bool IsInHitWindow(float hitRadius)
    {
        return Vector3.Distance(transform.position, hitZone.position) <= hitRadius;
    }
}
