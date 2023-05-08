using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_controller : MonoBehaviour
{
    public float alcanceDeSonido = 2f; // rango máximo de detección
    public Transform objetoDelJugador; // transform del objeto del jugador
    private AudioSource audioJugador;
    

    void Start()
    {
        audioJugador = objetoDelJugador.GetComponent<AudioSource>(); // obtener el AudioSource del jugador
    }

    private void Update()
    {
        
        // verificar si el jugador está dentro del alcance de sonido del enemigo
        float distancia = Vector3.Distance(transform.position, objetoDelJugador.position);
        if (distancia < alcanceDeSonido)
        {
            // si el jugador está haciendo sonidos, detectarlos
            if (audioJugador.isPlaying)
            {
                // realiza la acción deseada aquí, como persiguiendo al jugador o mostrando un mensaje en la pantalla
                Debug.Log("El jugador está dentro del alcance de sonido del enemigo");
            }
        }
    }
}
