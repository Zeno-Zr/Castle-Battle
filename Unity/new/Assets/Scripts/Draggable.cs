using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;


    private Collider2D _collider;
    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;

    [SerializeField] private Collider2D WeaponSlot;
    /*
     [SerializeField] private GameObject ArmorHeadSlot;
     [SerializeField] private GameObject ArmorBodySlot;
     [SerializeField] private GameObject ArmorFeetSlot;
    */

    private bool WeaponSlotHasItems = false;
    /*
    private bool ArmorHeadSlotHasItems = false; 
    private bool ArmorBodySlotHasItems = false; 
    private bool ArmorFeetSlotHasItems = false; 
    */






    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    void Update()
    {
        if (WeaponSlotHasItems && WeaponSlot.IsTouching(_collider))
        {
            transform.position = WeaponSlot.transform.position;
        }
    }

    void FixedUpdate()
    {

        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;

                return;
            }

            if (transform.position == _movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;

                if (!WeaponSlot.IsTouching(_collider))
                {
                    WeaponSlotHasItems = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }



        }
    }

    void OnTriggerEnter2D(Collider2D slots)
    {
        Draggable collidedDraggable = slots.GetComponent<Draggable>();
        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = slots.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if (!WeaponSlotHasItems && slots.CompareTag("WeaponSlot") && _collider.CompareTag("Weapon_Pistol"))
        {
            _movementDestination = slots.transform.position;
            WeaponSlotHasItems = true;
        }
        else if (!slots.CompareTag("player"))
        {
            _movementDestination = LastPosition;
        }


    }

}
