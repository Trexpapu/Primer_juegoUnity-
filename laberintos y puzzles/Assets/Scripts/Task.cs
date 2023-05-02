using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
   public GameObject task;
    private GameObject playerObj;
    private Rayo_lazer rayoLazer;
   
    public bool presionado;
     
    void Start()
    {
        playerObj = GameObject.Find("visor");
            
         rayoLazer = playerObj.GetComponent<Rayo_lazer>();
         
    }
    void Update()
    {
        if(rayoLazer.chocaPuzzle){
            if(presionado && isTaskActive()){//si le picaste y no hay una tarea ya activa
            Instantiate(task);
            presionado=false;
            }
        }else{
            presionado=false;
        }
    }


    private bool isTaskActive(){//funcion para evitar abrir varios paneles
        return !GameObject.FindWithTag("task");

    }
    




 
}
