using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        GameManager.OnGameStart();
        timer.OnGameStart();
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
