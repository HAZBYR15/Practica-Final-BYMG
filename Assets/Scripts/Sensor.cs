using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] luces;
    public Score score;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)//Sirve cuando yo entre al sen
    {

        //En ves de buscar por etiqueta ahora vas a buscar por tipo de componente heredado
        item itemRecogido = other.GetComponent<item>();
        if (itemRecogido != null)
        {
            itemRecogido.Recoger();
        }

        if (other.CompareTag("arcade"))
        {
            
            //luz.SetActive(true);//Sirve para prender  una luz, en este es individual el objeto
            foreach(var luz in luces)
            {
                luz.SetActive(true);//Este como esta dentro de un bucle aplicara a todos los objetos de una grupo
            }
            Debug.Log("Hecha una ficha");
        }

        if (other.CompareTag("item"))
        {
            score.CalcularPuntaje();
            other.gameObject.SetActive(false);
            Debug.Log("Obtuviste un PejeDolar");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("arcade"))//other apunta, el parametro almacena temporalmente las caracteristicas del objeto etiquetado
        {
            //luz.SetActive(false);
            foreach (var luz in luces)
            {
                luz.SetActive(false);//Este como esta dentro de un bucle aplicara a todos los objetos de una grupo
            }
            Debug.Log("Game over: regresa cuando quieras");
        }
    }
}//Puerta al infierno
