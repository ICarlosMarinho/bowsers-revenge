using UnityEngine;
using TMPro;
public class FInalStageClear : MonoBehaviour
{
    public GameObject recordEntryContainer;
    public TMP_InputField recordEntryTf;
    public GameObject saveBtn;
    private HighScores highScores;

    // Start is called before the first frame update
    void Awake()
    {
        highScores = new HighScores();
    
        if (highScores.isRecord()) recordEntryContainer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        print (recordEntryContainer.activeInHierarchy);

        if (recordEntryContainer.activeInHierarchy) {
    
            CheckAndDisableSaveBtn();
        }   
    }

    private void CheckAndDisableSaveBtn() {

        if (recordEntryTf.text == null || recordEntryTf.text.Length < 3) saveBtn.SetActive(false);
        else saveBtn.SetActive(true);
    }

    public void SaveHighScore() {

        highScores.addScoreEntry(PlayerPrefs.GetInt("totalScore"), recordEntryTf.text);

        recordEntryContainer.SetActive(false);
    }
}
