using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool facingLeft { get; set; } = true;
    private bool fireballCooldown = false;
    public float cooldownTime = 3f;
    public float speed = 1f;
    public float jumpForce = 5f;
    private Animator animator;
    public Transform firePoint;

    public GameObject firePointPrefab;
    private BoxCollider2D baseCollider;

    private Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (!animator.GetBool("isHurt"))
        {
            if (!baseCollider.IsTouchingLayers()) animator.SetBool("isJumping", true);
            else animator.SetBool("isJumping", false);

            if (baseCollider.IsTouchingLayers() && Input.GetButton("Horizontal")) animator.SetBool("isRunning", true);

            if (Input.GetButtonDown("Fire1") && !fireballCooldown) SpitFire();

            if (Input.GetButton("Horizontal"))
            {
                if (facingLeft && Input.GetAxisRaw("Horizontal") > 0) Flip();
                else if (!facingLeft && Input.GetAxisRaw("Horizontal") < 0) Flip();

                Run();
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Jump") && baseCollider.IsTouchingLayers()) Jump();

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

    void Flip()
    {
        facingLeft = !facingLeft;

        transform.Rotate(0f, 180f, 0f);
    }

    void SpitFire()
    {
        animator.SetBool("isSpiting", true);

        Instantiate(firePointPrefab, firePoint.transform.position, firePoint.transform.rotation);

        StartCoroutine(CancelSpitingAnimation());
        StartCoroutine(SetFireballCoolDown());
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
        if (target.CompareTag("Arrow") || target.CompareTag("Trap") || target.CompareTag("Enemy"))
        {

            animator.SetBool("isHurt", true);
            rbody.AddForce(new Vector2((Random.Range(-1f, 1f) + 2f), 3), ForceMode2D.Impulse);
        }
    }

    IEnumerator SetFireballCoolDown()
    {

        fireballCooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        fireballCooldown = false;
    }

    IEnumerator CancelSpitingAnimation()
    {

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("isSpiting", false);
    }
}

