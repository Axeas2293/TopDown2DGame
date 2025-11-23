using UnityEngine;

public interface IItemUseHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnItemUse(PlayerInteract player, ItemTemplate itemUsed, Vector2 mousePosition);
}
