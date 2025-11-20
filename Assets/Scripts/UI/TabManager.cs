using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    private List<GameObject> _buttonTabs;
    private List<GameObject> _contentPanels;
    [SerializeField] public GameObject defaultContentPanel;
    private GameObject activeContentPanel;
    [SerializeField] public Transform tabButtonsContainer;
    [SerializeField] public Transform contentPanelContainer;


    private void Awake()
    {

    }
    void Start()
    {
        _buttonTabs = new List<GameObject>();
        _contentPanels = new List<GameObject>();
        GetButtonTabs();
        GetContentPanels();

        activeContentPanel = defaultContentPanel;

        foreach(GameObject contentPanel in _contentPanels)
        {
            contentPanel.SetActive(false);
        }
        defaultContentPanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetButtonTabs()
    {   
        foreach(Transform child in tabButtonsContainer)
        {
            _buttonTabs.Add(child.gameObject);
        }
    }

    void GetContentPanels()
    {
        foreach(Transform child in contentPanelContainer)
        {
            _contentPanels.Add(child.gameObject);
        }
    }

    public void ShowTab(GameObject t_matchingContentPanel)
    {
        foreach (GameObject contentPanel in _contentPanels)
        {
            contentPanel.SetActive(false);
        }
        t_matchingContentPanel.gameObject.SetActive(true);
        activeContentPanel = t_matchingContentPanel;
    }

    void OnTabClicked()
    {
        
    }
}
