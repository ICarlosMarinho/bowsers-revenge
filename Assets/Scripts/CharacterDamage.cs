using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        destroyPlayer(collider);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destroyPlayer(collision.collider);
    }

    void destroyPlayer(Collider2D hitInfo)
    {
        GameObject target = hitInfo.transform.gameObject;

        if (target)
        {
            if (gameObject.CompareTag("Projectile") && !target.CompareTag("Projectile")) Destroy(gameObject);

            if (target.CompareTag("Player") || target.CompareTag("Enemy")) Destroy(target, 2f);

        }
    }
}
