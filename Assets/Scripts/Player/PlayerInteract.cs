using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask interactableLayerMask;
    public InventoryManager _inventoryManager;
    public Animator _animator;

    public Transform toolHitBoxPoint;
    private ItemTemplate currentItem;
    public float toolHitRadius = 0.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        _inventoryManager = InventoryManager.Instance;
    }
    public void TryContextInteract(Vector2 mousePosition)
    {
        GameObject interactableObject;
        interactableObject = Physics2D.OverlapPoint(mousePosition, interactableLayerMask)?.gameObject;
        if(interactableObject == null)
        {
            return;
        }
        IContextInteractable interactableObjectComponent = interactableObject.GetComponent<IContextInteractable>();

        if (interactableObjectComponent == null)
        {
            return;
        }

        interactableObjectComponent.OnContextInteract(this, mousePosition);
    }

    public void TryUseTool(Vector2 mousePosition)
    {
        Debug.Log("TryUseTool called");
        int activeSlot = InventoryManager.Instance.GetActiveSlotIndex();
        ItemTemplate activeItem = _inventoryManager.GetItemInSlot(activeSlot);
        Debug.Log("Active Item: " + (activeItem != null ? activeItem.displayedName : "None"));
        if (activeItem == null)
        {
            return;
        }

        ItemTemplate.UseType useType = activeItem.useType;
        Vector2 screenPos = Mouse.current.position.ReadValue();

        mousePosition = GetMouseWorldPosition();


        Debug.Log("MousePositin: " + mousePosition);
        GameObject interactableObject = Physics2D.OverlapPoint(mousePosition, interactableLayerMask)?.gameObject;
        if(interactableObject != null)
        {
            Debug.Log("Interactable Object Found: " + interactableObject.name);
            IItemUseHandler toolHandler;
            toolHandler = interactableObject.GetComponent<IItemUseHandler>();
            if(toolHandler != null)
            {
                Debug.Log("Using tool on interactable object.");
                toolHandler.OnItemUse(this, activeItem, mousePosition);
                return;
            }
            return;
        }
        if(interactableObject == null)
        {
            Debug.Log("No interactable object at mouse position.");
            //if(useType == ItemTemplate.UseType.Tool_WateringCan)
            return;
        }

    }

    private Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
