using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }

    private bool isLoading;
    public string nextSceneName;
    public string spawnPointName;
    public GameObject player;
    private string spawnPointID;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestSceneTransition(string sceneName, string spawnID)
    {
        if (isLoading)
            return;

        nextSceneName = sceneName;
        spawnPointID = spawnID;
        StartCoroutine(LoadSceneAsync());
    }

    public IEnumerator LoadSceneAsync() 
    {
        isLoading = true;
        yield return SceneManager.LoadSceneAsync(nextSceneName);
        PositionPlayerOnSpawn(spawnPointID);
        isLoading = false;
    }

    void PositionPlayerOnSpawn(string spawnID)
    {
        //GameObject spawnPoint = GameObject.Find(spawnID);

        if(player == null)
        {
            var found = GameObject.FindWithTag("Player");
            if(found != null)
            {
                player = found;
            }
            else
                Debug.LogWarning("Player not found ");
        }
        var spawnPoint = FindSpawnPointByID(spawnID);

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene t_scene, LoadSceneMode t_mode)
    {
        // Adjust Camera
        //
    }

    private SpawnPoint FindSpawnPointByID(string id)
    {
        var spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();

        foreach (var sp in spawnPoints)
        {
            if (sp.spawnID == id)
                return sp;
        }

        Debug.LogWarning("SpawnPoint with ID " + id + " not found.");
        return null;
    }

}

