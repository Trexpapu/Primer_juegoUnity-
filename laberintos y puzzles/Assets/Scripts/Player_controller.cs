using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
     CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
   
    [SerializeField]
    private float gravityValue = -9.81f;
   
    private Transform cameraMain;
    

    private bool hide1Presionado = false;
    private bool personajeVisible = true;

    public bool correr=false;

    public bool me_muevo;


    public Player_controlls playerInput;

    private GameObject playerObj3;
    private Task task;

    private GameObject playerObj2;
    private Hide hide;

    private GameObject playerObj;
    private Rayo_lazer rayoLazer;
    
    private void Awake()
    {
        playerInput= new Player_controlls();
        controller= GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable(){
        playerInput.Disable();
    }
    
    private void Start()
    {
        cameraMain= Camera.main.transform;

        playerObj3=GameObject.Find("cofre");
        task=playerObj3.GetComponent<Task>();

        playerObj2= GameObject.Find("BigCloset");  
        hide= playerObj2.GetComponent<Hide>();
        
         playerObj = GameObject.Find("visor");      
         rayoLazer = playerObj.GetComponent<Rayo_lazer>();
       
       
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
      

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();

        // Calcular la dirección del movimiento en el espacio del mundo
        Vector3 moveDirection = cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // Rotar el personaje hacia la dirección del movimiento
        if (moveDirection != Vector3.zero) {
            gameObject.transform.forward = moveDirection;

            // Alinear el personaje con el suelo
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f)) {
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }
        }

        // Mover el personaje utilizando el CharacterController
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);


        if (moveDirection.magnitude > 0f) {//condicional para saber si me muevo o no
             // El personaje se está moviendo
             me_muevo=true;
             Debug.Log("Me muevo: ");
        } else {
                // El personaje no se está moviendo
                me_muevo=false;
                Debug.Log("No me muevo");
            }




        // boton para interactuar..
        if (playerInput.PlayerMain.Interactuar.triggered)
        {
           //task.presionado=true;
           if(task.presionado){
            task.presionado=false;
            Debug.Log("Falso");
           }else{
            task.presionado=true;
            Debug.Log("true");
           }
           
           
        }
        
        

        //gravity
          playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //sprint of the player
      
        if(playerInput.PlayerMain.Sprint.triggered){
            if(!correr){
                playerSpeed=6f;
                correr=true;
            }else if(correr){
                playerSpeed=2f;
                correr=false;
            }
        }


      
       


    //hide player

       

       
    if (playerInput.PlayerMain.Hide1.triggered) {
        if (personajeVisible && rayoLazer.choca && !hide.esconder && !hide1Presionado) {
            
            hide.esconder = true;
            hide1Presionado = true;
            personajeVisible = false;
             controller.enabled = false;
        }
        else if (!personajeVisible && hide.esconder && hide1Presionado) {
           
            hide.presionado = true;
            hide.esconder = false;
            hide1Presionado = false;
            personajeVisible = true;
           
          
        }

    }
    if(hide.salio){
       StartCoroutine(finSalio());
       hide.salio=false;
    }
   
   


    }

    IEnumerator finSalio(){
    yield return new WaitForSeconds(1.5f);
    controller.enabled=true;
    
  }

  
    
}
