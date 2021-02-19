using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D collision) {

        GameObject target = collision.gameObject;

        if (target.CompareTag("Player")) Invoke("Fall", 1f);
        else if (target.CompareTag("Trap")) Destroy(gameObject);
    }

    private void Fall() {
        rbody.gravityScale = 10f;
    }
}
