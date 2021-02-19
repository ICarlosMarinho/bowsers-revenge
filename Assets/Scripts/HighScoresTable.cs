using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoresTable : MonoBehaviour
{
    public Transform rankingTemplate;
    public GameObject emptyRankingText;
    private Transform table;
    private HighScores highScores;
    // Start is called before the first frame update
    void Awake()
    {
        table = GetComponent<Transform>();
        highScores = new HighScores();

        List<HighScores.HighScoreEntry> highScoreList = highScores.GetHighScoresList();
        Transform rankingEntry;
        RectTransform rankingEntryRect;

        PlayerPrefs.DeleteKey("highScoreList");
        
        if (highScoreList != null) {

            SetEmptyRankingTextVisible(false);

            for (int i = 0; i < highScoreList.Count; i++) {

                rankingEntry = Instantiate(rankingTemplate, table);
                rankingEntryRect = rankingEntry.GetComponent<RectTransform>();
                rankingEntryRect.anchoredPosition = new Vector2(rankingTemplate.localPosition.x, -20f * (i + 1));


                rankingEntry.Find("Position").GetComponent<TMP_Text>().text = ($"{i + 1}");
                rankingEntry.Find("Score").GetComponent<TMP_Text>().text = (highScoreList[i].score.ToString("0000"));
                rankingEntry.Find("Player").GetComponent<TMP_Text>().text = (highScoreList[i].playerName);
            }

        } else {

            SetEmptyRankingTextVisible(true);
        }
    }

    void SetEmptyRankingTextVisible(bool setVisible) {

        emptyRankingText.SetActive(setVisible);
    }
}
