using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    void Update()
    {
  
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("player interacted!");
            checkInteraction();

        }

        if (context.canceled)
        {
            Debug.Log("player cancelled!");
        }
    }

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

