using UnityEngine;
using UnityEngine.UI; // For UI components (Text)
using TMPro; // For TextMeshPro (if using TMP)

public class EndSceneScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    private int currentScore;
    private int highScore;

    void Start()
    {
        // Load the current score from PlayerPrefs
        currentScore = PlayerPrefs.GetInt("PlayerScore", 0); // Default to 0 if not found

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if not found

        // Check if the current score is greater than the high score
        if (currentScore > highScore)
        {
            highScore = currentScore; // Update high score if current score is greater
            PlayerPrefs.SetInt("HighScore", highScore); // Save the new high score
            PlayerPrefs.Save();
        }

        // Display current score and high score in the End Scene UI
        if (currentScoreText != null)
        {
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    // Method to reset the high score
    public void ResetHighScore()
    {
        highScore = 0; // Reset high score to 0
        PlayerPrefs.SetInt("HighScore", highScore); // Save the reset high score
        PlayerPrefs.Save(); // Save the changes

        // Update the UI text to show the reset high score
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
