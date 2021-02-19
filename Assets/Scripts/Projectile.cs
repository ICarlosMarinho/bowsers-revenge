using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start() {

        PlayShootSound();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayImpactSound();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayImpactSound();
        Destroy(gameObject);
    }

    void PlayShootSound() {

        switch (tag)
        {
            case "Arrow": AudioManager.instance.Play("ArrowShoot");
            break;

            case "Fireball": AudioManager.instance.Play("FireballShoot");
            break;

            case "Apple": AudioManager.instance.Play("AppleShoot");
            break;
        }
    }

    void PlayImpactSound() {

        switch (tag)
        {
            case "Arrow": AudioManager.instance.Play("ArrowImpact");
            break;

            case "Fireball": AudioManager.instance.Play("FireballImpact");
            break;

            case "Apple": AudioManager.instance.Play("AppleImpact");
            break;
        }
    }
}
