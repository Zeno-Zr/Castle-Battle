using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBossAttack : MonoBehaviour
{
    PolygonCollider2D Scythe;
    // Start is called before the first frame update
    void Start()
    {
        Scythe = transform.Find("boss_droid_arm").GetComponent<PolygonCollider2D>();
    }

    void Attack()
    {
        Scythe.enabled = true;
    }

    void StopAttack()
    {
        Scythe.enabled = false;
    }
}
