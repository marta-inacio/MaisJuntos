using UnityEngine;
using UnityEngine.InputSystem;
public class NPCMundo : MonoBehaviour
{
    public GameObject npc;
    public float Velocidade;

    private Animator anim;
    private Rigidbody2D rb;

    public NpcDialogue npcDialogue;

    public float distancia;
    private Vector2 pontoInicial;

    private int direcao = 1;
    private bool parar = false;

    public string idle;
    public string esq;
    public string dir;

    void Start()
    {
        anim = npc.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pontoInicial = transform.position;
    }

    void Update()
    {
        if (InfoJogo.isDialogueActive)
            return;

        if (!parar)
            return;

        if (CliqueOuToqueNoNPC())
        {
            this.GetComponent<AudioSource>().Play();
            AbrirDialogo();
        }
    }

    private bool CliqueOuToqueNoNPC()
    {
        Vector2 posicaoInput;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            posicaoInput = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(posicaoInput, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
                return true;
        }

        if (Touchscreen.current != null)
        {
            var toque = Touchscreen.current.primaryTouch;

            if (toque.press.wasPressedThisFrame)
            {
                posicaoInput = Camera.main.ScreenToWorldPoint(toque.position.ReadValue());

                RaycastHit2D hit = Physics2D.Raycast(posicaoInput, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                    return true;
            }
        }

        return false;
    }

    void FixedUpdate()
    {
        if (InfoJogo.isDialogueActive)
        {
            rb.linearVelocity = Vector2.zero;
            anim.Play(idle);
            return;
        }

        if (parar)
        {
            rb.linearVelocity = Vector2.zero;
            anim.Play(idle);
            return;
        }

        AndarLoop();
    }

    void AndarLoop()
    {
        rb.linearVelocity = new Vector2(direcao * Velocidade, 0);

        if (direcao > 0)
            anim.Play(dir);
        else
            anim.Play(esq);

        float distanciaAtual = transform.position.x - pontoInicial.x;

        if (distanciaAtual >= distancia)
            direcao = -1;

        if (distanciaAtual <= -distancia)
            direcao = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            parar = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            parar = false;
    }

    void AbrirDialogo()
    {
        npcDialogue?.StartDialogue();
    }
}
