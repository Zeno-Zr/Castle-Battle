using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRemoveOldPart : MonoBehaviour
{
    Transform player;
    Transform endPoint;
    GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_armor").transform;
        endPoint = transform.Find("EndPosition").transform;
        barrier = transform.Find("Barrier").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > (endPoint.position.x + 11f))
        {
            Destroy(this.gameObject);
        }

        if (player.position.x > (barrier.transform.position.x + 2f))
        {
            barrier.GetComponent<Rigidbody2D>().MovePosition(barrier.transform.position - new Vector3(0, -2, 0));
        }
    }
}
