using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleShotYoshi : MonoBehaviour
{
    private float velocidade = 1.8f;
    public Transform posicaoTiro;

 
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidade ;
    }

    // Update is called once per frame
    void Update()
    {   
        if (posicaoTiro.position.x >= 4 || posicaoTiro.position.x <= -4)
        {
            Destroy(transform.gameObject);
        }
    }
}
