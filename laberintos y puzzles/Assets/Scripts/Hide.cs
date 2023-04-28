using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{

  [SerializeField]
  private Transform dentro, fuera;
  [SerializeField]
  private float tiempo;
  private GameObject player;
 
  public bool esconder;
  public bool presionado;
  Transform PlayerT;
  
  private void Start()
  {
    player= GameObject.FindGameObjectWithTag("Player");
    PlayerT= player.GetComponent<Transform>();

  }

  private void Update()
  {
    
    if(esconder==true){
      Debug.Log("Esconder = true");
        PlayerT.position= Vector3.Lerp(PlayerT.position, dentro.position, tiempo * Time.deltaTime);
        PlayerT.rotation=Quaternion.Lerp(PlayerT.rotation, dentro.rotation, tiempo * Time.deltaTime);
       
        
        
    }

  

    if(esconder==false && presionado == true){
      Debug.Log("esconder=false");
        PlayerT.position= Vector3.Lerp(PlayerT.position, fuera.position, tiempo * Time.deltaTime);
        PlayerT.rotation=Quaternion.Lerp(PlayerT.rotation, fuera.rotation, tiempo * Time.deltaTime);
        StartCoroutine(finEscondite());
        presionado=false;
        esconder=false;
       
    }

  }

  IEnumerator finEscondite(){
    yield return new WaitForSeconds(2);
    esconder=false;
  }
}
