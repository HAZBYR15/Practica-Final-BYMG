using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // TODO: Texto UI
    public TextMeshProUGUI textoPuntaje;


    // TODO: Variables internas
    private int puntajeActual = 0;

    public int PuntajeActual { get; set; }
    void Start()
    {
        textoPuntaje.text = "PUNTOS" + PuntajeActual;
    }
    private void Update()
    {
        textoPuntaje.text = "PUNTOS: " + PuntajeActual;
    }
    public void CalcularPuntaje()
    {
        int puntaje = 0;

        puntaje++;
        puntajeActual = puntaje;

        if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
    }
}
