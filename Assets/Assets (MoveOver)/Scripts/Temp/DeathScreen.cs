using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public MonoBehaviour Player;
    public MonoBehaviour Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player.enabled = false;
        Animator.enabled = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
            Player.enabled = true;
            Animator.enabled = true;

            
        }
        
    }
}
