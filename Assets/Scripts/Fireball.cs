using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rbody;
    private bool facingLeft;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        facingLeft = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().facingLeft;

        if (facingLeft) rbody.velocity = Vector2.left * speed;
        else rbody.velocity = Vector2.right * speed;
    }

}
