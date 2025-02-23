using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText; // Reference to the TMP text component

    // Start is called before the first frame update
    void Start()
    {
        // Get the final time from PlayerPrefs (the time that was saved in the timer)
        float finalTime = PlayerPrefs.GetFloat("timer", 0f); // Default to 0f if no timer value is saved

        // Convert the time into minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        int milliseconds = Mathf.FloorToInt((finalTime * 100) % 100);

        // Update the TMP text with the final time
        if (finalTimeText != null)
        {
            finalTimeText.text = string.Format("Final Time: {0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        }
        else
        {
            Debug.LogError("FinalTimeText is not assigned in the inspector");
        }
    }
}
