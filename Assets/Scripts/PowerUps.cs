using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public string nome;
    public Sprite imagem;
    public string descricao;

    public ConfigPopUp popUp;
    public Vidas vidas;
    public Timer tempo;
    public Player Jogador;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("entrei no trigger");
        if (other.CompareTag("Player"))
        {
            popUp.Show(nome, imagem, descricao, 0.5f);

            PlayPowerUp(nome);

            gameObject.SetActive(false);
        }
    }

    public void PlayPowerUp(string nome){

        switch (nome)
        {
            case "Vida":
                vidas.GanharVida();
                break;

            case "Velocidade":
                Jogador.AlteraVelocidade(15f, 2f);
                break;

            case "Caveira":
                Jogador.AlteraVelocidade(15f, 0.5f);
                break;

            case "Tempo":
                tempo.GanhaPerdeTempo(15f);
                break;

            case "NaoAjudar":
                tempo.GanhaPerdeTempo(-15f);
                break;

            case "Pano":
                Jogador.AlteraVelocidade(5f, 0f);
                break;

            case "Desenho":
                tempo.GanhaPerdeTempo(20f);
                break;

        }
    }

}
