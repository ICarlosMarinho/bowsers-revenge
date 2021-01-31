using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator objAnimator;
    private Vector2 initialPosition;
    private Vector2 currentPosition;
    private Vector2 playerPosition;
    private Animator playerAnimator;
    public float speed = 2f;
    public float maxDistance = 5f;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        objAnimator = GetComponent<Animator>();
        initialPosition = transform.position;
    }


    void FixedUpdate()
    {
        currentPosition = transform.position;

        if (GameObject.FindGameObjectWithTag("Player") && !objAnimator.GetBool("isHurt"))
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            if (playerAnimator == null) playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

            if (rbody.velocity.x != 0)
            {
                if (!objAnimator.GetBool("isRunning")) objAnimator.SetBool("isRunning", true);
            }
            else
            {
                if (objAnimator.GetBool("isRunning")) objAnimator.SetBool("isRunning", false);
            }

            run();
        }
    }

    void run()
    {
        if ((!playerInRange() && distanceFromInitialPosition() >= 0.2f) || (playerInRange() && playerInLeftSide()))
        {
            rbody.velocity = Vector2.left * speed;
        }
        else if ((!playerInRange() && distanceFromInitialPosition() <= -0.2f) || (playerInRange() && !playerInLeftSide()))
        {
            rbody.velocity = Vector2.right * speed;
        }
        else
        {
            rbody.velocity = new Vector2(0, 0);
        }
    }
    void CheckDamage(GameObject target)
    {
        if (target.CompareTag("Projectile") || target.CompareTag("Trap"))
        {
            rbody.velocity = new Vector2(0, 0);
            objAnimator.SetBool("isHurt", true);
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

    float distanceFromInitialPosition()
    {
        return currentPosition.x - initialPosition.x;
    }
    bool playerInRange()
    {
        return Mathf.Abs((currentPosition.x - playerPosition.x)) <= maxDistance && !playerAnimator.GetBool("isHurt");
    }

    bool playerInLeftSide()
    {

        return (currentPosition.x - playerPosition.x) > 0f;
    }
}

