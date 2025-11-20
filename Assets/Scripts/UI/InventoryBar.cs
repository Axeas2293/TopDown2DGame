using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class InventoryBar : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public int activeSlotIndex;
    private bool initialized;

    public List<SlotView> slotViews;



    public void OnDisable()
    {
        if (InventoryManager.Instance != null)
        {

            InventoryManager.OnActiveSlotChanged -= HandleActiveSlotChanged;
            InventoryManager.OnItemInSlotChanged -= HandleItemInSlotChanged;

        }
    }





    public void Initialize(InventoryManager inventoryManager)
    {
        if (initialized) return;
        InventoryManager = inventoryManager;

        InventoryManager.OnActiveSlotChanged += HandleActiveSlotChanged;
        InventoryManager.OnItemInSlotChanged += HandleItemInSlotChanged;

        for (int slotIndex = 0; slotIndex < slotViews.Count; slotIndex++)
        {
            ItemTemplate item = InventoryManager.GetItemInSlot(slotIndex);
            slotViews[slotIndex].SetIcon(item.icon);
        }
        activeSlotIndex = InventoryManager.GetActiveSlotIndex();
        UpdateHighlightForAllSlots(activeSlotIndex);
        initialized = true;
    }





    private void HandleActiveSlotChanged(int newSlotIndex)
    {
        UpdateHighlightForAllSlots(newSlotIndex);
    }

    private void HandleItemInSlotChanged(int slotIndex, ItemTemplate itemID)
    {
        if(itemID == null)
        {
            slotViews[slotIndex].SetIcon(null);
            return;
        }
    }

    private void UpdateHighlightForAllSlots(int slotIndex)
    {
        for(int i = 0; i < slotViews.Count; i++)
        {
            slotViews[i].SetHighlighted(i == slotIndex);
        }
    }
}

