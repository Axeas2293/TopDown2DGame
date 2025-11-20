using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string nextSceneName;
    public string spawnID;

    private bool hasTriggered = false;



    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (hasTriggered)
            return;

        if (SceneTransitionManager.Instance == null)
        {
            Debug.LogError("No SceneTransitionManager found in scene!");
            return;
        }

        hasTriggered = true;

        SceneTransitionManager.Instance.RequestSceneTransition(nextSceneName, spawnID);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
