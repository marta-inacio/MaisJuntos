using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlarNivel : MonoBehaviour
{
    public GameObject popUpPerder;
    public GameObject popUpGanhar;
    public void PausarJogo()
    {
        Time.timeScale = 0f;
    }

    public void RetomarJogo()
    {
        Time.timeScale = 1f;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("JogoNivel1");
    }

    public void SairJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void VencerJogo()
    {      
        AbrirPopUp(popUpGanhar);
    }


    public void PerderJogo()
    {
        PausarJogo();
        AbrirPopUp(popUpPerder);
    }

    public void AbrirPopUp(GameObject popUp)
    {
        popUp.SetActive(true);
    }
}
