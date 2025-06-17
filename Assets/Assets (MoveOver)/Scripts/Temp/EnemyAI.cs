 using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int damage = 10;
    public float wanderRadius = 5f;
    public float wanderInterval = 3f;

    private NavMeshAgent agent;
    private float wanderTimer;
    private Vector3 wanderTarget;
    private float lastAttackTime;
    private PlayerHealth playerHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderTimer = wanderInterval;
        wanderTarget = transform.position;

        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            agent.SetDestination(player.position);

            if (distance <= attackRange)
            {
                agent.isStopped = true; 
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                agent.isStopped = false; 
            }
        }
        else
        {
            agent.isStopped = false;

            wanderTimer += Time.deltaTime;

            if (wanderTimer >= wanderInterval || Vector3.Distance(transform.position, wanderTarget) < 1f)
            {
                wanderTarget = GetRandomWanderPosition();
                agent.SetDestination(wanderTarget);
                wanderTimer = 0;
            }
        }
    }

    void Attack()
    {
        Debug.Log("Enemy attacks!");
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    Vector3 GetRandomWanderPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
