using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioBoss : MonoBehaviour
{
    private int lifePoints = 100;
    private float velocity = 2.4f;
    public float velocityBonus;
    public Animator marioController;
    public Transform player;
    public Rigidbody2D Mario;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(lifePoints < 1)
        {
            marioController.SetTrigger("Death");
            Invoke("DestroyMario", 3.0f);
        }
        else
        {
            if (player.position.x <= -45.5)
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

            if (transform.position.x <= -60.519 || transform.position.x >= -46)
            {
                velocity = -(velocity);
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);

            }


            transform.position = new Vector3(transform.position.x + ((velocity * velocityBonus) * Time.deltaTime), transform.position.y, transform.position.z);

        }


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Projectile"))
        {
            lifePoints -= 6;
        }


    }

    void DestroyMario()
    {
        Destroy(gameObject);
    }
}

