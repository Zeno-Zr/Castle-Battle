using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAttack : MonoBehaviour
{
    public GameObject bossBullet;
    public Transform attackPos;

    [SerializeField] private int bulletSalvoCount = 5;
    
    float intervalBetweenSalvo = 0.3f;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_armor").transform;
    }

    public void Attack()
    {
        StartCoroutine(ShootBullet());
    }

    private IEnumerator ShootBullet()
    {
        for (int i = 1; i < bulletSalvoCount; i++)
        {
            Instantiate(bossBullet, attackPos);
            yield return new WaitForSeconds(intervalBetweenSalvo);
        }
        Instantiate(bossBullet, attackPos);
    }
}
