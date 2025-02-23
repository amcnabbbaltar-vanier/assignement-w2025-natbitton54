using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health (3 health points)
    private int currentHealth; // Current health
    public HealthUIManager healthUIManager;  // Reference to UI manager

    void Start()
    {
        if (healthUIManager == null)
        {
            Debug.LogError("HealthUIManager is not assigned!");
            return;
        }

        // Initialize health to max
        currentHealth = maxHealth;
        healthUIManager.UpdateHealthUI(); // Update the UI on start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedTrap"))
        {
            TakeDamage(1); // Take 1 damage on RedTrap collision
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease current health by damage

        if (currentHealth <= 0)
        {
            // If health reaches 0, the level restarts
            Die();
        }

        healthUIManager.UpdateHealthUI(); // Update the UI with the new health
    }

    void Die()
    {
        // Reset the score, lives, and timer when the player dies
        GameManager.Instance.currentScore = 0;
        GameManager.Instance.currentLives = 3;
        GameManager.Instance.SaveGame();

        // Reset the timer
        FindObjectOfType<timer>().ResetTimer();

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void UpdateHealthUI()
    {
        if (healthUIManager != null)
        {
            healthUIManager.UpdateHealthUI();
        }
    }

    public int GetCurrentHP()
    {
        return currentHealth;  // Return the current health
    }
}
