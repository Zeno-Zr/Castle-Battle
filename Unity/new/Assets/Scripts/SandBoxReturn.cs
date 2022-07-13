using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandBoxReturn : Interactable
{
    // when player taps the interact button while touching the working portal, returns to select scene
    public override void Interact()
    {
        Debug.Log("Return to Sandbox Scene Select");
        SceneManager.LoadScene("SandBoxEntrence");
    }
}
