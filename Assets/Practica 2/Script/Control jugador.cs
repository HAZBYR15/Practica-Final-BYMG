using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controljugador : MonoBehaviour
{
    // Start is called before the first frame update
    //Caracter controler es la pieza que nos va permitir el movimiento en el juego 
    //Velocidad Vertical - nos va permitir que tan rapido caemos
    //Es para registrar que camara va funcionar como los ojos del jugador
    //Que tan rapido se va movel el jugador al voltear
    //Rotacion Va indicar cuantosd grados va poder voltear para bajo o para arriba



    //Movimiento
    public float velocidad = 5f;
    public float gravedad = -9.8f;
    private CharacterController controller;
    private Vector3 velocidadVertical;
    //Variables Vista
    public Transform camara;
    public float SensibilidadMouse = 200f;
    private float rotacionXVertical = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        //Controller- Funciona para buscar la pieza de lego


        //Esta linea bloquea el puntero del mouse en los limites de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Manejador_Movimiento();
        Manejador_Vista();

    }
    void Manejador_Vista()
    {
        //1. Leer el input del mouse
        float mouseX= Input.GetAxis("Mouse X")*SensibilidadMouse*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * SensibilidadMouse * Time.deltaTime;
        //2.Contruir la orientacion horizaontal
        transform.Rotate(Vector3.up * mouseX);

        //3.REgistro de la orientacion VErtical
        rotacionXVertical -= mouseY;

        //4.Limitar la rotacion vertical
        Mathf.Clamp(rotacionXVertical, -90, 90f);
        //5.Aplicar la rotacion 
        //Son los ejes X , Y y Z
        camara.localRotation= Quaternion.Euler(rotacionXVertical,0,0);

    }
    void Manejador_Movimiento()
    {
        //1. Leer el input de movimiento(W,A,S y D o las flechas de direccion)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //2. Crear el VEctor de movimiento - Se almacena de forma local el registro de direccion de movimiento
        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;

        //3. Mover el caracter controller
        controller.Move(direccion*velocidad*Time.deltaTime);

        //4. Aplicar la gravedad
        //Se registra si esta en el piso para un futuro comportamiento de salto
        if(controller.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;//Una pequeña fuerza hacia abajo para mantenerlo pegado al piso
        }
        //Aplicamos la aceleracion de la gravedad
        velocidadVertical.y += gravedad * Time.deltaTime;

        //Movemos el controlador hacia abajo
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}