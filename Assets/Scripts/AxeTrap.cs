using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour
{
    private Rigidbody2D rbody2d;
    public float speed = 20f;
    public float maxLeft = -0.55f;
    public float maxRight = 0.55f;
    private bool clockwise = false;
    // Start is called before the first frame update
    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveAxe();
        checkAndToggleDirection();
    }

    void moveAxe()
    {

        if (transform.rotation.z < maxRight && !clockwise)
        {
            rbody2d.angularVelocity = speed;
        }
        else if (transform.rotation.z < maxLeft && clockwise)
        {
            rbody2d.angularVelocity = -speed;
        }
    }

    void checkAndToggleDirection()
    {
        if (transform.rotation.z >= maxRight || transform.rotation.z <= maxLeft) clockwise = !clockwise;
    }

}