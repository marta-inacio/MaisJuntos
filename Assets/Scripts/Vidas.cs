using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    public GameObject vida5;

    public GameObject vidaVazia1;
    public GameObject vidaVazia2;
    public GameObject vidaVazia3;

    public ControlarNivel controlarNivel;

    public GameObject popUpMaximoVida;
    public GameObject popUpPerderVida;

    private int vidas = 3;

    void Start()
    {
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }

    
    public void PerderVida()
    {
        Debug.Log("perdi vida");
        if (vidas > 0)
        {
            vidas--;
            //pop-up para maximo vidas
            StartCoroutine(MostrarPopUp(popUpPerderVida));
        }

        switch (vidas)
        {
            case 0:
                vida1.SetActive(false);
                vidaVazia1.SetActive(true);

                controlarNivel.PerderJogo();
                break;

            case 1:
                vida2.SetActive(false);
                vidaVazia2.SetActive(true);
                break;

            case 2:
                vida3.SetActive(false);
                vidaVazia3.SetActive(true);
                break;

            case 3:
                vida4.SetActive(false);
                break;

            case 4:
                vida5.SetActive(false);
                break;

        }
    }

    public void GanharVida()
    {
        if (vidas < 5)
        {
            vidas++;
        }
        else
        {
            //pop-up para maximo vidas
            StartCoroutine(MostrarPopUp(popUpMaximoVida));
        }

        switch (vidas)
        {
            case 2:
                vida2.SetActive(true);
                vidaVazia2.SetActive(false);
                break;

            case 3:
                vida3.SetActive(true);
                vidaVazia3.SetActive(false);
                break;

            case 4:
                vida4.SetActive(true);
                break;

            case 5:
                vida5.SetActive(true);
                break;

        }
    }

    IEnumerator MostrarPopUp(GameObject popUp)
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(1f);
        popUp.SetActive(false);
    }

}
