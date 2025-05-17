using UnityEngine;
using UnityEngine.AI;

public class SlenderPatrol : MonoBehaviour
{
    public float patrolRadius = 10f;
    public float patrolWaitTime = 2f;

    private NavMeshAgent agent;
    private FieldOfView fov;
    private Transform player;

    private float waitTimer = 0f;
    private bool isWaiting = false;

    private bool isGameOver = false; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();

        if (fov != null && fov.playerRef != null)
        {
            player = fov.playerRef.transform;
        }

        GoToRandomPoint();
    }

    void Update()
    {
        if (isGameOver) return; 

        if (fov != null && fov.canSeePlayer && player != null)
        {
            // Chase player
            agent.SetDestination(player.position);
        }
        else
        {
            // Patrol mode
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!isWaiting)
                {
                    isWaiting = true;
                    waitTimer = patrolWaitTime;
                }
                else
                {
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0f)
                    {
                        GoToRandomPoint();
                        isWaiting = false;
                    }
                }
            }
        }
    }

    void GoToRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    
    public void StopBehavior()
    {
        isGameOver = true;
        agent.isStopped = true; 
    }
}
