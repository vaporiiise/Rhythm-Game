using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.Animations;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public GameObject popupCanvas;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health: " + currentHealth);
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took damage. Health: " + currentHealth);
        UpdateHealthBar();
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed. Health: " + currentHealth);
    }
    void UpdateHealthBar() 
    {
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Player died!");
        animator.SetTrigger("Death");
        TriggerPopup();
    }
    public void TriggerPopup()
    {
        popupCanvas.SetActive(true);
    }
}
