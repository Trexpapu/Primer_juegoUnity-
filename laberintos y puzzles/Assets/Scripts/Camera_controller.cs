using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(CinemachineFreeLook))]
public class Camera_controller : MonoBehaviour
{
   private CinemachineFreeLook cinemachine;
   private Player_controlls playerInput;
   [SerializeField]
   private float lookSpeed=1f;



    private void Awake()
    {
        playerInput= new Player_controlls();
        cinemachine= GetComponent<CinemachineFreeLook>();
       
    }
   private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable(){

        playerInput.Disable();
    }

    private void Update()
    {
        Vector2 delta= playerInput.PlayerMain.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }

    
}
