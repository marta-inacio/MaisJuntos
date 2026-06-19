using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPopUp : MonoBehaviour
{
    public GameObject popUp;
    public TMP_Text nome;
    public Image imagem;
    public TMP_Text descricao;

    private Coroutine hideRoutine;

    public void Show(string n, Sprite img, string desc)
    {
        popUp.SetActive(true);

        nome.text = n;
        descricao.text = desc;
        imagem.sprite = img;

        if (hideRoutine != null)
        {
            StopCoroutine(hideRoutine);
        }

        hideRoutine = StartCoroutine(HideAfterTime());
    }

    private IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        popUp.SetActive(false);
    }
}