using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    TextMeshProUGUI tm;
    GameController gc;


    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        tm = GetComponent<TextMeshProUGUI>();
        tm.text = "Level " + gc.level;
    }

    private void Update()
    {
        tm.text = "Level " + gc.level;
    }
}
