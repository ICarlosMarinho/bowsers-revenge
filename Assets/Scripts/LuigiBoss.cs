using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuigiBoss : MonoBehaviour
{
    public static int lifePoints = 100;
    private float velocity = 1.5f;
    public float velocityBonus;
    public bool isAlive = true;
    public Transform player;
    public Animator luigiController;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifePoints < 1)
        {
            
            isAlive = false;
            luigiController.SetTrigger("Death");
            Invoke("DestroyLuigi",3.0f);

        }

        if (isAlive) {
            if (player.position.x <= -112.5 && player.position.y <= -2.88)
            {

                velocityBonus = 2.6f;
                //Luigi Modo Ataque
                luigiController.SetBool("Attack?", true);
            }
            else
            {
                velocityBonus = 1;
                //Luigi Modo Passivo
                luigiController.SetBool("Attack?", false);

            }

            if (transform.position.x <= -125.8 || transform.position.x >= -113)
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
            lifePoints -= 8;
        }


    }

    void DestroyLuigi()
    {
        Destroy(gameObject);
    }
}
