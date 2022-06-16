using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    [SerializeField] private Vector3 _offset = new Vector3(-0.4f, 0, 0);

    [SerializeField] private Collider2D WeaponSlot;
    [SerializeField] private Collider2D ArmorSlot;

    private bool WeaponSlotHasItems = false;
    private bool ArmorSlotHasItems = false;

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
        // moves the equipped item in sync with the slot
        if (WeaponSlotHasItems && WeaponSlot.IsTouching(_collider))
        {
            transform.position = WeaponSlot.transform.position + _offset;
        }

        // moves the equipped item in sync with the slot
        if (ArmorSlotHasItems && ArmorSlot.IsTouching(_collider))
        {
            transform.position = ArmorSlot.transform.position + _offset;
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

                // checks if the weapon is still equipped. If not, stops weapon from following Weaponslot
                if (!WeaponSlot.IsTouching(_collider))
                {
                    WeaponSlotHasItems = false;
                    //TODO: function to remove weapon's stats
                    Debug.Log("remove weapon stats");
                }
                // checks if the armor is still equipped. If not, stops armor from following Armorslot
                if (!ArmorSlot.IsTouching(_collider))
                {
                    ArmorSlotHasItems = false;
                    //TODO: function to remove armor's stats
                    Debug.Log("remove armor stats");
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

        if (!WeaponSlotHasItems && slots.CompareTag("WeaponSlot"))
        {
            switch (_collider.tag)
            {
                case "Weapon_Pistol":

                    _movementDestination = slots.transform.position + _offset;
                    WeaponSlotHasItems = true;
                    //TODO: function to call to implement weapon's stats
                    Debug.Log("add weapon stats");
                    break;

                default:
                    break;

            }
        }
        else if (!ArmorSlotHasItems && slots.CompareTag("ArmorSlot"))
        {
            switch (_collider.tag)
            {
                case "Armor_Basic":
                case "Armor_Dodge":
                case "Armor_Knight":
                case "Armor_Strong":

                    _movementDestination = slots.transform.position + _offset;
                    ArmorSlotHasItems = true;
                    //TODO: function to call to implement armor's stats
                    Debug.Log("add armor stats");
                    break;

                default:
                    break;
            }
        }
        else if (!slots.CompareTag("player") && !slots.CompareTag("Platform"))
        {
            _movementDestination = LastPosition;
        }
    }


    //ontriggerexit2d for checking if object left the collider?

}
