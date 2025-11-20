using Unity.Cinemachine;
using UnityEngine;


public class FollowInitiliazer : MonoBehaviour
{
    private GameObject Player;
    public CinemachineCamera _cinemachineCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_cinemachineCamera == null)
        {
            TryAssignPlayer();
        }
    }

    private void OnEnable()
    {
        TryAssignPlayer();
    }

    private void TryAssignPlayer()
    {
        if(PlayerPersistent.Instance != null)
        {
            _cinemachineCamera.Follow = PlayerPersistent.Instance.transform;
        }
    }
}
