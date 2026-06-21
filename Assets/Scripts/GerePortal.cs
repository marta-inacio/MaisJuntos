using UnityEngine;
using TMPro;

public class GerePortal : MonoBehaviour
{
    public GameObject SpwanLocation;
    public string nome;
    public MovimentoCamara movimento;

    public GameObject Camara;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Player")
        {
            switch (nome)
            {
                case "portal01":
                    //limites camara
                    movimento.minPosition = new Vector2(114.09f,37.31f);
                    movimento.maxPosition = new Vector2(157.07f,68.13f);

                    //render do mapa
                    Camara.transform.position = new Vector2(149f,26f);
                    Camara.GetComponentInChildren<Camera>().orthographicSize = 25f;
                    break;

                case "portal10":
                    movimento.minPosition = new Vector2(-31.2f, -0.1f);
                    movimento.maxPosition = new Vector2(3.9f, 90.6f);

                    Camara.transform.position = new Vector2(-0.2f, 7.3f);
                    Camara.GetComponentInChildren<Camera>().orthographicSize = 42f;
                    break;

                case "portal12":
                    movimento.minPosition = new Vector2(291.99f, 17.8f);
                    movimento.maxPosition = new Vector2(345.2f, 64.51f);

                    Camara.transform.position = new Vector2(333f, 13.5f);
                    Camara.GetComponentInChildren<Camera>().orthographicSize = 42f;
                    break;

                case "portal21":
                    movimento.minPosition = new Vector2(114.09f, 37.31f);
                    movimento.maxPosition = new Vector2(157.07f, 68.13f);

                    Camara.transform.position = new Vector2(149f, 26f);
                    Camara.GetComponentInChildren<Camera>().orthographicSize = 25f;
                    break;
            }
        }


        if (collision.tag == "Player" || collision.tag == "Inimigo"){
            collision.transform.position = SpwanLocation.transform.position; 
        }

    }
}