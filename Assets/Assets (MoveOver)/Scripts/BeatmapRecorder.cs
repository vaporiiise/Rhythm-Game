using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class BeatMapRecorder : MonoBehaviour
{
    public AudioSource musicSource;
    public string laneName = "left"; 
    private List<NoteData> recordedNotes = new List<NoteData>();
    private bool isRecording = false;

    [System.Serializable]
    public class NoteData
    {
        public float time;
        public string lane;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRecording)
        {
            float currentTime = musicSource.time;
            recordedNotes.Add(new NoteData { time = currentTime, lane = laneName });
            Debug.Log("Note recorded at: " + currentTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isRecording = !isRecording;
            Debug.Log(isRecording ? "Recording Started" : "Recording Stopped");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveBeatmap();
        }
    }

    void SaveBeatmap()
    {
        string json = JsonUtility.ToJson(new Wrapper { notes = recordedNotes }, true);
        string path = Application.dataPath + "/Beatmaps/song1.json";
        File.WriteAllText(path, json);
        Debug.Log("Saved beatmap to: " + path);
    }

    [System.Serializable]
    public class Wrapper
    {
        public List<NoteData> notes;
    }
}
