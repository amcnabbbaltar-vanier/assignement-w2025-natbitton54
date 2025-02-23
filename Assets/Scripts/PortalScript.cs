using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string nextSceneName; // The name of the next scene to load

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the portal is the player
        if (other.CompareTag("Player"))
        {
            // Save the game before loading the next scene
            GameManager.Instance.SaveGame();

            // Load the next level
            LoadNextLevel();
        }
    }

    // Function to load the next level
    void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next Scene Name is not assigned!");
        }
    }
}