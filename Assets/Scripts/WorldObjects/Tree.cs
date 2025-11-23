using UnityEngine;

public class Tree : MonoBehaviour, IItemUseHandler
{
    int maxHealthPoints = 3;
       public void OnItemUse(PlayerInteract player, ItemTemplate item, Vector2 mousePosition)
    {
        if (item.useType == ItemTemplate.UseType.Tool_Axe)
        {
            ChopDownTree(player, item);
        }
    }
    private void ChopDownTree(PlayerInteract player, ItemTemplate item)
    {
        // Logic to chop down the tree
        maxHealthPoints -= 1;
        if (maxHealthPoints <= 0)
        {
            Destroy(gameObject);
        }
            
    }
}

