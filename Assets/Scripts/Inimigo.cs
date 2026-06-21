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
    bool ModoPrincipal = true;

    //colidir e parar durante5 segundos
    bool colidiu = false;
    private Vector3 posicaoColisao;


    public Vidas vidas;


    void Start()
    {
        Jogador = GameObject.Find("Player");

        // Encontra o SpriteRenderer dentro do Player
        spritePlayer = Jogador.GetComponentInChildren<SpriteRenderer>();

        vidas = FindFirstObjectByType<Vidas>();

        PosAlvo = Jogador.transform.position;
    }

    void Update()
    {

        if (InfoJogo.isDialogueActive)
            return;


        if (colidiu)
        {
            transform.position = posicaoColisao;
            return;
        }


        if (ModoPrincipal)
        {
            PosAlvo = Jogador.transform.position;
        }

        //método c
        transform.right = (PosAlvo - transform.position).normalized;
        this.transform.position += this.transform.right * Velocidade * Time.deltaTime;

        Debug.DrawLine(this.transform.position, PosAlvo);


        if ((PosAlvo - this.transform.position).magnitude < 0.1f)
        {
            PosAlvo = Jogador.transform.position;
            ModoPrincipal = true;
        }

        if (ModoPrincipal)
        {
            PosAlvo = Jogador.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Jogador)
        {
            //print("muda");
            print(this.name + "colidiu com o" + collision.gameObject.name);

            StartCoroutine(MudarDeCorDano());
            vidas.PerderVida();

            StartCoroutine(PausaDepoisDeBater());
        }
        else { 
            PosAlvo = this.transform.position + transform.up * 2;
            ModoPrincipal = false;
        }
    }

    //ficar a vermelho na colisão
    IEnumerator MudarDeCorDano()
    {
        spritePlayer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spritePlayer.color = Color.white;
    }

    //parar durante uns segundos antes de ir atrás tirar mais vida
    IEnumerator PausaDepoisDeBater()
    {
        //guardar pos colisaõ
        colidiu = true;
        posicaoColisao = transform.position;

        yield return new WaitForSeconds(5f);

        colidiu = false;
        ModoPrincipal = true;
        PosAlvo = Jogador.transform.position;
    }
}