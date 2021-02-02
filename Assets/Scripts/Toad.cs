using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && !enemy.enemyAnimator.GetBool("isHurt")) enemy.followPlayer();
    }
}

