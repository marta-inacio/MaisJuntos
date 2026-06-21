using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TirarFoto : MonoBehaviour
{
    [Header("UI")]
    public RawImage previewCamera;   // Mostra o feed da câmara ao vivo
    public RawImage fotoCapturada;   // Mostra a foto depois de tirar
    public Button botaoAbrirCamera;
    public Button botaoTirarFoto;

    [Header("Resultado")]
    public Texture2D fotoGuardada;   // A foto fica guardada aqui (visível no Inspector)

    private WebCamTexture webcamTexture;

    void Start()
    {
        // Pede permissão da câmara antes de qualquer coisa
        #if UNITY_ANDROID
            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera))
            {
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);
            }
        #endif
    }

    public void AbrirCamera()
    {
        // Pede permissão e abre a câmara traseira
        WebCamDevice[] dispositivos = WebCamTexture.devices;

        if (dispositivos.Length == 0)
        {
            Debug.LogError("Nenhuma câmara encontrada!");
            return;
        }

        // Procura a câmara traseira (isFrontFacing == false)
        string nomeCamera = dispositivos[0].name;
        foreach (var dispositivo in dispositivos)
        {
            if (!dispositivo.isFrontFacing)
            {
                nomeCamera = dispositivo.name;
                break;
            }
        }

        webcamTexture = new WebCamTexture(nomeCamera, 1920, 1080, 30);
        previewCamera.texture = webcamTexture;
        webcamTexture.Play();

        Debug.Log("Câmara aberta: " + nomeCamera);
    }

    public void CapturarFoto()
    {
        if (webcamTexture == null || !webcamTexture.isPlaying) return;

        // Copia o frame atual para uma Texture2D
        fotoGuardada = new Texture2D(webcamTexture.width, webcamTexture.height);
        fotoGuardada.SetPixels(webcamTexture.GetPixels());
        fotoGuardada.Apply();

        // Mostra a foto capturada
        fotoCapturada.texture = fotoGuardada;

        // Para a câmara para poupar bateria
        webcamTexture.Stop();
        webcamTexture = null;


        //colocar guardada para pôr no livro
        InfoJogo.fotoCapturada = fotoGuardada;
    }

    public void DesligarCamara()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
            webcamTexture.Stop();
    }

    void OnDestroy()
    {
        DesligarCamara();
    }
}