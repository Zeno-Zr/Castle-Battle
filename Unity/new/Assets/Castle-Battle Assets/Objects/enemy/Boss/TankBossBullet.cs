using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossBullet : MonoBehaviour
{
    public float speed = 500f;
    public float lifeTime = 4f;

    Transform player;
    Rigidbody2D rb;
    Vector2 TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_armor").transform;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
        TargetPosition = new Vector2(player.position.x, player.position.y);
        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (TargetPosition - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" || collision.gameObject.tag != "Damage")
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
