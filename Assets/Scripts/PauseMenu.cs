using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    private static bool isPaused = false;

    void Start(){
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Show pause menu
        Time.timeScale = 0f; // Pause game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu
        Time.timeScale = 1f; // Resume game
        isPaused = false;
    }

    public void RestartLevel()
    {
        // Check if the current scene is Scene 1 (BuildIndex 1)
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // Find and reset the timer
            timer gameTimer = FindObjectOfType<timer>(); 
            if (gameTimer != null)
            {
                gameTimer.ResetTimer(); 
            }
            else
            {
                Debug.LogWarning("Timer script not found in the scene.");
            }

            GameManager.Instance.currentScore = 0; // Reset score
            GameManager.Instance.currentLives = 3; // Reset lives to 3
            GameManager.Instance.SaveGame();
        }

        Time.timeScale = 1f; // Ensure time resumes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the level
        Debug.Log("Level Restarted");
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time resumes
        SceneManager.LoadScene(0); // Loads Main Menu (Scene 0)
    }
}
