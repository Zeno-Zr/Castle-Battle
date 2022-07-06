using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenClose : MonoBehaviour
{
    Rigidbody2D rb;
    bool GateClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GateClosed)
        {
            rb.MovePosition(rb.position + Vector2.down * 2.5f);
            GateClosed = true;
        }
    }

    public void OpenGate()
    {
        if (GateClosed)
        {
            rb.MovePosition(rb.position + Vector2.up * 2.5f);
            Destroy(this);
        }
    }
}
