using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlarNivel : MonoBehaviour
{
    public GameObject popUpPerder;
    public GameObject popUpGanhar;

    private void Start()
    {
        Time.timeScale = 0f;
    }
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Jogo");
    }

    public void VencerJogo()
    {
        PausarJogo();
        InfoJogo.missao1 = 100;
        InfoJogo.voluntariado = true;
        popUpGanhar.GetComponent<AudioSource>().Play();
        AbrirPopUp(popUpGanhar);
    }


    public void PerderJogo()
    {
        PausarJogo();
        popUpPerder.GetComponent<AudioSource>().Play();
        AbrirPopUp(popUpPerder);
    }

    public void AbrirPopUp(GameObject popUp)
    {
        popUp.SetActive(true);
    }
}
