using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
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
            if (gameObject.CompareTag("Arrow") && !target.CompareTag("Fireball")) Destroy(gameObject);

            if (target.CompareTag("Player")) Destroy(target, 2f);

        }
    }
}
