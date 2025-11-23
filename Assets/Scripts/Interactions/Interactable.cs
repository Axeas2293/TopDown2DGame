using UnityEngine;

public interface IContextInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnContextInteract(PlayerInteract player, Vector2 mousePosition);
}
