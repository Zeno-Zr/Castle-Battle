using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobProjectileController : MonoBehaviour
{
    public float bulletRadius = 0.16f;
    public LayerMask playerLayer;
    Transform ProjectileTarget;
    public float speed = 500f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ProjectileTarget = (GameObject.Find("Player_armor")).transform;

        if(ProjectileTarget.position.x < rb.position.x)
        {
            speed = -speed;
        }
        StartCoroutine(BulletExpiry());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(transform.position, bulletRadius, playerLayer))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletExpiry()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
