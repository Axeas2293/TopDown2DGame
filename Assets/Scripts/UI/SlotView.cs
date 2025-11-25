using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image icon;
    [SerializeField] GameObject highLightObject;
    public Color highlightColor;
    public Color normalColor;
    bool isActive;



    public void SetIcon(Sprite sprite)
    {
        if(sprite != null)
        {
            icon.sprite = sprite;
        }
        else
        {
            icon.sprite = null;
        }
            icon.enabled = sprite != null;
    }

    public void SetHighlighted(bool isActive)
    {
        Debug.Log("SlotView: SetHighlighted called with" + isActive);
        if (isActive)
        {
            Debug.Log("SlotView: SetHighlighted true");
            highLightObject.SetActive(true);
        }
        else
        {  
            highLightObject.SetActive(false);
        }

    }
}
