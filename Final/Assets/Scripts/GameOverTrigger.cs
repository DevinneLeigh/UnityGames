using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverTrigger : MonoBehaviour
{
    public SlenderAnimations slenderAnimations;
    public MonoBehaviour playerControlScript;
    public float delayBeforeUI = 2f;
    public float gameOverDistance = 2f;
    public string gameOverSceneName = "GameOver"; // Scene to load

    public SlenderPatrol slenderPatrol;

    private Transform player;
    private bool gameOverTriggered = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (gameOverTriggered || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= gameOverDistance)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOverTriggered = true;

        // Stop enemy patrol and movement
        if (slenderPatrol != null)
        {
            slenderPatrol.StopBehavior();

            var agent = slenderPatrol.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent != null) agent.isStopped = true;
        }

        // Disable player controls
        if (playerControlScript != null)
            playerControlScript.enabled = false;

        // Rotate player to face Slender
        Vector3 dirToSlender = transform.position - player.position;
        dirToSlender.y = 0;
        if (dirToSlender != Vector3.zero)
            player.rotation = Quaternion.LookRotation(dirToSlender);

        // Play scream animation with override
        if (slenderAnimations != null)
            slenderAnimations.PlayAnimation("Scream", true);

        // Start coroutine to load game over scene after a delay
        StartCoroutine(LoadGameOverSceneAfterDelay());
    }

    IEnumerator LoadGameOverSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delayBeforeUI);

        Time.timeScale = 1f; // Unpause in case it's paused

        SceneManager.LoadScene(gameOverSceneName);
    }
}
