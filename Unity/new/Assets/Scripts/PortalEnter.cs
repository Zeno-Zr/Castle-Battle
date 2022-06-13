using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : Interactable
{

    // when player taps the interact button while touching the working portal, brings the player to the next scene
    public override void Interact()
    {
        //Debug.Log("portal is working");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
