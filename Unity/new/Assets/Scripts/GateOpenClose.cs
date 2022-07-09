using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenClose : MonoBehaviour
{
    public EnemyStats enemyStats;

    Rigidbody2D rb;
    bool GateClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GateClosed && enemyStats.enemyHealthAmount <= 0)
        {
            rb.MovePosition(rb.position + Vector2.up * 2.5f);
            Destroy(this);
        };
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GateClosed)
        {
            rb.MovePosition(rb.position + Vector2.down * 2.5f);
            GateClosed = true;
        }
    }
}
