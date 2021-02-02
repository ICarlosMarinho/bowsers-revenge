using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    public bool facingLeft { get; set; }
    private Rigidbody2D rbody2d;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();

        facingLeft = CompareTag("Player") ? true : false;
        enemy = CompareTag("Enemy") ? GetComponent<Enemy>() : null;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Player"))
        {
            if (facingLeft && Input.GetAxisRaw("Horizontal") > 0) Flip();
            else if (!facingLeft && Input.GetAxisRaw("Horizontal") < 0) Flip();
        }
        else if (CompareTag("Enemy") && !enemy.enemyAnimator.GetBool("isHurt"))
        {
            if (facingLeft)
            {
                if (!enemy.playerInRange() && rbody2d.velocity.x > 0) Flip();
                else if (enemy.playerInRange() && !enemy.playerInLeftSide()) Flip();
            }
            else
            {
                if (!enemy.playerInRange() && rbody2d.velocity.x < 0) Flip();
                else if (enemy.playerInRange() && enemy.playerInLeftSide()) Flip();
            }

        }
    }
    void Flip()
    {
        facingLeft = !facingLeft;

        transform.Rotate(0f, 180f, 0f);
    }
}
