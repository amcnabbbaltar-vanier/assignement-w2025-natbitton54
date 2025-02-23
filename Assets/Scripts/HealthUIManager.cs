using TMPro;
using UnityEngine;

public class HealthUIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;  // Reference to the TextMeshPro health text UI
    private HealthSystem healthSystem;  // Reference to the HealthSystem script

    void Start()
    {
        // Find the HealthSystem component in the scene
        healthSystem = FindObjectOfType<HealthSystem>();

        // Check if healthText is assigned
        if (healthText == null)
        {
            Debug.LogError("HealthText UI not assigned!");
        }

        if (healthSystem == null)
        {
            Debug.LogError("HealthSystem reference not found!");
        }

        // Initial UI Update
        UpdateHealthUI();
    }

    // This function updates the health UI when called
    public void UpdateHealthUI()
    {
        // Only update UI if healthSystem and healthText are assigned
        if (healthSystem != null && healthText != null)
        {
            // Display current health out of 3 (e.g., "Health: 3/3")
            healthText.text = "Health: " + healthSystem.GetCurrentHP() + "/" + healthSystem.maxHealth;
        }
    }
}
