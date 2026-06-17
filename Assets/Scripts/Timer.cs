using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public TMP_Text timerText;
    public float gameTime;

    private bool stopTimer;
    private float startTime;

    void Start()
    {
        stopTimer = false;
        startTime = Time.time;

        slider.maxValue = gameTime;
        slider.value = gameTime;
    }

    void Update()
    {
        if (!SceneManager.GetSceneByName("JogoNivel1").isLoaded) return;
        if (stopTimer) return;

        float time = gameTime - (Time.time - startTime);

        if (time <= 0)
        {
            time = 0;
            stopTimer = true;
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        slider.value = time;
    }

    public void Pausa()
    {
        stopTimer = true;
    }

    public void Retomar()
    {
        stopTimer = false;
        startTime = Time.time - (gameTime - slider.value);
    }
}
