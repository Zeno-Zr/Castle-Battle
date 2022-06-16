using UnityEngine;

public class DragControllerArmor : MonoBehaviour
{
    public DraggableArmor LastDragged => _lastDragged;

    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private DraggableArmor _lastDragged;

    void Awake()
    {
        DragControllerArmor[] controllers = FindObjectsOfType<DragControllerArmor>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (_isDragActive && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Drop();
            return;
        }

        if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                DraggableArmor draggable = hit.transform.gameObject.GetComponent<DraggableArmor>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag(); 
                }
            }
        }
    }

    void InitDrag()
    {
        _lastDragged.LastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool IsDragging)
    {
        _isDragActive = _lastDragged.IsDragging = IsDragging;
        _lastDragged.gameObject.layer = IsDragging ? Layer.Dragging : Layer.Default;
    }
}
