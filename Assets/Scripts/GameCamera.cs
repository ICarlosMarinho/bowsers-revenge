using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D cameraCollider;
    private Cinemachine.CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    public float leftLimit;

    [SerializeField]
    public float rightLimit;

    [SerializeField]
    public float topLimit;

    [SerializeField]
    public float bottomLimit;

    void Start()
    {
        virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        cameraCollider = GetComponent<BoxCollider2D>();

        cameraCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.x <= leftLimit) {

            cameraCollider.enabled = true;
            virtualCamera.LookAt = null;
            virtualCamera.Follow = null;
        }

        FixCameraPosition();
    }

    private void FixCameraPosition() {

        Camera.main.transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    void OnDrawGizmos() {

        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
    }
}