using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource musicSource;
    
    public bool rhythmSuccess = false;
    public string lastEnemyID = "";


    public float SongTime => musicSource.time;

    
    private void Start()
    {
        if (musicSource == null)
        {
            musicSource = FindObjectOfType<AudioSource>(); // Only if one AudioSource in scene
        }
    }
    private void Awake()
    {
        //Music Source
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        //SceneManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
