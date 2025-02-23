using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float time;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnGameStart()
    {
        PlayerPrefs.SetFloat("timer", 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("timer", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        PlayerPrefs.SetFloat("timer", time);

        int min = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int ms = Mathf.FloorToInt((time * 100) % 100);

        if (TimerText != null)
        {
            TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", min, seconds, ms);
        }
        else
        {
            Debug.LogError("Timer text is not assigned in the inspector");
        }
    }

    public void ResetTimer()
    {
        time = 0f;
        PlayerPrefs.SetFloat("timer", time); // Save the reset time
        if (TimerText != null)
        {
            TimerText.text = "00:00.00"; // Optionally reset UI immediately
        }
    }
}
