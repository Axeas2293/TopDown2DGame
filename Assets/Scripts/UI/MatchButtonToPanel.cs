using UnityEngine;

public class MatchButtonToPanel : MonoBehaviour
{

    [SerializeField] public GameObject matchingContentPanel;
    [SerializeField] public TabManager _tabManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _tabManager.ShowTab(matchingContentPanel);
    }
}
