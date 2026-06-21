using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class NpcDialogue : MonoBehaviour
{
    [Header("Diálogo NPC")]
    public string[] dialogueNpc;
    public GameObject dialoguePanelNpc;
    public TMP_Text dialogueTextNpc;
    public Sprite spriteNpc;

    [Header("Diálogo Player")]
    public string[] dialoguePlayer;
    public GameObject dialoguePanelPlayer;
    public TMP_Text dialogueTextPlayer;
    public Sprite spritePlayer;

    private int dialogueIndex = 0;
    private bool isNpcTurn = true;
    private bool dialogueDone = false;
    private bool isTyping = false;

    public bool readyToSpeak;

    private Coroutine typingCoroutine;

    [Header("Popup")]
    public string nome;
    public Sprite imagem;
    public string descricao;

    public ConfigPopUp popUp;

    void Start()
    {
        dialoguePanelNpc.SetActive(false);
        dialoguePanelPlayer.SetActive(false);
    }


    void Update()
    {
        if (!InfoJogo.isDialogueActive)
            return;

        if (InfoJogo.activeDialogue != this)
            return;

        if (CliqueOuToqueFeito())
        {
            if (isTyping)
            {
                SaltarAnimacao();
            }
            else
            {
                NextDialogue();
            }
        }
    }

    private bool CliqueOuToqueFeito()
    {
        // PC / rato
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            return true;
        }

        // Android / touch
        if (Touchscreen.current != null)
        {
            var toque = Touchscreen.current.primaryTouch;

            if (toque.press.wasPressedThisFrame)
            {
                return true;
            }
        }

        return false;
    }


    public void StartDialogue()
    {
        if (InfoJogo.isDialogueActive)
            return;

        dialogueIndex = 0;
        isNpcTurn = true;
        dialogueDone = false;

        InfoJogo.isDialogueActive = true;
        InfoJogo.activeDialogue = this;

        MostrarFalaAtual();
    }

    void SaltarAnimacao()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (isNpcTurn)
        {
            dialogueTextNpc.text = dialogueNpc[dialogueIndex];
        }
        else
        {
            dialogueTextPlayer.text = dialoguePlayer[dialogueIndex];
        }

        isTyping = false;
    }

    void NextDialogue()
    {
        dialogueIndex++;

        bool npcAcabou = dialogueIndex >= dialogueNpc.Length;
        bool playerAcabou = dialogueIndex >= dialoguePlayer.Length;

        if (npcAcabou && playerAcabou)
        {
            FecharDialogo();
            return;
        }

        isNpcTurn = !isNpcTurn;

        if (isNpcTurn && dialogueIndex >= dialogueNpc.Length)
            isNpcTurn = false;

        if (!isNpcTurn && dialogueIndex >= dialoguePlayer.Length)
            isNpcTurn = true;

        MostrarFalaAtual();
    }

    void MostrarFalaAtual()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (isNpcTurn)
        {
            dialoguePanelPlayer.SetActive(false);
            dialoguePanelNpc.SetActive(true);

            typingCoroutine =
                StartCoroutine(TypeText(
                    dialogueTextNpc,
                    dialogueNpc[dialogueIndex]
                ));
        }
        else
        {
            dialoguePanelNpc.SetActive(false);
            dialoguePanelPlayer.SetActive(true);

            typingCoroutine =
                StartCoroutine(TypeText(
                    dialogueTextPlayer,
                    dialoguePlayer[dialogueIndex]
                ));
        }
    }

    IEnumerator TypeText(TMP_Text textBox, string frase)
    {
        isTyping = true;
        textBox.text = "";

        foreach (char letter in frase)
        {
            textBox.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        isTyping = false;
        typingCoroutine = null;
    }

    void FecharDialogo()
    {
        dialoguePanelNpc.SetActive(false);
        dialoguePanelPlayer.SetActive(false);

        dialogueDone = true;
        dialogueIndex = 0;

        InfoJogo.isDialogueActive = false;
        InfoJogo.activeDialogue = null;

        if (nome == "Pastel de Nata")
            InfoJogo.nata = true;

        if (nome == "Guitarra Portuguesa")
            InfoJogo.guitarra = true;

        if (nome == "Calçada Portuguesa")
            InfoJogo.calcada = true;

        if (popUp != null)
        {
            popUp.Show(nome, imagem, descricao, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            readyToSpeak = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            readyToSpeak = false;
    }
}