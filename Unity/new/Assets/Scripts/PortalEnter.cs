using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : Interactable
{

    public override void Interact()
    {
        Debug.Log("portal is working");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
