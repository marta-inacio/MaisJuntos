using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class NpcDialogueHospital : MonoBehaviour
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

    private int npcIndex = 0;
    private int playerIndex = 0;

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

    public GameObject popUpAjudar;

    [Header("Objeto entregue")]
    public bool objetoEntregue = false;

    void Start()
    {
        dialoguePanelNpc.SetActive(false);
        dialoguePanelPlayer.SetActive(false);
    }

    void Update()
    {
        if (!InfoJogo.isDialogueActive)
            return;

        if (InfoJogo.activeDialogue2 != this)
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

        npcIndex = 0;
        playerIndex = 0;
        isNpcTurn = true;
        dialogueDone = false;

        InfoJogo.isDialogueActive = true;
        InfoJogo.activeDialogue2 = this;

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
            dialogueTextNpc.text = dialogueNpc[npcIndex];
        }
        else
        {
            dialogueTextPlayer.text = dialoguePlayer[playerIndex];
        }

        isTyping = false;
    }

    void NextDialogue()
    {
        if (isNpcTurn)
        {
            npcIndex++;
        }
        else
        {
            playerIndex++;
        }

        bool npcAcabou = npcIndex >= dialogueNpc.Length;
        bool playerAcabou = playerIndex >= dialoguePlayer.Length;

        if (npcAcabou && playerAcabou)
        {
            FecharDialogo();
            return;
        }

        // Alternar turno
        isNpcTurn = !isNpcTurn;

        // Se o NPC já acabou, passa para o Player
        if (isNpcTurn && npcAcabou)
        {
            isNpcTurn = false;
        }

        // Se o Player já acabou, passa para o NPC
        if (!isNpcTurn && playerAcabou)
        {
            isNpcTurn = true;
        }

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

            typingCoroutine = StartCoroutine(TypeText(
                dialogueTextNpc,
                dialogueNpc[npcIndex]
            ));
        }
        else
        {
            dialoguePanelNpc.SetActive(false);
            dialoguePanelPlayer.SetActive(true);

            typingCoroutine = StartCoroutine(TypeText(
                dialogueTextPlayer,
                dialoguePlayer[playerIndex]
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

        npcIndex = 0;
        playerIndex = 0;

        InfoJogo.isDialogueActive = false;
        InfoJogo.activeDialogue2 = null;

        if (popUp != null && objetoEntregue)
        {
            popUp.Show(nome, imagem, descricao, 3f);
        }
        else
        {
            popUpAjudar.SetActive(true);
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