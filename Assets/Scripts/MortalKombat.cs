using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalKombat : item //Cuando heredo un script mando a llamar despuede los dos puntos a el script
{
    public override void Recoger()
    {
        score.PuntajeActual += 10;
        Debug.Log("Nombre del Arcade" + nombreItem + "Año de Salida: 1992");
        Destroy(gameObject);
    }
}
