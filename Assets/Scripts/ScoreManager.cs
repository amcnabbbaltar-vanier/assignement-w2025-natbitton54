using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score; // Reference to UI Text

    void Start()
    {
        if (score == null)
        {
            Debug.LogError("Score TextMeshProUGUI is not assigned!");
            return;
        }

        // Just update the UI with the current score (no resetting)
        UpdateScoreUI();
    }

    void Update()
    {
        // Keep UI updated
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        score.text = "Score: " + GameManager.Instance.currentScore;
    }
}
