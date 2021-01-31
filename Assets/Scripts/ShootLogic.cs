using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float cooldownTime = 3f;
    public bool shootCooldown { get; set; } = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void shoot(bool facingLeft)
    {
        animator.SetBool("isShooting", true);

        GameObject objInstance = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

        if (facingLeft) objInstance.GetComponent<Rigidbody2D>().velocity = Vector2.left * projectileSpeed;
        else objInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * projectileSpeed;

        StartCoroutine(CancelSpitingAnimation());
        StartCoroutine(SetFireballCoolDown());
    }

    IEnumerator SetFireballCoolDown()
    {
        shootCooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        shootCooldown = false;
    }

    IEnumerator CancelSpitingAnimation()
    {
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("isShooting", false);
    }
}
