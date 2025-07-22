using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RhythmManager : MonoBehaviour
{
    public AudioProcessor audioProcessor;
    public GameObject notePrefab;

    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Transform leftHitZone;
    public Transform rightHitZone;

    public float noteTravelTime = 0.5f;
    public float hitRadius = 0.5f; // how close note must be to hit zone

    private List<GameObject> activeNotes = new List<GameObject>();

    void Start()
    {
        audioProcessor.onBeat.AddListener(OnBeat);
    }

    void OnBeat()
    {
        SpawnRandomNote();
    }

    void SpawnRandomNote()
    {
        bool spawnLeft = Random.value < 0.5f;

        Transform spawnPoint = spawnLeft ? leftSpawnPoint : rightSpawnPoint;
        Transform hitZone = spawnLeft ? leftHitZone : rightHitZone;

        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
        Note noteScript = note.GetComponent<Note>();
        noteScript.hitZone = hitZone;
        noteScript.travelTime = noteTravelTime;

        note.name = spawnLeft ? "LeftNote" : "RightNote";
        activeNotes.Add(note);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // left
        {
            TryHit("LeftNote", leftHitZone);
        }

        if (Input.GetKeyDown(KeyCode.D)) // right
        {
            TryHit("RightNote", rightHitZone);
        }
    }

    void TryHit(string noteTag, Transform hitZone)
    {
        foreach (GameObject note in activeNotes)
        {
            if (note != null && note.name == noteTag)
            {
                Note noteScript = note.GetComponent<Note>();
                if (noteScript.IsInHitWindow(hitRadius))
                {
                    Debug.Log($"✅ HIT: {note.name}");
                    Destroy(note);
                    activeNotes.Remove(note);
                    return;
                }
            }
        }

        Debug.Log("❌ MISS");
    }
}
