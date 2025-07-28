using UnityEngine;

public class RhythmSceneSetup : MonoBehaviour
{
    public AudioSource rhythmAudio; // Drag your music AudioSource here

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.musicSource = rhythmAudio;
        }
        else
        {
            Debug.LogWarning("GameManager not found in Scene B.");
        }
    }
}
