using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject portalOpen;
    //public GameObject portalClose;

    public void TurnOnPower(GameObject Portal)
    {
        /*
        GameObject nextLevelPortal = Instantiate(portalOpen) as GameObject;
        nextLevelPortal.transform.position = Portal.transform.position;
        */
        portalOpen.SetActive(true);

    }

}
