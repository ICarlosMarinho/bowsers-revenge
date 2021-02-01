using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f;
    private Animator animator;
    private ShootLogic shootLogic;
    private BoxCollider2D baseCollider;
    private Rigidbody2D rbody;
    private FlipCharacter flipCharacter;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseCollider = GetComponent<BoxCollider2D>();
        shootLogic = GetComponent<ShootLogic>();
        flipCharacter = GetComponent<FlipCharacter>();
    }

    void FixedUpdate()
    {
        if (!animator.GetBool("isHurt"))
        {
            if (rbody.velocity.y > 0 && !baseCollider.IsTouchingLayers()) animator.SetBool("isJumping", true);
            else if (baseCollider.IsTouchingLayers()) animator.SetBool("isJumping", false);

            if (baseCollider.IsTouchingLayers() && Input.GetButton("Horizontal")) animator.SetBool("isRunning", true);

            if (Input.GetButtonDown("Fire1") && !shootLogic.shootCooldown && !animator.GetBool("isCrouching"))
                shootLogic.shoot(flipCharacter.facingLeft);

            if (Input.GetButton("Horizontal") && !animator.GetBool("isCrouching")) Run();

            else
            {
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Jump") && baseCollider.IsTouchingLayers() && !animator.GetBool("isCrouching")) Jump();

            if (Input.GetAxisRaw("Vertical") < 0 && baseCollider.IsTouchingLayers()) animator.SetBool("isCrouching", true);
            else animator.SetBool("isCrouching", false);

        }
    }

    void Run()
    {
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rbody.velocity.y);
    }

    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        CheckDamage(collisionInfo.transform.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        CheckDamage(collisionInfo.transform.gameObject);
    }

    void CheckDamage(GameObject target)
    {
        if (target.CompareTag("Projectile") || target.CompareTag("Trap") || target.CompareTag("Enemy"))
        {

            animator.SetBool("isHurt", true);
            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) * 2f), 2f), ForceMode2D.Impulse);
        }
    }
}

