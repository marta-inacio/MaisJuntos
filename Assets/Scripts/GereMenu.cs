using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject menuPrincipal;
    public GameObject Colecao;
    public GameObject Paises;
    public GameObject Voluntariado;
    public GameObject Definicoes;
    public GameObject PopUpVazio;

    //foto voluntarido
    public RawImage foto;

    void Update()
    {

        switch (InfoJogo.menu)
        {
            case 1:
                Debug.Log("Abriu Menu Principal");
                menuInicial.SetActive(false);
                menuPrincipal.SetActive(true);
                break;

            case 2:
                menuInicial.SetActive(false);
                if (InfoJogo.nata || InfoJogo.calcada || InfoJogo.guitarra)
                {
                    Colecao.SetActive(true);
                }
                else
                {
                    PopUpVazio.SetActive(true);
                }
                break;

            case 3:
                Debug.Log("Abriu paises");
                menuInicial.SetActive(false);
                Paises.SetActive(true);
                break;

            case 4:
                Debug.Log("Abriu voluntariado");
                menuInicial.SetActive(false);

                if (InfoJogo.voluntariado)
                {
                    //Debug.Log("voluntariod" + InfoJogo.voluntariado);
                    if (InfoJogo.fotoCapturada != null)
                    {
                        foto.texture = InfoJogo.fotoCapturada;
                    }
                    Voluntariado.SetActive(true);
                }
                else
                {
                    //Debug.Log("vazio" + InfoJogo.voluntariado);
                    PopUpVazio.SetActive(true);
                }
                break;

            case 5:
                Debug.Log("Abriu Definicoes");
                menuInicial.SetActive(false);
                Definicoes.SetActive(true);
                break;
        }
    }


    public void Sai()
    {
        print("aplicação terminou!");
        Application.Quit();
    }

    public void AbreJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void FechaMenu()
    {
        SceneManager.UnloadSceneAsync("Menu");

        ControlarNivel timer = FindFirstObjectByType<ControlarNivel>();

        if (timer != null)
        {
            //Debug.Log("enteiraai");
            timer.RetomarJogo();
        }
    }

    //public void MusicaVolume(Slider MV)
    //{
    //    print("Volume da música:" + MV.value);
    //}

    //public void FXVolume(Slider FX)
    //{
    //    print("Volume FX:" + FX.value);
    //}

}
