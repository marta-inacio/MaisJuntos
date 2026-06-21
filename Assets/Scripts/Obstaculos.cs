using UnityEngine;


public class Obstaculos : MonoBehaviour
{
    //variavel publica
    public GameObject Jogador;
    public SpriteRenderer spritePlayer;

    public Vidas vidas;

    private void Start()
    {
        Jogador = GameObject.Find("Player");

        // Encontra o SpriteRenderer dentro do Player
        spritePlayer = Jogador.GetComponentInChildren<SpriteRenderer>();

        vidas = FindFirstObjectByType<Vidas>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Jogador)
        {
            this.GetComponent<AudioSource>().Play();
            Player player = Jogador.GetComponent<Player>();

            if (player.salto)
                return;

            player.Cair();

            //print(this.name + "colidiu com o" + other.gameObject.name);

            vidas.PerderVida();
        }
    }
}
