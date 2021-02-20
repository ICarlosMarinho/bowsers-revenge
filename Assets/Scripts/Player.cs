using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public static int stageScore;
    public float speed = 1f;
    public float jumpForce = 5f;
    private Animator animator;
    private ShootLogic shootLogic;
    private PolygonCollider2D baseCollider;
    private Rigidbody2D rbody;
    private FlipCharacter flipCharacter;
    public GameObject gameOverUI;

    void Awake()
    {
        stageScore = PlayerPrefs.GetInt("totalScore");
        
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseCollider = GetComponent<PolygonCollider2D>();
        shootLogic = GetComponent<ShootLogic>();
        flipCharacter = GetComponent<FlipCharacter>();
    }

    void FixedUpdate()
    {
        if (!animator.GetBool("isHurt"))
        {
            if (!Grounded()) animator.SetBool("isJumping", true);
            else animator.SetBool("isJumping", false);

            if (Grounded() && Input.GetButton("Horizontal") && !animator.GetBool("isCrouching")) {

                animator.SetBool("isRunning", true);
                Run();

            } else animator.SetBool("isRunning", false);

            if (Input.GetButtonDown("Fire1") && !shootLogic.shootCooldown && !animator.GetBool("isCrouching")) 
                shootLogic.shoot(flipCharacter.facingLeft);
            
                

            if (Input.GetButtonDown("Jump") && Grounded() && !animator.GetBool("isCrouching")) Jump();

            if (Input.GetAxisRaw("Vertical") < 0 && Grounded()) animator.SetBool("isCrouching", true);
            else animator.SetBool("isCrouching", false);

        } else {

            if (PlayerPrefs.GetInt("lifeCount") < 1) {

                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }
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
    private bool Grounded() {

        Bounds boundsCollider = baseCollider.bounds; 
        float extraHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boundsCollider.center, 
            baseCollider.bounds.size, 
            0f, 
            Vector2.down, 
            extraHeight, 
            groundLayerMask
        );

        return raycastHit.collider != null;
    }
}

