using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public PlayerInputActions _inputActions;
    public static InputService Instance { get; private set; }

    public Vector2 MoveInput { get; private set; }

    public event Action<Vector2> OnMove;
    public event Action OnMenuToggle;
    public event Action<Vector2> OnContextInteract;
    public event Action<Vector2> OnToolUse;
    public event Action<float> OnItemSelect;

    public Vector2 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        _inputActions = new PlayerInputActions();

        _inputActions.Player.Enable();




        _inputActions.Player.Move.performed += ctx =>
        {
            MoveInput = ctx.ReadValue<Vector2>();
            OnMove?.Invoke(MoveInput);
        };
            _inputActions.Player.Move.canceled += ctx => {
            MoveInput = Vector2.zero;
            OnMove?.Invoke(MoveInput);
        };



        _inputActions.Player.Interact.performed += ctx => HandleContextInteraction(mousePosition);
        _inputActions.Player.OpenMenu.performed += ctx => HandleOpenMenu();
        _inputActions.Player.ToolUse.performed += ctx => HandleToolUse(mousePosition);
        _inputActions.Player.SelectItem.performed += ctx => HandleSelectItem(ctx.ReadValue<float>());

        mousePosition = GetMousePosition();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void HandleContextInteraction(Vector2 mousePosition)
    {
        OnContextInteract?.Invoke(mousePosition);
    }

    private void HandleOpenMenu()
    {
        OnMenuToggle?.Invoke();
    }

    private void HandleToolUse(Vector2 mousePosition)
    {
        OnToolUse?.Invoke(mousePosition);
    }

    private void HandleSelectItem(float itemSlot)
    {
        Debug.Log("InputService: Item slot selected: " + itemSlot);
        OnItemSelect?.Invoke(itemSlot);
    }

    private Vector2 GetMousePosition()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = new Vector2(worldPoint.x, worldPoint.y);
        return mousePosition;
    }


    public void EnableUIControls()
    {
        _inputActions.UI.Enable();
    }

    public void EnablePlayerControls()
    {
        _inputActions.UI.Disable();
        _inputActions.Player.Enable();
    }
}
