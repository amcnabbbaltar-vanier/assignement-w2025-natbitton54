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

        UpdateScoreUI();
    }

    void Update()
    {
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        if (score == null)
        {
            Debug.LogError("Score TextMeshProUGUI is not assigned!");
            return;
        }

        score.text = "Score: " + GameManager.Instance.currentScore.ToString();
    }
}
