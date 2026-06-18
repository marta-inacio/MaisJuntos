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

    void Start()
    {

        switch (InfoJogo.menu)
        {
            case 1:
                Debug.Log("Abriu Menu Principal");
                menuInicial.SetActive(false);
                menuPrincipal.SetActive(true);
                break;

            case 2:
                Debug.Log("Abriu coleção");
                menuInicial.SetActive(false);
                Colecao.SetActive(true);
                break;

            case 3:
                Debug.Log("Abriu paises");
                menuInicial.SetActive(false);
                Paises.SetActive(true);
                break;

            case 4:
                Debug.Log("Abriu voluntariado");
                menuInicial.SetActive(false);
                Voluntariado.SetActive(true);
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
            Debug.Log("enteiraai");
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
