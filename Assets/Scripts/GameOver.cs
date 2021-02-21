using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("FirstStage");
        PlayerPrefs.SetInt("totalScore", 0);
        PlayerPrefs.SetInt("lifeCount", 5);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
