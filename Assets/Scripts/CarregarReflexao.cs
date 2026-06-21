using UnityEngine;
using TMPro;

public class CarregarReflexao : MonoBehaviour
{
    public TMP_Text campoTexto; 

    void Start()
    {
        if (PlayerPrefs.HasKey("TextoGuardado"))
        {
            campoTexto.text = PlayerPrefs.GetString("TextoGuardado");
        }
    }
}