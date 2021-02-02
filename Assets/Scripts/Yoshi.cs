using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
    private ShootLogic shootLogic;
    private FlipCharacter flipCharacter;
    private Enemy enemy;
    void Start()
    {
        shootLogic = GetComponent<ShootLogic>();
        enemy = GetComponent<Enemy>();
        flipCharacter = GetComponent<FlipCharacter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemy.playerInRange() && !shootLogic.shootCooldown && !enemy.enemyAnimator.GetBool("isHurt"))
        {
            shootLogic.shoot(flipCharacter.facingLeft);
        }
    }
}
