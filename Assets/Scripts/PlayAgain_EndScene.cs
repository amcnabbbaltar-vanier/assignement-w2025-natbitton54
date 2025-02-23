using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayAgain_EndScene : MonoBehaviour
{
    [SerializeField] GameObject playAgainEndScene; // Reference to the Play Again button GameObject

    // Start is called before the first frame update
    public void PlayAgain()
    {
        // Reset the score, lives, and timer before loading the scene
        ResetGame();

        // Load the first scene (replace with your main game scene index)
        SceneManager.LoadScene(1);
    }

    private void ResetGame()
    {
        // Reset the score to 0
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.Save();

        // Reset the lives to 3
        PlayerPrefs.SetInt("PlayerLives", 3);
        PlayerPrefs.Save();

        // Reset the timer to 0
        FindObjectOfType<timer>().ResetTimer();

        // Ensure that the changes are saved to PlayerPrefs
        PlayerPrefs.Save();

        Debug.Log("Game Reset: Score - 0, Lives - 3, Timer - 0");
    }
}
