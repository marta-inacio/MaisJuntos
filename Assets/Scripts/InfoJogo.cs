using UnityEngine;

public static class InfoJogo
{
    //qual o menu aberto
    public static int menu;

    //guardar o valor do progresso entre scenes para fazer a fazer preencher
    public static float missao1 = 0;
    public static float missao2 = 0;

    //voluntariado ou não?
    public static bool voluntariado = false;

    //foto do voluntariado
    public static Texture2D fotoCapturada;

    //nivelItemsEncontrados
    public static int itemsEncontrados = 0;
}