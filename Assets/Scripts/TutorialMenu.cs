using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public GameObject TutorialMenuUI;
    public static bool firstLoad = true;

    void Start()
    {
        if (firstLoad)
        {
            Time.timeScale = 0f;
            TutorialMenuUI.SetActive(true);
            firstLoad = false;
        }
    }

    public void CloseTutorial()
    {
        TutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
