using UnityEngine;
using UnityEngine.AI;

public class SlenderAnimations : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private FieldOfView fov;
    private bool overrideAnimation = false;
    private string currentOverrideName;


    public Transform player; // Optional, can get from FOV

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();

        if (fov != null && fov.playerRef != null)
        {
            player = fov.playerRef.transform;
        }
    }

    void Update()
    {
        HandleAutoAnimation();
    }

    void HandleAutoAnimation()
    {
        if (overrideAnimation) return; 

        if (agent == null) return;

        float speed = agent.velocity.magnitude;
        bool canSeePlayer = fov != null && fov.canSeePlayer;

        if (canSeePlayer && speed > 0.1f)
        {
            PlayAnimation("Run");
        }
        else if (speed > 0.1f)
        {
            PlayAnimation("Walk");
        }
        else
        {
            PlayAnimation("Idle");
        }
    }


    public void PlayAnimation(string animationName, bool forceOverride = false)
    {
        if (forceOverride)
        {
            overrideAnimation = true;
            currentOverrideName = animationName;
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            animator.Play(animationName);
        }
    }

}