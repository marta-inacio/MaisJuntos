using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AbreMenus : MonoBehaviour
{
    public void AbreMenuPrincipal()
    {
        InfoJogo.menu = 1;
        //Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbrirColecao()
    {
        InfoJogo.menu = 2;
        //Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbrePaises()
    {
        InfoJogo.menu = 3;
        //Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreVoluntariado()
    {
        InfoJogo.menu = 4;
        //Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreDefinicoes()
    {
        InfoJogo.menu = 5;
        //Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreHospital()
    {
        SceneManager.LoadScene("JogoNivel1");
    }

    public void FechaHospital()
    {
        SceneManager.UnloadSceneAsync("JogoNivel1");
        Time.timeScale = 1f;
    }
}

