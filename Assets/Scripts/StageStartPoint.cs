using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStartPoint : MonoBehaviour
{
    public GameObject playerPrefab;
    private bool respawnSched = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlayerDead() && !respawnSched)
        {

            SpawnPlayer();

            respawnSched = true;
        }

        if (!IsPlayerDead()) respawnSched = false;
    }

    void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation);
    }

    bool IsPlayerDead()
    {
        return GameObject.FindGameObjectWithTag("Player") == null;
    }
}
