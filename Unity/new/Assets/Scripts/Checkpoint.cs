using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && transform.gameObject.GetComponent<SpriteRenderer>().sprite != GetComponentInParent<CheckpointList>().greenFlag)
        {
            gm.lastCheckPointPos = transform.position;
            GetComponentInParent<CheckpointList>().ChangeAllCheckpointsToRed();

            transform.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<CheckpointList>().greenFlag;
            Debug.Log("changed checkpoint sprite");

            FindObjectOfType<PlayerAttributes>().SavePlayer();

        }
    }
}
