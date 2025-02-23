using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        // Load game data
        GameManager.Instance.LoadGame();

        // Debug to check if data is loaded correctly
        Debug.Log("Loaded Score: " + GameManager.Instance.currentScore);
        Debug.Log("Loaded Lives: " + GameManager.Instance.currentLives);
    }
}
