using System;
using UnityEngine;

public class ReturnToExplore : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            GotoNextLevel();
        }
    }
    void GotoNextLevel()
    {
        
        int perfects = ScoreManager.Instance.perfectCount; // Your system
        if (perfects >= 10)
        {
            GameManager.Instance.rhythmSuccess = true;
        }
        else
        {
            GameManager.Instance.rhythmSuccess = false;
        }


        GameManager.Instance.lastEnemyID = "Enemy_001";
        
        
        Transition transition = FindObjectOfType<Transition>();
    
        if (transition != null)
        {
            transition.LoadNextLevel(); 
        }
        else
        {
            Debug.LogError("Transition object not found at runtime!");
        }
    }
}
