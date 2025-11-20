using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemTemplate> items;

    private Dictionary<string, ItemTemplate> lookup = new Dictionary<string, ItemTemplate>();

    public ItemTemplate GetItemByID(string id)
    {
        if (lookup.Count == 0)
        {
            foreach (var item in items)
                lookup[item.nameID] = item;
        }
        return lookup.ContainsKey(id) ? lookup[id] : null;
    }
}
