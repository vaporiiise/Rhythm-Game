using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource musicSource;

    public float SongTime => musicSource.time;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
