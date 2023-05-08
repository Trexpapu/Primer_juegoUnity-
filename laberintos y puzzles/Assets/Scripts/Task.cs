using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
  
    private GameObject playerObj;
    private Rayo_lazer rayoLazer;

     public GameObject taskPrefab;
    private GameObject taskInstance;
 
   
    public bool presionado=false;
     
    void Start()
    {
        playerObj = GameObject.Find("visor");
            
         rayoLazer = playerObj.GetComponent<Rayo_lazer>();
   
     taskInstance = Instantiate(taskPrefab);
           taskInstance.SetActive(false);
           Debug.Log("Lo instancie y lo desactive de la escnea");
         
    }
    void Update()
    {
        
        if(rayoLazer.chocaPuzzle){
            if(presionado && isTaskActive()){//si le picaste y no hay una tarea ya activa
                taskInstance.SetActive(true);
                Debug.Log("Entro a activar el prefab");;           
            }
            if(!presionado){
            taskInstance.SetActive(false);
            Debug.Log("Entro a desactivar el prefab");
        
            }
        }else{
            presionado=false;
        }


    }


    private bool isTaskActive(){//funcion para evitar abrir varios paneles
        return !GameObject.FindWithTag("task");

    }
    




 
}
