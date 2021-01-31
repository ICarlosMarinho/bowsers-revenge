using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
    private ShootLogic shootLogic;
    private FlipCharacter flipCharacter;
    // Start is called before the first frame update
    void Start()
    {
        shootLogic = GetComponent<ShootLogic>();
        flipCharacter = GetComponent<FlipCharacter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!shootLogic.shootCooldown) shootLogic.shoot(flipCharacter.facingLeft);
    }
}
