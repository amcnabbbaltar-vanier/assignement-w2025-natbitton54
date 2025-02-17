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
        Time.timeScale = 1f; // Ensure time resumes
        SceneManager.LoadScene(1); // Reloads the level
        Debug.Log("Level Restarted");
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time resumes
        SceneManager.LoadScene(0); // Loads Main Menu (Scene 0)
    }
}
