using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace RangedMobAI
{
public class RangedMobAI : MonoBehaviour
{
    public Transform target;
    public LayerMask targetLayer;
    public float speed = 200f;
    public float aggroRange = 100f;
    public float attackRange = 50f;
    public float nextWaypointDistance = 3f;
    public GameObject projectile;
    public float attackInterval = 5f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    float attackCooldown = 0f;

    Seeker seeker;
    Rigidbody2D rb;
    Transform bodytransform;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        bodytransform = GetComponent<Transform>();


        InvokeRepeating("UpdatePath", 0f, 0.5f);
        InvokeRepeating("FireProjectile", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (!isInPatrolRange() || isInAttackRange())
        {
            path = null;
            rb.velocity = new Vector2((rb.velocity.x * 0.25f), rb.velocity.y);
        }
        else if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void FireProjectile()
    {
        if (attackCooldown < attackInterval)
        {
            attackCooldown += 0.5f;
        } else if (isInAttackRange())
        {
            Instantiate(projectile, bodytransform.position, bodytransform.rotation);
            attackCooldown = 0f;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } 
        
        else
        {
            reachedEndOfPath = false;
        }
        

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Checks if target is in aggro range
    bool isInPatrolRange()
    {
        return Physics2D.OverlapCircle(rb.position, aggroRange, targetLayer);
    }

    bool isInAttackRange()
    {
        return Physics2D.OverlapCircle(rb.position, attackRange, targetLayer);
    }
}
}