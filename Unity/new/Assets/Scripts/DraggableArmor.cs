using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class DraggableArmor : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    private Vector3 _offset = new Vector3(0, 0, 0);

    [SerializeField] private GameObject ArmorSlot;

    public bool IsInsideArmorSlot = false;

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
        if (
            (slots.CompareTag("Armor_Basic") ||
            slots.CompareTag("Armor_Dodge") ||
            slots.CompareTag("Armor_Knight") ||
            slots.CompareTag("Armor_Strong")) &&
            slots.GetComponent<DraggableArmor>().IsInsideArmorSlot
            )
        {
            _movementDestination = LastPosition;
            return;
        }

        if (!IsInsideArmorSlot && slots.CompareTag("ArmorSlot"))
        {
            _movementDestination = slots.transform.position + _offset;
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

        Draggable collidedDraggable = slots.GetComponent<Draggable>();
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
    }
}
