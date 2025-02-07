using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsManager : Singleton<ControlsManager>
{
    [SerializeField] LayerMask objectMask = 0;
    [SerializeField, Range(1, 50)] float detectionDistance = 20;
    [SerializeField] GenericObject currentObjectSelected;

    new Camera camera = new();
    Ray ray = new();

    public Vector3 CursorLocation => GetMousePosition();

    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(CursorLocation);
        Debug.DrawRay(ray.origin, ray.direction * detectionDistance, Color.blue);
    }

    Vector3 GetMousePosition()
    {
        Vector2 _mousePos = InputManager.Instance.MousePosition.ReadValue<Vector2>();
        return new Vector3(_mousePos.x, _mousePos.y, 0);
    }

    public void SelectObject(InputAction.CallbackContext _context)
    {
        bool _hitEntity = Physics.Raycast(ray, out RaycastHit _result, detectionDistance, objectMask);
        if (!_hitEntity) return;
        currentObjectSelected = _result.transform.GetComponent<GenericObject>();
        Debug.Log($"Selected Object : {currentObjectSelected}");
    }

    public void Move(InputAction.CallbackContext _context)
    {
        if (currentObjectSelected is EntityMoving && currentObjectSelected.IsPlayerOwned)
        {
            EntityMoving _currentObjectSelected = currentObjectSelected as EntityMoving;
            bool _hit = Physics.Raycast(ray, out RaycastHit _result, detectionDistance, objectMask);
            if (!_hit) return;
            if (_result.transform.GetComponent<GenericObject>())
            {
                GenericObject _objectHit = _result.transform.GetComponent<GenericObject>();
                Debug.Log($"selected : {_currentObjectSelected.ObjectName} | hit : {_objectHit.ObjectName}");
                if (!(_objectHit.ObjectName == _currentObjectSelected.ObjectName))
                {
                }
                else
                {
                    Debug.Log("SAME");
                }
            }
            else
            {
                _currentObjectSelected.Move(_result.point);
            }
        }
    }

    public void OpenOptions(InputAction.CallbackContext _context)
    {
        Debug.Log("OPTIONS");
    }
}