using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxDistance = 5f;
    public float speed = 2f;
    public int scoreValue = 100;
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
        currentPosition = transform.position;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) {

            currentPosition = transform.position;
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            checkAndToggleAnimationState();
        }
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
}
