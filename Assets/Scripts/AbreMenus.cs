using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AbreMenus : MonoBehaviour
{
    //void Start()
    //{
    //    Scene menuScene = SceneManager.GetSceneByName("Menu");
    //}

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive); 
    }

    void UnloadMenu()
    {
        if (SceneManager.GetSceneByName("Menu").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Menu");
        }
        
    }
    public void AbreMenuPrincipal()
    {
        UnloadMenu();
        InfoJogo.menu = 1;
        LoadMenu();
    }

    public void AbrirColecao()
    {
        UnloadMenu();
        InfoJogo.menu = 2;
        LoadMenu();
    }

    public void AbrePaises()
    {
        UnloadMenu();
        InfoJogo.menu = 3;
        LoadMenu();
    }

    public void AbreVoluntariado()
    {
        UnloadMenu();
        InfoJogo.menu = 4;
        LoadMenu();
    }

    public void AbreDefinicoes()
    {
        UnloadMenu();
        InfoJogo.menu = 5;
        LoadMenu();
    }

    public void AbreHospital()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("JogoNivel1");
    }
}

