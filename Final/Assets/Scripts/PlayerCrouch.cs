using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float standingHeight = 2f;
    public float crouchHeight = 1f;
    public float cameraStandY = 0.4f;
    public float cameraCrouchY = 0.2f;

    public KeyCode crouchKey = KeyCode.C;
    public float transitionSpeed = 8f;

    private bool isCrouching = false;
    private bool isInCrawlSpace = false;
    private float targetHeight;
    private float targetCamY;

    void Start()
    {
        targetHeight = standingHeight;
        targetCamY = cameraStandY;
    }

    void Update()
    {
        bool crouchHeld = Input.GetKey(crouchKey);

        if (crouchHeld)
        {
            isCrouching = true;
            targetHeight = crouchHeight;
            controller.transform.localScale = new Vector3(.5f, .25f, .5f);
            targetCamY = cameraCrouchY;
        }
        else if (!isInCrawlSpace && CanStandUp())
        {
            isCrouching = false;
            targetHeight = standingHeight;
            controller.transform.localScale = new Vector3(1, 1, 1);
            targetCamY = cameraStandY;
        }

        // Smooth transition for height
        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * transitionSpeed);

        // Smooth transition for camera
        Vector3 camPos = cameraTransform.localPosition;
        camPos.y = Mathf.Lerp(camPos.y, targetCamY, Time.deltaTime * transitionSpeed);
        cameraTransform.localPosition = camPos;
    }

    bool CanStandUp()
    {
        float distanceToCheck = standingHeight - crouchHeight;
        Vector3 origin = transform.position + Vector3.up * crouchHeight;
        return !Physics.Raycast(origin, Vector3.up, distanceToCheck);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrawlOnly"))
            isInCrawlSpace = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrawlOnly"))
            isInCrawlSpace = false;
    }
}