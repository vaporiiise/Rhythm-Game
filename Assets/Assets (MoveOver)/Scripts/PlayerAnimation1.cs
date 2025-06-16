using UnityEngine;

public class PlayerAnimation1 : MonoBehaviour
{
    public Animator animator;
    public KeyCode attackKey;

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            int randomAttack = Random.Range(0, 2); 

            if (randomAttack == 0)
            {
                animator.SetTrigger("attack1");
            }
            else
            {
                animator.SetTrigger("attack2");
            }
        }
    }
}