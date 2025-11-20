using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(InitializeUI());
    }

    private System.Collections.IEnumerator InitializeUI()
    {
        // WICHTIG: einen Frame warten, damit UI_Manager seine Prefabs instanziert hat!
        yield return null;

        if (UI_Manager.Instance == null)
        {
            Debug.LogError("UI_Manager existiert nicht in der Szene!");
            yield break;
        }

        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager existiert nicht in der Szene!");
            yield break;
        }

        UI_Manager.Instance.Initialize(InventoryManager.Instance);
    }
}
