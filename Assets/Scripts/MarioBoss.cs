using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioBoss : MonoBehaviour
{
    private int lifePoints = 100;
    private float velocity = 2.4f;
    public float velocityBonus;
    public Animator marioController;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= -45 && player.position.y <= -0.9)
        {

            velocityBonus = 2.9f;
            //Matio Modo Ataque
            marioController.SetBool("Attack", true);
        }
        else
        {
            velocityBonus = 1;
            //Mario Modo Passivo
            marioController.SetBool("Attack", false);

        }

        if (transform.position.x <= -60.50 || transform.position.x >= -46)
        {
            velocity = -(velocity);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);

        }
        transform.position = new Vector3(transform.position.x + ((velocity * velocityBonus) * Time.deltaTime), transform.position.y, transform.position.z);

    }
}