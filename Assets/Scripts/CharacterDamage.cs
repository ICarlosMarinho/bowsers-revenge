using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterDamage : MonoBehaviour
{
    void destroyEnemy(Collider2D hitInfo)
    {
        GameObject target = hitInfo.transform.gameObject;

        if (target)
        {
            if (gameObject.CompareTag("Projectile") && !target.CompareTag("Projectile")) Destroy(gameObject);
            if (target.CompareTag("Enemy")) Destroy(target, 2f);

        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        destroyEnemy(collider);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destroyEnemy(collision.collider);
    }


}
