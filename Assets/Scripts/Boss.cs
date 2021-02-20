using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame updat
    [Range(1, 1000)]
    public int hp;
    public GameObject stageClearUI;
    private Enemy enemy;

    void Start() {

        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate() {

        if (enemy.enemyAnimator.GetBool("isDefeated")) {

            Time.timeScale = 0f;
            stageClearUI.SetActive(true);
        }
    }
}
