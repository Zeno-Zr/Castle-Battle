using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossMove : StateMachineBehaviour
{
    public float attackRange = 3f;
    public float firstSpecialHealth = 100f;
    public float secondSpecialHealth = 50f;

    Transform player;
    Rigidbody2D rb;
    BossLookAt bossLookAt;
    EnemyStats enemyStats;
    FinalBossPath pathing;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player_armor").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossLookAt = animator.GetComponent<BossLookAt>();
        enemyStats = animator.GetComponent<EnemyStats>();
        pathing = animator.GetComponent<FinalBossPath>();

        pathing.IsInMoveStage = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossLookAt.LookAtPlayer();

        float TargetDistance = Vector2.Distance(player.position, rb.position);
        
        if(enemyStats.enemyHealthAmount <= firstSpecialHealth)
        {
            animator.SetTrigger("UseSpecial");
            firstSpecialHealth = 0f;
        }

        if(enemyStats.enemyHealthAmount <= secondSpecialHealth)
        {
            animator.SetTrigger("UseSpecial");
            secondSpecialHealth = 0f;
        }

        if(TargetDistance <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("UseSpecial");
        pathing.IsInMoveStage = false;
    }
}
