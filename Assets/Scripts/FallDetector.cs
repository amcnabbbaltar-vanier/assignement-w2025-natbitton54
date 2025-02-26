using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           GameManager.Instance.currentLives -= 2;

           if(GameManager.Instance.currentLives <= 0)
           {
                GameManager.Instance.currentLives = 3;
            }

            GameManager.Instance.SaveGame();
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        // Reload the current scene to restart the level
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
