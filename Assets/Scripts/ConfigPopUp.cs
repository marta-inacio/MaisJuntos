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
    }

    public void Show(string n, Sprite img, string desc, float time)
    {
        popUp.SetActive(true);

        nome.text = n;
        descricao.text = desc;
        imagem.sprite = img;

        if (hideRoutine != null)
        {
            StopCoroutine(hideRoutine);
        }

        hideRoutine = StartCoroutine(HideAfterTime(time));
    }
    private IEnumerator HideAfterTime( float time)
    {
        yield return new WaitForSeconds(time);
        popUp.SetActive(false);
    }
}