using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("lifeCount") == 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResetLifes()
    {
        PlayerPrefs.SetInt("lifeCount", 3);
    }

    public void Retry()
    {
        SceneManager.LoadScene("FirstStage");
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
