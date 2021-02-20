using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("lifeCount", 3);
        PlayerPrefs.SetInt("totalScore", 0);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
