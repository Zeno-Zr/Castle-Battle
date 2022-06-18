using System.Collections;
using System.Collections.Generic;
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
    private Vector3 weapon_offset = new Vector3(-0.4f, 0, 0);
    private Vector3 armor_offset = new Vector3(0, 0, 0);

    [SerializeField] private GameObject ArmorSlot;
    [SerializeField] private GameObject WeaponSlot;

    public bool IsInsideArmorSlot = false;
    public bool IsInsideWeaponSlot = false;

    [SerializeField] public bool IsAWeapon;

    private void Awake()
    {
        LastPosition = GetComponent<Transform>().position;
    }

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

    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.tag);

        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if (other.CompareTag("Platform") || other.CompareTag("player"))
        {
            // do nothing
        }
        else if (other.CompareTag("ArmorSlot") && !IsAWeapon)
        {
            if (other.GetComponent<ArmorSlot>().HasAnArmorItem)
            {
                _movementDestination = LastPosition;
            }
            else
            {
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
        }
        else if (other.CompareTag("WeaponSlot") && IsAWeapon)
        {
            if (other.GetComponent<WeaponSlot>().HasAWeaponItem)
            {
                _movementDestination = LastPosition;
            }
            else
            {
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
        }
        else
        {
            _movementDestination = LastPosition;
        }

        // avoid overlapping of draggables
        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (IsInsideArmorSlot && other.CompareTag("ArmorSlot"))
        {
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

        if (IsInsideWeaponSlot && other.CompareTag("WeaponSlot"))
        {
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
