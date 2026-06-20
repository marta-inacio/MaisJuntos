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

    //tempo powerUpseDowns
    private float tempoExtra = 0f;

    private bool stopTimer;
    private float startTime;

    public ControlarNivel controlarNivel;

    //slider pisca perto do fim
    public Image sliderFill;
    private bool entreiTerminar;

    private Coroutine rotinaTempo;

    void Start()
    {
        stopTimer = false;
        startTime = Time.time;

        slider.maxValue = gameTime;
        slider.value = gameTime;

        entreiTerminar = false;
    }

    void Update()
    {
    

        if (!SceneManager.GetSceneByName("JogoNivel1").isLoaded) return;
        if (stopTimer) return;

        float time = gameTime + tempoExtra - (Time.time - startTime);

        if (time <= 0)
        {
            controlarNivel.PerderJogo();
            time = 0;
            stopTimer = true;
        }

        //a 15 segundos pisca 
        if (time < 15 && !entreiTerminar)
        {
            entreiTerminar = true;
            rotinaTempo = StartCoroutine(TerminarTempo());
        }

        if (time >= 15 && entreiTerminar)
        {
            entreiTerminar = false;

            if (rotinaTempo != null)
            {
                StopCoroutine(rotinaTempo);
                rotinaTempo = null;
            }

            sliderFill.color = Color.white;
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        slider.value = time;
    }

    //public void Pausa()
    //{
    //    stopTimer = true;
    //}

    //public void Retomar()
    //{
    //    stopTimer = false;
    //    startTime = Time.time - (gameTime - slider.value);
    //}

    public void GanhaPerdeTempo(float tempoSegundos)
    {
        tempoExtra += tempoSegundos;

        entreiTerminar = false;

        if (rotinaTempo != null)
        {
            StopCoroutine(rotinaTempo);
            rotinaTempo = null;
        }

    }

    IEnumerator TerminarTempo()
    {
        while (!stopTimer)
        {
            sliderFill.color = Color.red;
            yield return new WaitForSeconds(1f);

            sliderFill.color = Color.white;
            yield return new WaitForSeconds(1f);

        }
    }
}
