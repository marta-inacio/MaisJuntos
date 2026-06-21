using UnityEngine;
using UnityEngine.InputSystem;

public class Objetos : MonoBehaviour
{
    [Header("Transporte")]
    public float distanciaX = 5f;
    public string tagPlayer = "Player";
    public string tagMenina;

    [Header("Troca da Menina")]
    public GameObject meninaAtual;
    public GameObject meninaFeliz;

    [Header("Objeto após entrega")]
    public bool destruirObjetoDepoisDeEntregar = true;

    private Transform player;
    private bool aSerTransportado = false;

    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag(tagPlayer);

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player não encontrado. Confirma se o Player tem a tag Player.");
        }

        if (meninaFeliz != null)
        {
            meninaFeliz.SetActive(false);
        }
    }

    void Update()
    {
        if (aSerTransportado && player != null)
        {
            transform.position = new Vector3(
                player.position.x + distanciaX,
                player.position.y,
                transform.position.z
            );
        }

        if (CliqueOuToqueFeito(out Vector2 posEcra))
        {
            Vector2 posMundo = Camera.main.ScreenToWorldPoint(posEcra);

            RaycastHit2D hit = Physics2D.Raycast(posMundo, Vector2.zero);

            if (hit.collider == null)
                return;

            if (!aSerTransportado)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Apanhar();
                }
            }
            else
            {
                if (hit.collider.CompareTag(tagMenina))
                {
                    EntregarNaMenina();
                }
            }
        }
    }

    private bool CliqueOuToqueFeito(out Vector2 posEcra)
    {
        posEcra = Vector2.zero;

        // PC e Android
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            posEcra = Pointer.current.position.ReadValue();
            return true;
        }

        return false;
    }

    private void Apanhar()
    {

        this.GetComponent<AudioSource>().Play();
        if (player == null)
            return;

        aSerTransportado = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        // tiraa menina triste
        if (meninaAtual != null)
        {
            meninaAtual.SetActive(false);
        }

        if (meninaFeliz != null)
        {
            meninaFeliz.SetActive(true);

            NpcDialogueHospital dialogoFeliz =
                meninaFeliz.GetComponent<NpcDialogueHospital>();

            if (dialogoFeliz != null)
            {
                dialogoFeliz.objetoEntregue = false;
            }
        }

        Debug.Log("Objeto apanhado.");
    }

    private void EntregarNaMenina()
    {
        aSerTransportado = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (col != null)
        {
            col.enabled = false;
        }

        // A menina feliz já está ativa desde que o pato foi apanhado
        if (meninaFeliz != null)
        {
            NpcDialogueHospital dialogoFeliz =
                meninaFeliz.GetComponent<NpcDialogueHospital>();

            if (dialogoFeliz != null)
            {
                dialogoFeliz.objetoEntregue = true;

                InfoJogo.isDialogueActive = false;
                InfoJogo.activeDialogue = null;
                InfoJogo.activeDialogue2 = null;

                dialogoFeliz.StartDialogue();
            }
            else
            {
                Debug.LogWarning("O GameObject meninaFeliz não tem NpcDialogueHospital.");
            }
        }
        else
        {
            Debug.LogWarning("meninaFeliz não foi atribuída no Inspector.");
        }

        Debug.Log("Objeto entregue à menina.");

        if (destruirObjetoDepoisDeEntregar)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}