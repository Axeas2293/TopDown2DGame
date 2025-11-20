using UnityEngine;

[CreateAssetMenu(fileName = "ItemTemplate", menuName = "ItemTemplate", order = 1)]
public class ItemTemplate : ScriptableObject
{
    public string displayedName;
    public Sprite icon;
    public string nameID;
    public string description;
    public int maxStackSize;
    public enum ItemType
    {
        Consumable,
        Equipment,
        Quest,
        Miscellaneous
    }


}
