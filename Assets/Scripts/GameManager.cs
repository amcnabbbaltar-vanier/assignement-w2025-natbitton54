using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentScore;
    public int currentLives;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnGameStart()
    {
        // Reset score ONLY when game starts from Unity Play button
        PlayerPrefs.SetInt("PlayerScore", 0);
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
        currentScore = PlayerPrefs.GetInt("PlayerScore", 0);
        currentLives = PlayerPrefs.GetInt("PlayerLives", 3);
        Debug.Log("Game Loaded: Score - " + currentScore + ", Lives - " + currentLives);
    }
}
