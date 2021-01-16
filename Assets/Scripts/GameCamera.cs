using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private Cinemachine.CinemachineVirtualCamera mainCamera;
    private GameObject player;
    void Start()
    {
        mainCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {

            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {

            if (mainCamera.Follow == null || mainCamera.LookAt == null)
            {

                mainCamera.Follow = player.transform;
                mainCamera.LookAt = player.transform;
            }
        }
    }
}