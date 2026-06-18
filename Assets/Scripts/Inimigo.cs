using System.Collections;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    //variavel publica
    public float Velocidade;
    public GameObject Jogador;
    public SpriteRenderer spritePlayer;
    public GameObject PerderVida;
    Vector3 PosAlvo;

    public Vidas vidas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jogador = GameObject.Find("Player");

        // Encontra o SpriteRenderer dentro do Player
        spritePlayer = Jogador.GetComponentInChildren<SpriteRenderer>();

        vidas = FindFirstObjectByType<Vidas>();
    }

    // Update is called once per frame
    void Update()
    {
        PosAlvo = Jogador.transform.position;
        // //método B move towards
        this.transform.position = Vector3.MoveTowards(this.transform.position, PosAlvo, Velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Jogador)
        {
            //print("muda");
            print(this.name + "colidiu com o" + collision.gameObject.name);

            StartCoroutine(MudarDeCorDano());
            vidas.PerderVida();

            //collision.gameObject.GetComponent<Animator>().Play("MudaCor");
            //this.GetComponent<AudioSource>().Play();
        }
    }

    //ficar a vermelho na colisão
    IEnumerator MudarDeCorDano()
    {
        spritePlayer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spritePlayer.color = Color.white;
    }
}