using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player_movement_controller : MonoBehaviour
{
   [SerializeField]
   private Rigidbody _rigidbody;
    [SerializeField]
    private FixedJoystick _joystick;

    [SerializeField]
    private Animation _animator;
    [SerializeField]
    private float moveSpeed;

    private void FixedUpdate()
    {
        _rigidbody.velocity= new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y , _joystick.Vertical * moveSpeed);
    }
}
