using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCount : MonoBehaviour
{
    private TMP_Text lifeCountText;
    private int localLifeCount = Player.lifeCount;
    // Start is called before the first frame update
    void Start()
    {
        lifeCountText = GetComponent<TMP_Text>();
        lifeCountText.text = $"x {Player.lifeCount}";
    }

    // Update is called once per frame
    void Update()
    {
        if (localLifeCount != Player.lifeCount)
        {
            lifeCountText.text = $"x {Player.lifeCount}";
            localLifeCount = Player.lifeCount;
        }
    }
}
