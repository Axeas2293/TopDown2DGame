using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image icon;
    [SerializeField] UnityEngine.UI.Image backGroundImage;
    public Color highlightColor;
    public Color normalColor;
    bool isActive;



    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
        icon.enabled = sprite != null;
    }

    public void SetHighlighted(bool isActive)
    {
        if (isActive)
        {
            backGroundImage.color = highlightColor;
        }
        else
        {
            backGroundImage.color = normalColor;
        }
    }
}
