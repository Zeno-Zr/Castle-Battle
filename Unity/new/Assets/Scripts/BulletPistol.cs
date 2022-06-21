using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol: MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;

    public LayerMask whatIsSolid;

    //public PlayerAttack playerAttack;
    


    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("enemy take damage");
                hitInfo.collider.GetComponent<EnemyStats>().TakeDamage();
            }
            /*
            if (Physics2D.OverlapCircle(transform.position, 0.2f, whatIsSolid))
            {
                Debug.Log("platform hit");
                //playerAttack.damage();
            }
            */
            DestroyProjectile();
        }


        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
