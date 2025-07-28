using UnityEngine;

public class ExploreGmaeManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool rhythmSuccess = false;
    public string lastEnemyID = "";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}

