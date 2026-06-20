using UnityEngine;

public class portaHospital : MonoBehaviour
{
    public GameObject botao;

    private void Start()
    {
        if (botao != null)
            botao.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (botao != null)
            botao.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (botao != null)
            botao.SetActive(false);
    }
}