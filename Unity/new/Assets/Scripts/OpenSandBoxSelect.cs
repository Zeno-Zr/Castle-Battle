using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSandBoxSelect : Interactable
{
    public SandBoxSceneSelect selectScript;

    // when player taps the interact button while touching the working portal, brings the player to the next scene
    public override void Interact()
    {
        Debug.Log("Open Sandbox Scene Select");
        selectScript.OpenCanvas();
    }
}
