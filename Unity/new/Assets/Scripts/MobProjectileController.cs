using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobProjectileController : MonoBehaviour
{
    public Transform ProjectileTarget;
    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(ProjectileTarget.position.x < rb.position.x)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy (gameObject);
    }
}
