using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageScoreTable : MonoBehaviour
{
    private TMP_Text scoreObtained;
    private TMP_Text timePenalty;
    private TMP_Text finalScore;

    // Start is called before the first frame update
    void Awake()
    {
        int penaltyValue = (int) Mathf.Floor(HudTime.GameTime / 10);
        int finalScoreValue = (Player.stageScore - penaltyValue) < 0? 0 : Player.stageScore - penaltyValue;

        scoreObtained = GameObject.Find("Score Obtained").GetComponent<TMP_Text>();
        timePenalty = GameObject.Find("Time Penalty").GetComponent<TMP_Text>();
        finalScore = GameObject.Find("Final Score").GetComponent<TMP_Text>();

        scoreObtained.text = $"Score Obtained: {Player.stageScore}";
        timePenalty.text = $"Time Penalty: {penaltyValue}";
        finalScore.text = $"Final Score: {finalScoreValue}";

        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + finalScoreValue);
    }
}
