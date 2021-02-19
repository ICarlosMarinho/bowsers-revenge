using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudLifes : MonoBehaviour
{
    private TMP_Text lifeCountText;
    // Start is called before the first frame update
    void Start()
    {
        lifeCountText = GetComponent<TMP_Text>();
        lifeCountText.text = $"x {PlayerPrefs.GetInt("lifeCount")}";
    }
}
