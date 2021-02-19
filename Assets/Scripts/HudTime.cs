using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudTime : MonoBehaviour
{
    private TMP_Text time;
    public static int GameTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<TMP_Text>();
    }

    void FixedUpdate () {
        GameTime = (int) Mathf.Floor(Time.timeSinceLevelLoad);
    }
    // Update is called once per frame
    void Update()
    {
       if (Time.timeScale > 0) time.text = $"{Mathf.Floor((GameTime / 60)).ToString("00")}:{(GameTime % 60).ToString("00")}";
    }
}
