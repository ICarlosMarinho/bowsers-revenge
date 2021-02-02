using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageClearMenu : MonoBehaviour
{
    public GameObject StageClearUI;
    public Transform StageClearPoint;
    public TMP_Text scoreTextResult;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) {

            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < StageClearPoint.position.x) {
                StageClearUI.SetActive(true);
                scoreTextResult.text = $"Your Score: {Player.playerScore}";
                Time.timeScale = 0f;
            }
            
        }
    }

    public void ResetLifes()
    {
        PlayerPrefs.SetInt("lifeCount", 3);
    }

    public void Retry()
    {
        SceneManager.LoadScene("FirstStage");
        StageClearUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
