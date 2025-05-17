using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float drainRate = 25f;
    public float regenRate = 15f;
    public bool isSprinting;
    public Slider staminaBar;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    void Update()
    {
        bool sprintKeyHeld = Input.GetKey(KeyCode.LeftShift); // Check if sprint key is held
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0; // Check if moving

        // Sprinting condition
        if (sprintKeyHeld && isMoving && currentStamina > 0)
        {
            isSprinting = true; // Set to true when sprinting
            currentStamina -= drainRate * Time.deltaTime; // Drain stamina
            currentStamina = Mathf.Max(currentStamina, 0f); // Ensure stamina doesn't go below 0
        }
        else
        {
            isSprinting = false; // Set to false when not sprinting
            if (currentStamina < maxStamina)
            {
                currentStamina += regenRate * Time.deltaTime; // Regenerate stamina
                currentStamina = Mathf.Min(currentStamina, maxStamina); // Ensure stamina doesn't exceed max
            }
        }

        staminaBar.value = currentStamina; // Update stamina bar
    }
    
    public void DeductStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Max(currentStamina, 0f);
        staminaBar.value = currentStamina;
    }
}