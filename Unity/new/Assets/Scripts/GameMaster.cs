using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    public GameObject IsEndless;

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

        if (GameObject.Find("IsEndless") == null)
        {
            Debug.Log("spawned endless object");
            Instantiate(IsEndless, transform.position, Quaternion.identity);
            Debug.Log("changed name to IsEndless");
            FindObjectOfType<IsEndless>().name = "IsEndless";
        }
    }
}
