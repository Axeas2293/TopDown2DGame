using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Manager : MonoBehaviour

    
{
    public static UI_Manager Instance { get; private set; }

    [SerializeField] private GameObject UIRootPrefab;

    private GameObject uiRootInstance;
    private UI_PanelReference panels;

    public MenuInputActions _menuInputActions;
    private bool isOpen;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        isOpen = false;


        uiRootInstance = Instantiate(UIRootPrefab);
        DontDestroyOnLoad(uiRootInstance);

        panels = uiRootInstance.GetComponentInChildren<UI_PanelReference>();

        if (panels.UI_Panel_Menu != null)
            panels.UI_Panel_Menu.SetActive(false);



    }


    private void OnEnable()
    {
        InputService.Instance.OnMenuToggle += HandleMenuToggle;
    }

    private void OnDisable()
    {
        if(InputService.Instance != null)
        {
            InputService.Instance.OnMenuToggle -= HandleMenuToggle;
        }
    }




    private void HandleMenuToggle()
    {
        isOpen = !isOpen;
        panels.UI_Panel_Menu.SetActive(isOpen);

        if (isOpen)
        {

            InputService.Instance.EnableUIControls();
        }
        else
        {
            InputService.Instance.EnablePlayerControls();
        }
    }

    public void Initialize(InventoryManager inventoryManager)
    {
        var inventoryBar = uiRootInstance.GetComponentInChildren<InventoryBar>();
        if (inventoryBar != null)
            inventoryBar.Initialize(inventoryManager);   
    }
}
