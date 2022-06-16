using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class DraggableCombined : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    private Vector3 weapon_offset = new Vector3(-0.4f, 0, 0);
    private Vector3 armor_offset = new Vector3(0, 0, 0);

    [SerializeField] private GameObject ArmorSlot;
    [SerializeField] private GameObject WeaponSlot;

    public bool IsInsideArmorSlot = false;
    public bool IsInsideWeaponSlot = false;


    [SerializeField] public bool IsAWeapon = false;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    void Update()
    {
        /*
        // moves the equipped item in sync with the slot
        if (ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems && ArmorSlot.GetComponent<Collider2D>().IsTouching(_collider))
        {
            transform.position = ArmorSlot.transform.position + _offset;
        }
        */
        if (IsInsideArmorSlot && ArmorSlot.GetComponent<Collider2D>().IsTouching(_collider))
        {
            transform.position = ArmorSlot.transform.position + armor_offset;
        }

        if (IsInsideWeaponSlot && WeaponSlot.GetComponent<Collider2D>().IsTouching(_collider))
        {
            transform.position = WeaponSlot.transform.position + weapon_offset;
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
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D slots)
    {
        //  if (ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems && 
        // checking if the armor slot already has armor equipped (for armor)
        if (
            (slots.CompareTag("Armor_Basic") ||
            slots.CompareTag("Armor_Dodge") ||
            slots.CompareTag("Armor_Knight") ||
            slots.CompareTag("Armor_Strong")) &&
            slots.GetComponent<DraggableCombined>().IsInsideArmorSlot
            )
        {
            _movementDestination = LastPosition;
            return;
        }

        // checking if the weapon slot already has armor equipped (for weapons)
        if (
            (slots.CompareTag("Weapon_Pistol") || 
            slots.CompareTag("Weapon_Rifle")) &&
            slots.GetComponent<DraggableCombined>().IsInsideWeaponSlot
            )
        {
            Debug.Log("AAAA");
            _movementDestination = LastPosition;
            return;
        }

        // checking if a weapon is dragged to the wrong slot (that is either empty or equipped)
        if (IsAWeapon)
        {
            if (slots.CompareTag("ArmorSlot"))
            {
                _movementDestination = LastPosition;
                return;
            } 
            else if (
            (slots.CompareTag("Armor_Basic") ||
            slots.CompareTag("Armor_Dodge") ||
            slots.CompareTag("Armor_Knight") ||
            slots.CompareTag("Armor_Strong")) &&
            slots.GetComponent<DraggableCombined>().IsInsideArmorSlot
            )
            {
                _movementDestination = LastPosition;
                return;
            }
        }
        
        // checking if an armor is dragged to the wrong slot (that is either empty or equipped)
        if (!IsAWeapon)
        {
            if (slots.CompareTag("WeaponSlot"))
            {
                _movementDestination = LastPosition;
                return;
            }
            else if (
            (slots.CompareTag("Weapon_Pistol") || 
            slots.CompareTag("Weapon_Rifle")) &&
            slots.GetComponent<DraggableCombined>().IsInsideWeaponSlot
            )
            {
                _movementDestination = LastPosition;
                return;
            }       
        }

        if (!IsInsideArmorSlot && slots.CompareTag("ArmorSlot"))
        {
            _movementDestination = slots.transform.position + armor_offset;
            //ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems = true;
            IsInsideArmorSlot = true;

            if (_collider.CompareTag("Armor_Basic"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add armor stats1");

            }
            else if (_collider.CompareTag("Armor_Dodge"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add armor stats2");

            }
            else if (_collider.CompareTag("Armor_Knight"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add armor stats3");

            }
            else if (_collider.CompareTag("Armor_Strong"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add armor stats4");

            }
        }

        if (!IsInsideWeaponSlot && slots.CompareTag("WeaponSlot"))
        {
            _movementDestination = slots.transform.position + weapon_offset;
            //ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems = true;
            IsInsideWeaponSlot = true;

            if (_collider.CompareTag("Weapon_Pistol"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add weapon stats1");

            }
            else if (_collider.CompareTag("Weapon_Rifle"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("add weapon stats2");
            }
        }

        DraggableCombined collidedDraggable = slots.GetComponent<DraggableCombined>();
        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = slots.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
    }

    void OnTriggerExit2D(Collider2D slots)
    {
        // if (ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems && slots.CompareTag("ArmorSlot"))
        if (IsInsideArmorSlot && slots.CompareTag("ArmorSlot"))
        {
            // ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems = false;
            IsInsideArmorSlot = false;

            if (_collider.CompareTag("Armor_Basic"))
            {
                //TODO: function to call to remove armor's stats
                Debug.Log("remove armor stats1");
            }
            else if (_collider.CompareTag("Armor_Dodge"))
            {
                //TODO: function to call to remove armor's stats
                Debug.Log("remove armor stats2");
            }
            else if (_collider.CompareTag("Armor_Knight"))
            {
                //TODO: function to call to remove armor's stats
                Debug.Log("remove armor stats3");
            }
            else if (_collider.CompareTag("Armor_Strong"))
            {
                //TODO: function to call to remove armor's stats
                Debug.Log("remove armor stats4");
            }
        }

        if (IsInsideWeaponSlot && slots.CompareTag("WeaponSlot"))
        {
            // ArmorSlot.GetComponent<ArmorSlot>().ArmorSlotHasItems = false;
            IsInsideWeaponSlot = false;

            if (_collider.CompareTag("Weapon_Pistol"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("remove weapon stats1");

            }
            else if (_collider.CompareTag("Weapon_Rifle"))
            {
                //TODO: function to call to implement armor's stats
                Debug.Log("remove weapon stats2");
            }
        }

    }
}
