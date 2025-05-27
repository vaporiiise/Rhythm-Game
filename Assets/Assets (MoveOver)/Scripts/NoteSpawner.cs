using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject tapNotePrefab;
    public GameObject holdNotePrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public AudioSource musicSource;
    public BeatmapLoader beatmapLoader;

    private int nextNoteIndex = 0;

    void Update()
    {
        if (beatmapLoader.loadedNotes == null || nextNoteIndex >= beatmapLoader.loadedNotes.Count)
            return;

        float songTime = musicSource.time;
        var note = beatmapLoader.loadedNotes[nextNoteIndex];

        if (songTime >= note.time - 2f) 
        {
            Transform spawnPoint = (note.lane == "left") ? leftSpawnPoint : rightSpawnPoint;

            if (note.type == "tap")
            {
                GameObject tap = Instantiate(tapNotePrefab, spawnPoint.position, Quaternion.identity);

                NoteDataHolder holder = tap.GetComponent<NoteDataHolder>();
                if (holder != null)
                {
                    holder.noteTime = note.time;
                    holder.lane = note.lane; 
                }
                else
                {
                    Debug.LogError("NoteDataHolder missing on tapNotePrefab!");
                }
            }
            else if (note.type == "hold")
            {
                GameObject hold = Instantiate(holdNotePrefab, spawnPoint.position, Quaternion.identity);
                hold.transform.localScale += new Vector3(0, note.duration * 2f, 0);

                NoteDataHolder holder = hold.GetComponent<NoteDataHolder>();
                if (holder != null)
                {
                    holder.noteTime = note.time;
                    holder.lane = note.lane; 
                }
                else
                {
                    Debug.LogError("NoteDataHolder missing on holdNotePrefab!");
                }
            }

            nextNoteIndex++;
        }
    }
}

