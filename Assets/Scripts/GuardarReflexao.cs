using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // se usares TMP

public class GuardarReflexao : MonoBehaviour
{
    public TMP_InputField campoInput; 

    public void AoClicarGuardar()
    {
        string texto = campoInput.text;
        PlayerPrefs.SetString("TextoGuardado", texto);
        PlayerPrefs.Save();

    }
}