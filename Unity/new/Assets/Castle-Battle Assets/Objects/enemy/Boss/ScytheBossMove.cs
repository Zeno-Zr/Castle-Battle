using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBossMove : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float enragedHealth = 100f;

    Transform player;
    Rigidbody2D rb;
    BossLookAt bossLookAt;
    EnemyStats enemyStats;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player_armor").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossLookAt = animator.GetComponent<BossLookAt>();
        enemyStats = animator.GetComponent<EnemyStats>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossLookAt.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        float distance = Vector2.Distance(player.position, rb.position);
        if(distance > 1f && distance <= 10f)
        {
            rb.MovePosition(newPos);
        }

        if(enemyStats.enemyHealthAmount <= enragedHealth)
        {
            animator.SetBool("IsEnraged", true);
        }

        if(distance <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
    }
}
