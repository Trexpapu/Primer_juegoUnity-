using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_controller : MonoBehaviour
{
    [SerializeField]
    public float alcanceDeSonido = 2f; // rango máximo de detección
    public Transform objetoDelJugador; // transform del objeto del jugador
    private AudioSource audioJugador;
    private GameObject objeto;
    private Player_controller controller;//obtenemos los datos de playercontroller

    void Start()
    {
        audioJugador = objetoDelJugador.GetComponent<AudioSource>(); // obtener el AudioSource del jugador
        objeto=GameObject.FindGameObjectWithTag("Player");
        controller=objeto.GetComponent<Player_controller>();
    }

    private void Update()
    {
        
        // verificar si el jugador está dentro del alcance de sonido del enemigo
        float distancia = Vector3.Distance(transform.position, objetoDelJugador.position);
        if (distancia < alcanceDeSonido)
        {
            // si el jugador está haciendo sonidos, detectarlos
            if (audioJugador.isPlaying && controller.correr)//si se reproduce un sonido del jugador y este esta corriendo
            {
                // realiza la acción deseada aquí, como persiguiendo al jugador o mostrando un mensaje en la pantalla
                Debug.Log("El jugador está dentro del alcance de sonido del enemigo");
            }
        }
    }
}
