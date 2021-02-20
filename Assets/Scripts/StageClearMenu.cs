using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearMenu : MonoBehaviour
{
    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
