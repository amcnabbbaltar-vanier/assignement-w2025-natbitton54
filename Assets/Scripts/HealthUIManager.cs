using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    public  Slider healthBar;  // Reference to the TextMeshPro health text UI
    private HealthSystem healthSystem;  // Reference to the HealthSystem script

    void Start()
    {
        // Find the HealthSystem component in the scene
        healthSystem = FindObjectOfType<HealthSystem>();

        if (healthBar == null)
        {
            Debug.LogError("HealthBar UI not assigned!");
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
        if (healthSystem != null && healthBar != null)
        {
            // Display current health 
            healthBar.value = (float) healthSystem.GetCurrentHP() / healthSystem.maxHealth;
        }
    }
}
