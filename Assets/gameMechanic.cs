using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMechanic : MonoBehaviour
{
    public double buckets;
    public double bPS;

    public Slider timerSlider;

    public Text currentTimeText;
    public Text bucketsText;
    public Text bPSText;

    public float currentTime;
    public float maxTime;

    public bool timerActive = false;

    public void Start()
    {
        buckets = 0;
        bPS = 1;
        maxTime = 3;
        currentTime = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = currentTime;
    }

    public void click()
    {
        timerSlider.gameObject.SetActive(true);
        timerActive = true;
    }

    public void Update()
    {
        bucketsText.text = buckets + " Buckets";
        bPSText.text = bPS + " PerClick";

        float time = currentTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            timerSlider.value = currentTime;
            currentTimeText.text = textTime;
        }


        if (currentTime <= 0)
        {
            timerActive = false;
            timerSlider.gameObject.SetActive(false);
            currentTime = maxTime;
            buckets += bPS;
        }
    }

}
