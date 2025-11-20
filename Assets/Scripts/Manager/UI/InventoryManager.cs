using UnityEngine;
using System;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private int slotCount = 8;

    [Header("References")]
    public ItemDatabase itemDatabase;

    // stores ONLY item IDs
    private string[] slotItemIDs;

    private int activeSlotIndex = 0;

    // EVENTS
    public event Action<int> OnActiveSlotChanged;
    public event Action<int, ItemTemplate> OnItemInSlotChanged;

    private void Awake()
    {
        // Singleton Setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize slot array
        slotItemIDs = new string[slotCount];
        for (int i = 0; i < slotCount; i++)
            slotItemIDs[i] = null;
    }

    // -------- ACTIVE SLOT ----------

    public void SetActiveSlot(int slotIndex)
    {
        if (slotIndex == activeSlotIndex)
            return;

        if (!IsValidSlot(slotIndex))
        {
            Debug.LogWarning($"Invalid active slot index: {slotIndex}");
            return;
        }

        activeSlotIndex = slotIndex;
        OnActiveSlotChanged?.Invoke(activeSlotIndex);
    }

    public int GetActiveSlotIndex() => activeSlotIndex;

    // -------- ITEM HANDLING ----------

    public void SetItemInSlot(int slotIndex, string itemID)
    {
        if (!IsValidSlot(slotIndex))
        {
            Debug.LogWarning($"Invalid slot index: {slotIndex}");
            return;
        }

        slotItemIDs[slotIndex] = itemID;

        var item = itemDatabase.GetItemByID(itemID);
        OnItemInSlotChanged?.Invoke(slotIndex, item);
    }

    public ItemTemplate GetItemInSlot(int slotIndex)
    {
        if (!IsValidSlot(slotIndex))
        {
            Debug.LogWarning($"Invalid slot index: {slotIndex}");
            return null;
        }

        var id = slotItemIDs[slotIndex];
        return itemDatabase.GetItemByID(id);
    }

    // -------- INTERNAL ----------

    private bool IsValidSlot(int index)
    {
        return index >= 0 && index < slotItemIDs.Length;
    }
}