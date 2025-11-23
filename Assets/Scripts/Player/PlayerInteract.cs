using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask interactableLayerMask;
    public InventoryManager _inventoryManager;
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
        int activeSlot = InventoryManager.Instance.GetActiveSlotIndex();
        ItemTemplate activeItem = _inventoryManager.GetItemInSlot(activeSlot);

        if(activeItem == null)
        {
            return;
        }

        ItemTemplate.UseType useType = activeItem.useType;

        GameObject interactableObject = Physics2D.OverlapPoint(mousePosition, interactableLayerMask)?.gameObject;
        if(interactableObject != null)
        {
            IItemUseHandler toolHandler;
            toolHandler = interactableObject.GetComponent<IItemUseHandler>();
            if(toolHandler != null)
            {
                toolHandler.OnItemUse(this, activeItem, mousePosition);
                return;
            }
            return;
        }
        if(interactableObject == null)
        {
            //if(useType == ItemTemplate.UseType.Tool_WateringCan)
            return;
        }

    }
}
