using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public float interactionDistance = 3f;
    public GameObject interactionUI;

    private Camera mainCamera;

    void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);

        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform == transform)
            {
                if (interactionUI != null)
                    interactionUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("Win");
                }

                return;
            }
        }

        if (interactionUI != null)
            interactionUI.SetActive(false);
    }
}