using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignDisplay : Interactable
{
    public GameObject Sign;
    public override void Interact()
    {
        Debug.Log("sign display is working");
        Sign.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitSign()
    {
        Debug.Log("sign display is off");
        Sign.SetActive(false);
        Time.timeScale = 1;
    }


}
