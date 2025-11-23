using UnityEngine;

[CreateAssetMenu(fileName = "ItemTemplate", menuName = "ItemTemplate", order = 1)]
public class ItemTemplate : ScriptableObject
{
    public string displayedName;
    public Sprite icon;
    public string nameID;
    public string description;
    public int maxStackSize;

    public ItemType itemType;
    public UseType useType;
    public enum ItemType
    {
        Consumable,
        Equipment,
        Quest,
        Miscellaneous
    }

    public enum UseType
    {
        None,
        Tool_Axe,
        Tool_Pickaxe,
        Tool_Hoe,
        Tool_WateringCan,
        Seed,
        Consumable,
        PlaceableObject,
    }

}
