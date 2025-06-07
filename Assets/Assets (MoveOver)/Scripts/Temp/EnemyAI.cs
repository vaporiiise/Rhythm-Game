using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float wanderRadius = 5f;
    public float wanderInterval = 3f;

    private NavMeshAgent agent;
    private float wanderTimer;
    private Vector3 wanderTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderTimer = wanderInterval;
        wanderTarget = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            wanderTimer += Time.deltaTime;

            if (wanderTimer >= wanderInterval || Vector3.Distance(transform.position, wanderTarget) < 1f)
            {
                wanderTarget = GetRandomWanderPosition();
                agent.SetDestination(wanderTarget);
                wanderTimer = 0;
            }
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
    }
}
