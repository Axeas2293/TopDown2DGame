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

        _menuInputActions = new MenuInputActions();

        uiRootInstance = Instantiate(UIRootPrefab);
        DontDestroyOnLoad(uiRootInstance);

        panels = uiRootInstance.GetComponentInChildren<UI_PanelReference>();

        if (panels.UI_Panel_Menu != null)
            panels.UI_Panel_Menu.SetActive(false);



    }


    private void OnEnable()
    {
        _menuInputActions.UI_Controls.Enable();
        _menuInputActions.UI_Controls.Open_Menu.performed += OnOpenMenu;
    }

    private void OnDisable()
    {
        if (_menuInputActions != null)
        {
            _menuInputActions.UI_Controls.Disable();
            _menuInputActions.UI_Controls.Open_Menu.performed -= OnOpenMenu;
        }
    }


    private void OnOpenMenu(InputAction.CallbackContext ctx)
    {
        isOpen = !isOpen;
        panels.UI_Panel_Menu.SetActive(isOpen);

        if (isOpen)
        {

            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Initialize(InventoryManager inventoryManager)
    {
        var inventoryBar = uiRootInstance.GetComponentInChildren<InventoryBar>();
        if (inventoryBar != null)
            inventoryBar.Initialize(inventoryManager);   
    }
}
