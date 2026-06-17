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

    void Start()
    {
        anim = Jogador.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //joystick dir
        Vector3 movimento = joystick.InputDirection;

        // Movimento com física (acompanha o Rigidbody) by Chat
        rb.linearVelocity = new Vector2(movimento.x, movimento.y) * Velocidade;


        //pôr o bicho a mexer
        AndarComAnimacao(movimento);
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


}