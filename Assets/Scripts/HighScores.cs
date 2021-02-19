using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores
{
    public List<HighScoreEntry> GetHighScoresList() {

        string listJson = PlayerPrefs.GetString("highScoreList");
        HighScoreList list = null;
        
        if (listJson != null) list = JsonUtility.FromJson<HighScoreList>(PlayerPrefs.GetString("highScoreList"));

        return list != null? list.highScores : null;
    }

    public void SaveHighScoreList(List<HighScoreEntry> list) {

        List<HighScoreEntry> sortedList = SortList(list);
        string jsonList = JsonUtility.ToJson(new HighScoreList(sortedList));

        PlayerPrefs.SetString("highScoreList", jsonList);
        PlayerPrefs.Save();
    }

    private List<HighScoreEntry> SortList(List<HighScoreEntry> list) {
        
        List<HighScoreEntry> auxList = new List<HighScoreEntry>(list);
        HighScoreEntry auxEntry;

        for (int i = 0; i < auxList.Count; i++) {
            for (int j = i + 1; j < auxList.Count; j++) {
                
                if (auxList[i].score < auxList[j].score) {
                    auxEntry = auxList[i];
                    auxList[i] = auxList[j];
                    auxList[j] = auxEntry;
                }
            }
        }

        return auxList;
    }

    public bool isRecord() {

        List<HighScoreEntry> list = GetHighScoresList();

        return PlayerPrefs.GetInt("totalScore") >= list[list.Count - 1].score;
    }

    public void addScoreEntry(int score, string playerName) {

        List<HighScoreEntry> list = GetHighScoresList();
        HighScoreEntry newHighScore = new HighScoreEntry(score, playerName);

        if (list == null || list.Count < 5) list.Add(newHighScore);
        else {

            for (int i = list.Count - 1; i >= 0; i--) {

                if (list[i].score <= newHighScore.score) list[i] = newHighScore; 
            }
        }

        SaveHighScoreList(list);
    }

    public class HighScoreList {

        public List<HighScoreEntry> highScores;

        public HighScoreList(List<HighScoreEntry> list) {
            this.highScores = list;
        }
    }

    [System.Serializable]
    public class HighScoreEntry {

        public int score;
        public string playerName;

        public HighScoreEntry(int score, string playerName) {
            this.score = score;
            this.playerName = playerName;
        }
    }
}
