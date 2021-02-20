using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserJr : MonoBehaviour
{
    [SerializeField]
    public List<Vector2> fireballSpawnPoints;

    [SerializeField]
    [Range(-100f, 100f)]
    public float gizmoLineHeight = 5f;
    public float minFireballVelocity = 5f;
    public float maxFireballVelocity = 10f;
    public GameObject fireballPrefab;

    public float fireballCooldownTime = 10f;
    private bool fireballCooldown = false;
    private Enemy enemy;

    void Start() {

        enemy = GetComponent<Enemy>();
    }
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) {

            if (enemy.playerInRange() && !fireballCooldown && !enemy.enemyAnimator.GetBool("isHurt") && !enemy.enemyAnimator.GetBool("isDefeated")) 
                ShootFireballs();
        }
    }

    void OnDrawGizmos() {

        Gizmos.color = Color.red;

        foreach (Vector2 position in fireballSpawnPoints) {

            Gizmos.DrawLine(position, new Vector2(position.x, position.y + gizmoLineHeight));
        }
    }

    private void ShootFireballs () {

        enemy.enemyAnimator.SetBool("isShooting", true);

        foreach (Vector2 position in fireballSpawnPoints)
        {
            if (Random.Range(0f, 1f) < 0.3f) {

                GameObject objInstance = Instantiate(fireballPrefab, position, fireballPrefab.transform.rotation);

                objInstance.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(minFireballVelocity, maxFireballVelocity);
            } 
        }

        StartCoroutine(CancelShootingAnimation());
        StartCoroutine(SetFireballCooldown());
    }

    private IEnumerator SetFireballCooldown() {

        fireballCooldown = true;

        yield return new WaitForSeconds(fireballCooldownTime);

        fireballCooldown = false;
    }

    IEnumerator CancelShootingAnimation()
    {
        yield return new WaitForSeconds(2f);

        enemy.enemyAnimator.SetBool("isShooting", false);
    }
}


