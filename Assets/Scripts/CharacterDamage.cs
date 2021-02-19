using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDamage : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rbody;
    void Start() {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    private void EnemyHit(Collider2D hitInfo) {

        GameObject hitSource = hitInfo.transform.gameObject;

        if (hitSource.CompareTag("Fireball") && !animator.GetBool("isHurt")) {
            
            rbody.velocity = Vector2.zero;
            Player.stageScore += GetComponent<Enemy>().scoreValue;

            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) * 1f), 2f), ForceMode2D.Impulse);
            animator.SetBool("isHurt", true);
            Destroy(gameObject, 1f);
        }
    }

    private void PlayerHit(Collider2D hitInfo) {
        
        GameObject hitSource = hitInfo.transform.gameObject;
        int currentLifes = PlayerPrefs.GetInt("lifeCount");

        if ((hitSource.CompareTag("Apple")
        || hitSource.CompareTag("Arrow") 
        || hitSource.CompareTag("Trap") 
        || hitSource.CompareTag("Enemy") 
        || hitSource.CompareTag("Boss")) 
        && !animator.GetBool("isHurt")) {

            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) * 1f), 2f), ForceMode2D.Impulse);
            animator.SetBool("isHurt", true);
            
            if (currentLifes > 0) PlayerPrefs.SetInt("lifeCount", currentLifes - 1);
            
            StartCoroutine(ReloadStage());
        }
    }

    private void BossHit(Collider2D hitInfo) {

        GameObject hitSource = hitInfo.transform.gameObject;
        Boss boss = GetComponent<Boss>();
        Enemy enemy = GetComponent<Enemy>();

        if (hitSource.CompareTag("Fireball") && !animator.GetBool("isHurt")) {

            rbody.velocity = Vector2.zero;
            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) * 1f), 2f), ForceMode2D.Impulse);
  
            boss.hp -= 100;
                
            if (boss.hp > 0) {

                enemy.speed += 0.5f;

                animator.SetBool("isHurt", true);
                StartCoroutine("RestoreBoss");
            } else {

                Player.stageScore += GetComponent<Enemy>().scoreValue;

                animator.SetBool("isDefeated", true);
                Destroy(gameObject, 2f);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (CompareTag("Boss")) BossHit(collider);
        else if (CompareTag("Enemy")) EnemyHit(collider);
        else if (CompareTag("Player")) PlayerHit(collider);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Boss")) BossHit(collision.collider);
        else if (CompareTag("Enemy")) EnemyHit(collision.collider);
        else if (CompareTag("Player")) PlayerHit(collision.collider);
    }

    private IEnumerator ReloadStage()
    {
        yield return new WaitForSeconds(1);

        string currScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currScene);
    }

    private IEnumerator RestoreBoss() {

        yield return new WaitForSeconds(2);

        animator.SetBool("isHurt", false);        
    }
}
