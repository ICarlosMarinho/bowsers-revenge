using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D cameraCollider;
    private Cinemachine.CinemachineVirtualCamera mainCamera;
    public Transform bossAreaCenter;
     

    void Start()
    {
        mainCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        cameraCollider = GetComponent<BoxCollider2D>();

        cameraCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.x <= bossAreaCenter.transform.position.x) {

            cameraCollider.enabled = true;
    
            mainCamera.Follow = null;
            mainCamera.LookAt = null;
        }
    }
}