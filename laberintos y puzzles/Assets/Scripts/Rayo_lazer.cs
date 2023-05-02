using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo_lazer : MonoBehaviour
{

  private float rango = 0.5f;
    public GameObject eyes;
    public Transform rayo;
  
    public bool choca;//choca con un objeto para hide
    public bool chocaPuzzle;

    private void Start() {
    eyes = GameObject.Find("visor");
    rayo = eyes.transform;
    }

  private  void Update()
  {
    RaycastHit hit;
    Vector3 origenRayo=rayo.position;
    Vector3 direccionRayo=rayo.forward;
    if(Physics.Raycast(origenRayo, direccionRayo, out hit, rango)){// buscamos el objeto y vemos donde esta el origen, luego la direccion hacia delante, out hit y el rango que le dimos
       
        if(hit.collider.GetComponent<Hide>()==true){//si choca un objeto con componente hide 
           choca=true;
         
        }else{
          choca=false;
        }

    }else{
      choca=false;
    }


     if(Physics.Raycast(origenRayo, direccionRayo, out hit, rango)){
      if(hit.collider.GetComponent<Task>()==true){//si choca un objeto con componente Task
        chocaPuzzle=true;
      }else{
        chocaPuzzle=false;
      }
     }else{
      chocaPuzzle=false;
     }

  }

    private void OnDrawGizmos(){
        Vector3 origenRayo=rayo.position;
        Vector3 direccionRayo=rayo.forward;
        Gizmos.color= Color.green;
        Gizmos.DrawRay(origenRayo, direccionRayo * rango);
    }

}
