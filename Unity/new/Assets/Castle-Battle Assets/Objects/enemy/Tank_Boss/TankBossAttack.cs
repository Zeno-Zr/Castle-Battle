using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossAttack : MonoBehaviour
{
    public GameObject tankBossBullet;
    public Transform attackPos;
    public int bulletSalvoCount = 3;
    
    float intervalBetweenSalvo = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        attackPos = transform.Find("attackPos");
    }

    public void Attack()
    {
        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        for (int i = 1; i < bulletSalvoCount; i++)
        {
            Instantiate(tankBossBullet, attackPos);
            yield return new WaitForSeconds(intervalBetweenSalvo);
        }
        Instantiate(tankBossBullet, attackPos);
    }

    public void EnragedAttack()
    {
        //shoot laser
    }
}
