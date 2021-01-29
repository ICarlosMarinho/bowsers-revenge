using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
    public Rigidbody2D yoshiRigidbody;
    public float forcaPulo, rateFire = 1.9f, currentTime;
    public int valorAleatorio;
    public Transform groundCheck, posicaoTiro, posicaoPlayer;
    public bool grounded, verSeVirou = false;
    public LayerMask whatIsGround;
    public Animator animation;
    public GameObject macaPrefab;


    void Start()
    {
        
    }

    
    void Update()
    {

        //Yoshi Pulando
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
        valorAleatorio = Random.Range(1, 1000);
        if (valorAleatorio == 25 && grounded)
        {
            yoshiRigidbody.AddForce(new Vector2(0, forcaPulo));
            
        }
        
        //Yoshi Atirando
        currentTime += Time.deltaTime;
        if (currentTime >= rateFire && animation.GetBool("Atirar") == false)
        {
            currentTime = 0;

            Instantiate(macaPrefab, posicaoTiro.position, posicaoTiro.rotation);
            animation.SetBool("Atirar", true);
        }
        else
        {
            animation.SetBool("Atirar", false);
        }

        if (posicaoPlayer.position.x < yoshiRigidbody.transform.position.x && verSeVirou == false)
        {
            yoshiRigidbody.transform.rotation = Quaternion.Euler(0, yoshiRigidbody.transform.rotation.eulerAngles.y + 180, 0);
            verSeVirou = true;
        }
        if(posicaoPlayer.position.x > yoshiRigidbody.transform.position.x && verSeVirou == true)
        {
            yoshiRigidbody.transform.rotation = Quaternion.Euler(0, yoshiRigidbody.transform.rotation.eulerAngles.y + 180, 0);
            verSeVirou = false;
        }       

    }
}
