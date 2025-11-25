using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class InventoryBar : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public int activeSlotIndex;
    private bool initialized = false;

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
            if (item != null)
            {
                slotViews[slotIndex].SetIcon(item.icon);
            }
            else
            {
                slotViews[slotIndex].SetIcon(null);
            }


        }
        activeSlotIndex = InventoryManager.GetActiveSlotIndex();
        UpdateHighlightForAllSlots(activeSlotIndex);
        initialized = true;
    }





    private void HandleActiveSlotChanged(int newSlotIndex)
    {
        Debug.Log("HandleActiveSlotChanged called with index: " + newSlotIndex);
        UpdateHighlightForAllSlots(newSlotIndex);

    }

    private void HandleItemInSlotChanged(int slotIndex, ItemTemplate itemID)
    {
        if(itemID != null)
        {
            slotViews[slotIndex].SetIcon(itemID.icon);
        }
        else
        {
            slotViews[slotIndex].SetIcon(null);
        }

    }

    private void UpdateHighlightForAllSlots(int slotIndex)
    {
        Debug.Log("Updating highlight for slot index: " + slotIndex);
        for (int i = 0; i < slotViews.Count; i++)
        {
            Debug.Log("Setting highlight for slot " + i + ": " + (i == slotIndex));
            slotViews[i].SetHighlighted(i == slotIndex);
        }
    }

    public void RefreshUI()
    {
        for(int slotIndex = 0; slotIndex < slotViews.Count; slotIndex++)
        {
            ItemTemplate item = InventoryManager.GetItemInSlot(slotIndex);
            slotViews[slotIndex].SetIcon(item.icon);
        }
        activeSlotIndex = InventoryManager.GetActiveSlotIndex();
        UpdateHighlightForAllSlots(activeSlotIndex);
    }

}

