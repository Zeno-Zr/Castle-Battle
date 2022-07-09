using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour
{
    public bool isFlipped = false;
    public bool attackUnderCooldown = false;
    public float attackInterval = 5f;

    Transform player;
    
    void Start()
    {
        player = GameObject.Find("Player_armor").transform;
    }

    public void StartCooldown()
    {
        attackUnderCooldown = true;
        StartCoroutine(ResetCooldown());
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(attackInterval);
        attackUnderCooldown = false;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        } else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
