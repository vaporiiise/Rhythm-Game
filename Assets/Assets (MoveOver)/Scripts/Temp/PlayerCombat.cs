using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public BoxCollider hitBox;
    public float activeTime = 0.3f;
    public KeyCode attackKey = KeyCode.Mouse0;
    public Animator animator;

    private bool isAttacking = false;
    void Start()
    {
        if (hitBox == null)
        {
            hitBox = GetComponent<BoxCollider>();
        }
        hitBox.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartCoroutine(Attack());
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

    System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        hitBox.enabled = true;
        yield return new WaitForSeconds(activeTime);
        hitBox.enabled = false;
        isAttacking = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered With" + other.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");
        }
    }
}
