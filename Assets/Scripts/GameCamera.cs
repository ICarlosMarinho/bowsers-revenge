using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private Cinemachine.CinemachineVirtualCamera mainCamera;
    public Transform bossAreaCenter;

    void Start()
    {
        mainCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.x <= bossAreaCenter.transform.position.x) {

            mainCamera.Follow = null;
            mainCamera.LookAt = null;
        }
    }
}