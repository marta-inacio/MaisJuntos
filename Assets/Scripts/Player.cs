using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using PinePie.SimpleJoystick;

public class Player : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade;
    public JoystickController joystick;

    //mexer tudo junto
    private Animator anim;
    private Rigidbody2D rb;

    //salto
    private bool salto;

    void Start()
    {
        anim = Jogador.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!salto)
        {
            //joystick dir
            Vector3 movimento = joystick.InputDirection;

            // Movimento com física (acompanha o Rigidbody) by Chat
            rb.linearVelocity = new Vector2(movimento.x, movimento.y) * Velocidade;
        
            //pôr o bicho a mexer
            AndarComAnimacao(movimento);
        }
    }

    //pato a andar com animações
    void AndarComAnimacao(Vector3 dir) { 

        if( dir == Vector3.zero) {
            anim.Play("idle");

        }else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            anim.Play(dir.x < 0 ? "esq" : "dir");
        }
        else
        {
            anim.Play(dir.y > 0 ? "cima" : "baixo");
        }
    }


    //chamar o clique do bota aqui que tem d ser courotine pq while
    public void cliqueSalto()
    {
        StartCoroutine(Saltar());
    }


    //saltar
    IEnumerator Saltar()
    {
        salto = true;

        Vector3 dir = joystick.InputDirection;

        if (dir != Vector3.zero)
            dir.Normalize();

        // animação
        if (dir == Vector3.zero)
        {
            anim.Play("salto_cima");
        }
        else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            anim.Play(dir.x < 0 ? "salto_esq" : "salto_dir");
        }
        else
        {
            anim.Play(dir.y > 0 ? "salto_cima" : "salto_baixo");
        }

        //desacelerar animação para bater com salto
        anim.speed = 1f / 2f;

        // temposalto
        float duracaoSalto = 0f;

        Vector3 velocidade = dir * Velocidade;

        while (duracaoSalto < 2f)
        {
            duracaoSalto += Time.deltaTime;

            rb.linearVelocity = new Vector2(velocidade.x, velocidade.y) * 1.5f;

            yield return null;
        }

        //// parar no fim do salto
        //rb.linearVelocity = Vector2.zero;

        anim.speed = 1f;

        salto = false;
    }
   




}