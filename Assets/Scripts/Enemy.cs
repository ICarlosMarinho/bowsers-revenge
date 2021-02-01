using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxDistance = 5f;
    public float speed = 2f;
    public Rigidbody2D rbody { get; set; }
    public Vector2 initialPosition { get; set; }
    public Vector2 currentPosition { get; set; }
    public Vector2 playerPosition { get; set; }
    public Animator playerAnimator { get; set; }
    public Animator enemyAnimator { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;

        if (GameObject.FindGameObjectWithTag("Player") && !enemyAnimator.GetBool("isHurt"))
        {
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        checkAndToggleAnimationState();
    }

    public bool playerInRange()
    {
        return GameObject.FindGameObjectWithTag("Player") != null
        ? Mathf.Abs((currentPosition.x - playerPosition.x)) <= maxDistance && !playerAnimator.GetBool("isHurt")
        : false;
    }

    public bool playerInLeftSide()
    {
        return currentPosition.x > playerPosition.x;
    }

    public float distanceFromInitialPosition()
    {
        return currentPosition.x - initialPosition.x;
    }

    public void followPlayer()
    {
        if ((!playerInRange() && distanceFromInitialPosition() >= 0.2f)
        || (playerInRange() && playerInLeftSide()))
        {
            rbody.velocity = Vector2.left * speed;
        }
        else if ((!playerInRange() && distanceFromInitialPosition() <= -0.2f)
        || (playerInRange() && !playerInLeftSide()))
        {
            rbody.velocity = Vector2.right * speed;
        }
        else
        {
            rbody.velocity = new Vector2(0, 0);
        }
    }

    void checkAndToggleAnimationState()
    {
        if (rbody.velocity.x != 0)
        {
            if (!enemyAnimator.GetBool("isRunning")) enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            if (enemyAnimator.GetBool("isRunning")) enemyAnimator.SetBool("isRunning", false);
        }
    }

    void CheckDamage(GameObject target)
    {
        if (target.CompareTag("Projectile") || target.CompareTag("Trap"))
        {
            rbody.velocity = new Vector2(0, 0);
            enemyAnimator.SetBool("isHurt", true);
            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) * 2f), 2f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        CheckDamage(collisionInfo.transform.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        CheckDamage(collisionInfo.transform.gameObject);
    }
}
