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
        //if (PlayerPrefs.GetInt("PrimeiraVez", 1) == 1)
        //{
        //    // Primeira execução
        //    menuInicial.SetActive(true);
        //    menuPrincipal.SetActive(false);

        //    PlayerPrefs.SetInt("PrimeiraVez", 0);
        //    PlayerPrefs.Save();
        //}
        //else
        //{
        //    // Já abriu o jogo anteriormente
        //    menuInicial.SetActive(false);
        //    menuPrincipal.SetActive(true);
        //}

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
        SceneManager.LoadScene("Jogo2");
    }

    public void FechaMenu()
    {
        SceneManager.UnloadSceneAsync("Menu");
        Time.timeScale = 1f;
    }
}
