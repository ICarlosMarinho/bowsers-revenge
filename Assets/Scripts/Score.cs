using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!scoreText.text.Equals(Player.playerScore.ToString())) scoreText.text = $"{Player.playerScore}";
    }
}
