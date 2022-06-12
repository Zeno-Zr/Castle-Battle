using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("player attacked!");
        }
    }
}
