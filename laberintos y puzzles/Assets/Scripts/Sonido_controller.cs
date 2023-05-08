using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido_controller : MonoBehaviour
{

    //este script controla el audio que hará el jugador y aumenta el rango
    public AudioClip[] sonidosDeCaminar;//arreglo para los sonidos de caminar
    public AudioClip[] sonidosDeCorrer;//audio para los sonidos de correr
    AudioClip sonidoAReproducir;//audio para hacer switch en el sonido
    float maxDistancia;//aumentar la distancia donde se escucha el sonido
    float minDistancia;//disminuir la distancia donde se escucha el sonido

    public AudioSource audioSource;
    private Player_controller controller;

    // Start is called before the first frame update
    void Start()
    {
       
       controller=GetComponent<Player_controller>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.me_muevo){//si me muevo o no 
        if(!audioSource.isPlaying){//si no hay sonido reproduciondo
        if(controller.correr==true){//si estoy corriendo
            sonidoAReproducir= sonidosDeCorrer[Random.Range(0, sonidosDeCorrer.Length)];//va a seleccionar un sonido random de mi arreglo de sonidos
            maxDistancia = 10f; // distancia máxima cuando está corriendo
            minDistancia=2f;//distancia minima
        }else{
            sonidoAReproducir = sonidosDeCaminar[Random.Range(0, sonidosDeCaminar.Length)];
             maxDistancia = 5f; // distancia máxima cuando está caminando
             minDistancia=1f;
        }

        audioSource.clip = sonidoAReproducir;//ponemos el sonido a reproducir en el clip
        audioSource.maxDistance = maxDistancia;//le cambiamos la distancia
        audioSource.minDistance=minDistancia;
        audioSource.Play();//reproducimos
        }
    }else{
        audioSource.Stop();//detener el sonido si no me muevo
    }
    }
}
