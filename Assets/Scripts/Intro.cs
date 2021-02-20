using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> pagesList; 
    public GameObject introScreen; 
    public GameObject mainMenuScreen;  
    void Start()
    {
        StartCoroutine(ShowHistory());
    }

    private IEnumerator ShowHistory() {

        foreach(GameObject page in pagesList) {

            yield return ShowPage(page);
        }

        introScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }

    private IEnumerator ShowPage(GameObject page) {

        page.SetActive(true);

        yield return new WaitForSeconds(15f);

        page.SetActive(false);
    }

    public void SkipIntro() {
        
        StopAllCoroutines();
        introScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
