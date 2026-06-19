using UnityEngine;
using UnityEngine.UI;

public class SliderCrescer : MonoBehaviour
{
    public Slider missao1;
    public Slider missao2;

    void Start()
    {
        missao1.value = InfoJogo.missao1;
        missao2.value = InfoJogo.missao2;
    }
}