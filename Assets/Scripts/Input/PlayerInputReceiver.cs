using UnityEngine;

public class PlayerInputReceiver : MonoBehaviour
{

    public PlayerMovement _playerMovement;
    public PlayerInteract _playerInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        InputService.Instance.OnMove += HandleMove;
        InputService.Instance.OnContextInteract += HandleContextInteraction;
        InputService.Instance.OnToolUse += HandleToolUse;
        InputService.Instance.OnItemSelect += HandleSelectItem;

    }

    private void OnDisable()
    {
        InputService.Instance.OnMove -= HandleMove;
        InputService.Instance.OnContextInteract -= HandleContextInteraction;
        InputService.Instance.OnToolUse -= HandleToolUse;
        InputService.Instance.OnItemSelect -= HandleSelectItem;
    }

    private void HandleMove(Vector2 value)
    {
        _playerMovement.SetMoveInput(value);
    }

    private void HandleContextInteraction(Vector2 mousePosition)
    {
        _playerInteract.TryContextInteract(mousePosition);
    }

    private void HandleToolUse(Vector2 mousePosition)
    {
        _playerInteract.TryUseTool(mousePosition);
    }

    private void HandleSelectItem(float slotIndex)
    {
        int slotIndexInt = Mathf.RoundToInt(slotIndex);
        InventoryManager.Instance.SetActiveSlot(slotIndexInt);
    }
}
