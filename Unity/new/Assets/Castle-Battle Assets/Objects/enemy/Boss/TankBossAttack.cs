using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossAttack : MonoBehaviour
{
    public GameObject tankBossBullet;
    public Transform attackPos;
    public LineRenderer lineRenderer;

    [SerializeField] private int bulletSalvoCount = 3;
    [SerializeField] private float laserMaxRange = 20f;
    [SerializeField] private float laserChargeTime = 3f;
    
    float intervalBetweenSalvo = 0.3f;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        attackPos = transform.Find("attackPos");
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
            Instantiate(tankBossBullet, attackPos);
            yield return new WaitForSeconds(intervalBetweenSalvo);
        }
        Instantiate(tankBossBullet, attackPos);
    }

    public void EnragedAttack()
    {
        //raycast draw aiming laser
        Vector2 target = new Vector2(player.position.x, player.position.y);
        if (Physics2D.Raycast(attackPos.position, target))
        {
            RaycastHit2D _hit = Physics2D.Raycast(attackPos.position, target);
            Draw2DRay(attackPos.position, _hit.point);
        }
        else
        {
            Draw2DRay(attackPos.position, target.normalized * laserMaxRange);
        }
        //instantiate damage laser
        StartCoroutine(DamageLaser());
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    private IEnumerator DamageLaser()
    {
        yield return new WaitForSeconds(laserChargeTime);
        //adjust linerenderer width
        //set mesh collider
        //set tag damage
        //set linerenderer array null
        lineRenderer.SetPosition(1, attackPos.position);
    }
}
