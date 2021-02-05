using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuigiBoss : MonoBehaviour
{
    public int lifePoints = 100;
    private float velocity = 1.5f;
    public float velocityBonus;
    public Transform player;
    public Animator luigiController;
    public bool right_left = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= -113 && player.position.y <= -2.88)
        {

            velocityBonus = 2.3f;
            //Luigi Modo Ataque
            luigiController.SetBool("Attack?", true);
        }
        else
        {
            velocityBonus = 1;
            //Luigi Modo Passivo
            luigiController.SetBool("Attack?", false);

        }

        if (transform.position.x <= -125.8 || transform.position.x >= -113 )
        {
            velocity = -(velocity); 
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
  
        }
            transform.position = new Vector3(transform.position.x + ((velocity * velocityBonus) * Time.deltaTime), transform.position.y, transform.position.z);

    }
}
