using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Items: MonoBehaviour
{

    public string nome;
    public Sprite imagem;

    public ConfigPopUp popUp;
    //public Vidas vidas;
    //public Timer tempo;
    //public Player Jogador;

    //sliders 
    public GameObject alcool;
    public GameObject anestesia;
    public GameObject bata;
    public GameObject compressas;
    public GameObject estetoscopio;
    public GameObject luvas;
    public GameObject mascara;
    public GameObject monitor;
    public GameObject oculos;
    public GameObject penso;
    public GameObject seringa;
    public GameObject soro;
    public GameObject tesoura;
    public GameObject touca;
    public GameObject bisturi;

    public TMP_Text textoEncontrados;

    public ControlarNivel controlarNivel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("entrei no trigger");
        if (other.CompareTag("Player"))
        {
            popUp.Show("Encontraste", imagem, nome, 0.8f);

            PreencheSlider(nome);

            gameObject.SetActive(false);


            //se encontra todos ganha
            InfoJogo.itemsEncontrados++;
            textoEncontrados.text = InfoJogo.itemsEncontrados.ToString();

            if(InfoJogo.itemsEncontrados == 15)
            {
                //Debug.Log("ENTREI NO GANAHR");
                InfoJogo.itemsEncontrados = 0;
                controlarNivel.VencerJogo();
            }
        }
    }

    public void PreencheSlider(string nome)
    {
        switch (nome)
        {
            case "Alcool": 
                Encontrado(alcool); 
                break;
            case "Anestesia": 
                Encontrado(anestesia); 
                break;
            case "Bata": 
                Encontrado(bata); 
                break;
            case "Compressas": 
                Encontrado(compressas); 
                break;
            case "Estetoscopio": 
                Encontrado(estetoscopio); 
                break;
            case "Luvas": 
                Encontrado(luvas); 
                break;
            case "Mascara": 
                Encontrado(mascara); 
                break;
            case "Monitor": 
                Encontrado(monitor); 
                break;
            case "Oculos": 
                Encontrado(oculos); 
                break;
            case "Penso": 
                Encontrado(penso); 
                break;
            case "Seringa": 
                Encontrado(seringa); 
                break;
            case "Tesoura": 
                Encontrado(tesoura); 
                break;
            case "Touca": 
                Encontrado(touca); 
                break;
            case "Bisturi": 
                Encontrado(bisturi); 
                break;
            case "Soro":
                Encontrado(soro);
                break;
        }
    }

    void Encontrado(GameObject obj)
    {
        if (obj != null)
        {
            Image img = obj.GetComponent<Image>();
            img.color = Color.green;
        }
    }

}
