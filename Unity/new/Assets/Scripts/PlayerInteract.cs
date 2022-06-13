using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    // For interact button
    public void Interact(InputAction.CallbackContext context)
    {
        // when the button is being tapped and held
        if (context.performed)
        {
            Debug.Log("player interacted!");
            checkInteraction();

        }
        
        // when the is no longer being tapped
        if (context.canceled)
        {
            Debug.Log("player cancelled!");
        }
    }


    // checks for any objects with a collider2D touching the player
    private void checkInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}

