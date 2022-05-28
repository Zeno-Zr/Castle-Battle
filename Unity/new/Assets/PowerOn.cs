using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject portalOpen;

    public void TurnOnPower(GameObject Portal)
    {
        GameObject nextLevelPortal = Instantiate(portalOpen) as GameObject;
        Vector3 ground = transform.Find("Ground").position;
        nextLevelPortal.transform.position = ground;
    }

}
