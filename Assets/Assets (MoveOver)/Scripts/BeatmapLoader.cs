using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class NoteData
{
    public float time;
    public string lane;
    public string type = "tap";
    public float duration = 0f;
}

[System.Serializable]
public class Beatmap
{
    public List<NoteData> notes;
}

public class BeatMapLoader : MonoBehaviour
{
    public float time;
    public string lane;
    public string type = "tap";
    public float duration = 0f;
}

public class BeatmapLoader : MonoBehaviour
{
    public string fileName = "song1.json";
    public List<NoteData> loadedNotes;

    void Start()
    {
        LoadBeatmap();
    }

    void LoadBeatmap()
    {
        string path = Path.Combine(Application.dataPath, "Beatmaps", fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Beatmap beatmap = JsonUtility.FromJson<Beatmap>(json);
            loadedNotes = beatmap.notes;
            Debug.Log($"Loaded {loadedNotes.Count} notes from {fileName}");
        }
        else
        {
            Debug.LogError("Beatmap not found at: " + path);
        }
    }
}
