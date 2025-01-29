using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] Controls controls = null;
    [SerializeField] InputAction mousePostition = null;
    [SerializeField] InputAction leftClick = null;
    [SerializeField] InputAction rightClick = null;
    [SerializeField] InputAction options = null;

    [SerializeField] ControlsManager controlsManager = null;

    public InputAction MousePosition => mousePostition;
    public InputAction LeftClick => leftClick;
    public InputAction RightClick => rightClick;
    public InputAction Options => options;

    protected override void Awake()
    {
        base.Awake();
        controls = new();
    }

    private void OnEnable()
    {
        mousePostition = controls.Mouse.MousePosition;
        mousePostition.Enable();

        leftClick = controls.Mouse.LeftClick;
        leftClick.Enable();
        leftClick.performed += controlsManager.SelectObject;

        rightClick = controls.Mouse.RightClick;
        rightClick.Enable();
        rightClick.performed += controlsManager.Move;

        options = controls.Keyboard.Options;
        options.Enable();
        options.performed += controlsManager.OpenOptions;
    }

    private void OnDisable()
    {
        mousePostition.Disable();
        leftClick.Disable();
        rightClick.Disable();
        options.Disable();
    }
}