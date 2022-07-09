using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    //[SerializeField] private bool swap = false;

    private static CheckpointList instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeAllCheckpointsToRed()
    {
        foreach (Transform transform in gameObject.transform)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = redFlag;
        }
    }


}
