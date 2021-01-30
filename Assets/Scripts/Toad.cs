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
    public float speed = 2f;
    public float maxDistance = 5f;
    private bool runningToLeft = false;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        objAnimator = GetComponent<Animator>();
        initialPosition = transform.position;
    }


    void FixedUpdate()
    {
        currentPosition = transform.position;

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            if (rbody.velocity.magnitude != 0)
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

    float distanceFromInitialPosition()
    {
        return currentPosition.x - initialPosition.x;
    }
    bool playerInRange()
    {
        return Mathf.Abs((currentPosition.x - playerPosition.x)) <= maxDistance;
    }

    bool playerInLeftSide()
    {

        return (currentPosition.x - playerPosition.x) > 0f;
    }
}

