using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        Transform transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }
}
