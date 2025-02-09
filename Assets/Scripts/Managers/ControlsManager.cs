using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

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
            switch (_result.transform.GetComponent<GenericObject>())
            {
                case Plant:
                    Plant _plantHit = _result.transform.GetComponent<Plant>();
                    Debug.Log($"Plant {_plantHit}");
                    StartCoroutine(_currentObjectSelected.MoveAndAttack(_plantHit, _result.point));
                    break;
                case EntityMoving:
                    EntityMoving _entityHit = _result.transform.GetComponent<EntityMoving>();
                    Debug.Log($"Entité : {_entityHit}");
                    if (!(_entityHit.ObjectName == currentObjectSelected.ObjectName))
                    {
                        StartCoroutine(_currentObjectSelected.MoveAndAttack(_entityHit, _result.point));
                    }
                    else
                    {
                        Debug.Log("SELF");
                    }
                    break;
                case GenericObject:
                    GenericObject _objectHit = _result.transform.GetComponent<GenericObject>();
                    print($"Objet : {_objectHit}");
                    break;
                default:
                    Debug.Log("Rien");
                    _currentObjectSelected.Move(_result.point);
                    break;
            }
        }
    }

    public void OpenOptions(InputAction.CallbackContext _context)
    {
        Debug.Log("OPTIONS");
    }
}