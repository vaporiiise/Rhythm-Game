using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float hitX = -5f; 
    private float spawnX;    
    private float spawnTime; 

    private NoteDataHolder noteData;

    void Start()
    {
        noteData = GetComponent<NoteDataHolder>();

        spawnX = transform.position.x;

        spawnTime = GameManager.Instance.SongTime;

        // Safety check
        if (noteData == null)
        {
            Debug.LogError("NoteDataHolder not found on note!");
        }

        if (noteData.noteTime <= 0f)
        {
            Debug.LogWarning("NoteTime is zero or not set. This may cause division errors.");
        }
    }

    void Update()
    {
        if (noteData == null || noteData.noteTime <= 0f)
            return;

        float currentSongTime = GameManager.Instance.SongTime;
        float timeUntilHit = noteData.noteTime - currentSongTime;
        float totalTravelTime = noteData.noteTime - spawnTime;

        if (totalTravelTime <= 0f)
        {
            totalTravelTime = 0.0001f;
        }

        float distance = spawnX - hitX;
        float speed = distance / totalTravelTime;

        float newX = hitX + timeUntilHit * speed;

        if (newX < hitX - 1f)
        {
            Destroy(gameObject); 
            return;
        }

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
