using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;
    
    [Tooltip("Vertical offset from object origin for line of sight (Y-axis).")]
    public float sightOriginYOffset = 1.5f;
    
    public GameObject playerRef;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    
    
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Vector3 origin = transform.position + new Vector3(0, sightOriginYOffset, 0);
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        canSeePlayer = false;
        
        foreach (var targetCollider in rangeChecks)
        {
            Transform target = targetCollider.transform;
            Vector3 directionToTarget = (target.position - origin).normalized;
            
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(origin, target.position);

                if (!Physics.Raycast(origin, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    return; // Early exit if one target is visible
                }
            }

        // if (rangeChecks.Length != 0)
        // {
        //     Transform target = rangeChecks[0].transform;
        //     Vector3 directionToTarget = (target.position - transform.position).normalized;
        //
        //     if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
        //     {
        //         float distanceToTarget = Vector3.Distance(transform.position, target.position);
        //
        //         if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
        //         {
        //             canSeePlayer = true;
        //         }
        //         else
        //         {
        //             canSeePlayer = false;
        //         }
        //     }
        //     else
        //     {
        //         canSeePlayer = false;
        //     }
        // }
        // else if (canSeePlayer)
        // {
        //     canSeePlayer = false;
        
        }
    }
    
    
    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position + new Vector3(0, sightOriginYOffset, 0);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, radius);

        Vector3 leftBoundary = DirectionFromAngle(-angle / 2);
        Vector3 rightBoundary = DirectionFromAngle(angle / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + leftBoundary * radius);
        Gizmos.DrawLine(origin, origin + rightBoundary * radius);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + transform.forward * radius);
        
        if (canSeePlayer)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float angleInDegrees)
    {
        return Quaternion.Euler(0, angleInDegrees, 0) * transform.forward;
    }
}
