using System.Collections;
using UnityEngine;

public class Mario : MonoBehaviour
{  
    private Rigidbody2D rbody;
    private ShootLogic shootLogic;
    private FlipCharacter flipCharacter;
    private Enemy enemy;
    public float spinCooldownTime = 20f;
    private bool spinCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        flipCharacter = GetComponent<FlipCharacter>();
        shootLogic = GetComponent<ShootLogic>();
    }

    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) {

            if (enemy.playerInRange() && !spinCooldown) Spin();
            else if (!enemy.playerInRange() || enemy.enemyAnimator.GetBool("isHurt") || player.GetComponent<Animator>().GetBool("isHurt"))
                NormalMode(); 
        }

        if (enemy.playerInRange() && !shootLogic.shootCooldown && !enemy.enemyAnimator.GetBool("isHurt") && !enemy.enemyAnimator.GetBool("isDefeated")) {
            shootLogic.shoot(flipCharacter.facingLeft);
        }
    }

    private IEnumerator SetSpinCooldown() {

        spinCooldown = true;

        yield return new WaitForSeconds(spinCooldownTime);

        spinCooldown = false;
    }

    private void Spin () {

        enemy.enemyAnimator.SetBool("isSpinning", true);

        transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.eulerAngles.z + 180);
        
        if (enemy.playerInLeftSide()) rbody.AddForce(new Vector2(-0.6f, 1f) * enemy.speed, ForceMode2D.Impulse);
        else rbody.AddForce(new Vector2(0.6f, 1f) * enemy.speed, ForceMode2D.Impulse);

        rbody.sharedMaterial.bounciness = 1f;

        StartCoroutine(SetNormalMode());
        StartCoroutine(SetSpinCooldown());
    }

    private IEnumerator SetNormalMode() {

        yield return new WaitForSeconds(5f);

        NormalMode();
    }

    private void NormalMode() {

        enemy.enemyAnimator.SetBool("isSpinning", false);
        rbody.sharedMaterial.bounciness = 0f;
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        rbody.velocity = new Vector2(0, -1) * enemy.speed;
    }
}

