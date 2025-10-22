using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvsZ : item
{
    public override void Recoger()
    {
        score.PuntajeActual++;
        Debug.Log("Nombre del Arcade" + nombreItem + "Año de Salida: 1993" + "Disficultad: Alta");
    }
}
