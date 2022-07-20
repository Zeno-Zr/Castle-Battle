using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossAttack : MonoBehaviour
{
    public GameObject tankBossBullet;
    public Transform attackPos;
    public LineRenderer lineRenderer;

    [SerializeField] private int bulletSalvoCount = 3;
    //[SerializeField] private float laserMaxRange = 20f;
    [SerializeField] private float laserChargeTime = 3f;
    
    float intervalBetweenSalvo = 0.3f;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        attackPos = transform.Find("attackPos");
        lineRenderer.useWorldSpace = true;
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
        player = GameObject.Find("Player_armor").transform;
        
        //raycast draw aiming laser
        Vector2 direction = new Vector2((player.position.x - attackPos.position.x), (player.position.y - attackPos.position.y));
        if (Physics2D.Raycast(attackPos.position, direction))
        {
            RaycastHit2D _hit = Physics2D.Raycast(attackPos.position, direction);
            Draw2DRay(attackPos.position, _hit.point);
            Debug.Log("Tank Hit Target " + _hit.point);
        
            //instantiate damage laser
            StartCoroutine(DamageLaser());
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    private IEnumerator DamageLaser()
    {
        yield return new WaitForSeconds(laserChargeTime);
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.3f;

        //create mesh from renderer
        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, true);

        //add mesh collider
        MeshCollider meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
        //meshCollider.isTrigger = true;
        gameObject.tag = "Damage";
        yield return new WaitForSeconds(0.5f);

        //clear linerenderer array
        Destroy(meshCollider);
        lineRenderer.positionCount = 0;
    }
}
