using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float time;

    // This method will run when the Unity Play button is clicked, resetting the timer
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnGameStart()
    {
        // Reset timer only when Unity starts running (via Play button)
        PlayerPrefs.SetFloat("timer", 0f);
        PlayerPrefs.Save(); // Ensure the reset is saved
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load the saved timer value (if any) from PlayerPrefs
        time = PlayerPrefs.GetFloat("timer", 0f); // Default to 0f if no timer value is saved
    }

    // Update is called once per frame
    void Update()
    {
        // Accumulate time continuously
        time += Time.deltaTime;

        // Save the timer value in PlayerPrefs
        PlayerPrefs.SetFloat("timer", time);
        PlayerPrefs.Save(); // Save the updated timer value to PlayerPrefs

        // Display time in minutes, seconds, and milliseconds
        int min = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int ms = Mathf.FloorToInt((time * 100) % 100);

        if (TimerText != null)
        {
            TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", min, seconds, ms); // Format and show timer
        }
        else
        {
            Debug.LogError("Timer text is not assigned in the inspector");
        }
    }

    // This method resets the timer manually (can be called during level resets or on certain events)
    public void ResetTimer()
    {
        time = 0f; // Reset the time
        PlayerPrefs.SetFloat("timer", time); // Save the reset time
        PlayerPrefs.Save(); // Ensure the reset is saved

        if (TimerText != null)
        {
            TimerText.text = "00:00.00"; // Optionally reset UI immediately
        }
    }
}
