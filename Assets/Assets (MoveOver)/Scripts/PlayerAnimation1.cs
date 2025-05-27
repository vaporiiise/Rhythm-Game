using UnityEngine;

public class PlayerAnimation1 : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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