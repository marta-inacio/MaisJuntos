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
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbrirColecao()
    {
        InfoJogo.menu = 2;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbrePaises()
    {
        InfoJogo.menu = 3;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreVoluntariado()
    {
        InfoJogo.menu = 4;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreDefinicoes()
    {
        InfoJogo.menu = 5;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void AbreHospital()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("JogoNivel1");
    }
}

