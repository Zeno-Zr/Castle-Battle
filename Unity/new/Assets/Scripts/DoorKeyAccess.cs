using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyAccess : MonoBehaviour
{
    public GameObject key;
    public LayerMask playerLayer;

    Interactable DoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayer())
        {
            Destroy(key.gameObject);
            DoorOpen.enabled = true;
        }
    }

    bool checkPlayer()
    {
        return Physics2D.OverlapBox(new Vector2(key.transform.position.x, key.transform.position.y), new Vector2(0.2f, 1f), 0f, playerLayer);
    }
}
