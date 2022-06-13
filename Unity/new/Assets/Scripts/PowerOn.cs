using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject portalOpen;

    // sets the working portal object to active
    public void TurnOnPower(GameObject Portal)
    {
        portalOpen.SetActive(true);
    }

}
