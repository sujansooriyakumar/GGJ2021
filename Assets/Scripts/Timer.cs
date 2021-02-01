using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private Image bar;
    GameController gc;
    public bool ticking;
    public float time;

    private void Start()
    {
        bar = GetComponent<Image>();
        gc = FindObjectOfType<GameController>();
        ticking = true;
        time = gc.totalTime;
        bar.fillAmount = 1.0f;
        
    }

    private void Update()
    {
        if (ticking)
        {
            time -= Time.deltaTime;
        }
        bar.fillAmount = time / gc.totalTime;
        if(time <= 0)
        {
            time = gc.totalTime;
            ticking = false;
            FindObjectOfType<DogController>().Death();
        }
    }
}
