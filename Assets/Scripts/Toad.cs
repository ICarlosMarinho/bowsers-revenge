using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{

    //Correr
    public Transform posicao;
    public float speed;
    public float x;

    //Verificar Parede
    public Transform WallCheck;
    public bool Wall;
    public LayerMask whatisWall;

    void Start()
    {


    }


    void Update()
    {

        x = transform.position.x;
        x += speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        Wall = Physics2D.OverlapCircle(WallCheck.position, 0.09f, whatisWall);

        if (Wall)
        {
            posicao.rotation = Quaternion.Euler(0, posicao.rotation.eulerAngles.y + 180, 0); ;
            speed = -(speed);
        }


    }
}