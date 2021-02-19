using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HudScore : MonoBehaviour
{
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{Player.stageScore}";
    }
}
