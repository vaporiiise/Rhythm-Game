using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerFight : MonoBehaviour
{
    public GameObject popupSprite; 
    public string sceneToLoad;     

    private bool playerInTrigger = false;

    void Start()
    {
        if (popupSprite != null)
            popupSprite.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (popupSprite != null)
                popupSprite.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            if (popupSprite != null)
                popupSprite.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}