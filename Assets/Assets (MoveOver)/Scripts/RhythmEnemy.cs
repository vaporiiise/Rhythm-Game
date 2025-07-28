using UnityEngine;

public class RhythmEnemy : MonoBehaviour
{
    public string enemyID; 

    void Start()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.rhythmSuccess &&
            GameManager.Instance.lastEnemyID == enemyID)
        {
            Destroy(gameObject); 
        }
    }
}
