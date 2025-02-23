using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentScore;
    public int currentLives; // This will store the lives (matching HealthSystem's currentHealth)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Preserve GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }

        // Ensure lives are loaded and reset if needed
        LoadGame();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnGameStart()
    {
        // Reset score and lives ONLY when game starts from Unity Play button
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("PlayerLives", 3); // Reset lives to 3 at game start
        PlayerPrefs.Save();
    }

    public void SaveGame()
    {
        // Save score and lives ONLY during scene transitions
        PlayerPrefs.SetInt("PlayerScore", currentScore);
        PlayerPrefs.SetInt("PlayerLives", currentLives);
        PlayerPrefs.Save();
        Debug.Log("Game Saved: Score - " + currentScore + ", Lives - " + currentLives);
    }

    public void LoadGame()
    {
        // Load saved values only when transitioning scenes
        currentScore = PlayerPrefs.GetInt("PlayerScore", 0); // Default to 0 if not found
        currentLives = PlayerPrefs.GetInt("PlayerLives", 3); // Default lives to 3 if not found

        // If currentLives is less than or equal to 0, reset it to 3
        if (currentLives <= 0)
        {
            currentLives = 3;
            SaveGame(); // Ensure reset lives are saved
        }

        Debug.Log("Game Loaded: Score - " + currentScore + ", Lives - " + currentLives);
    }
}
