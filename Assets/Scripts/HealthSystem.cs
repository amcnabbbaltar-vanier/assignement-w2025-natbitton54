using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health (3 lives)
    private int currentHealth; // Current lives
    public HealthUIManager healthUIManager; // Reference to UI manager

    void Start()
    {
        if (healthUIManager == null)
        {
            Debug.LogError("HealthUIManager is not assigned!");
            return;
        }

        // Load saved lives from GameManager
        GameManager.Instance.LoadGame();
        currentHealth = GameManager.Instance.currentLives; // Sync with GameManager

        // Ensure currentHealth doesn’t exceed maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthUIManager.UpdateHealthUI(); // Update the UI on start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedTrap"))
        {
            TakeDamage(1); // Take 1 damage (lose 1 life) on RedTrap collision
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease current lives by damage

        if (currentHealth <= 0)
        {
            // If lives reach 0, the level restarts
            Die();
        }

        // Sync lives with GameManager and save
        GameManager.Instance.currentLives = currentHealth;
        GameManager.Instance.SaveGame();

        healthUIManager.UpdateHealthUI(); // Update the UI with the new lives
    }

    void Die()
    {
        // If we're in level 1, reset the timer
        if (SceneManager.GetActiveScene().buildIndex == 1)  // Level 1
        {
            // Reset the score, lives, and timer when the player dies in level 1
            GameManager.Instance.currentScore = 0;
            GameManager.Instance.currentLives = 3; // Reset lives to 3
            GameManager.Instance.SaveGame(); // Save reset lives

            // Reset the timer
            FindObjectOfType<timer>().ResetTimer();
        }
        else
        {
            // If not in level 1, just reset lives and score but do not reset the timer
            GameManager.Instance.currentLives = 3; // Reset lives to 3
            GameManager.Instance.SaveGame(); // Save reset data
        }

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
        return currentHealth; // Return the current lives
    }
}
