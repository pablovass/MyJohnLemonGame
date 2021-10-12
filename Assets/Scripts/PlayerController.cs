using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private Animator _animator;
    public float turnSpeed;
    public Rigidbody _rigidbody;
    private Quaternion rotation = Quaternion.identity;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();//refenciamos el animator
        _rigidbody = GetComponent<Rigidbody>();

    }

    // ocurre menos veces que el update 50 por segundo 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        movement.Set(horizontal,0,vertical);
        
        movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        _animator.SetBool("IsWalking",isWalking);
        
        // creamos una variable de mirada deseada. 
        Vector3 desiredForward=Vector3.RotateTowards(transform.forward,movement,turnSpeed*Time.fixedDeltaTime,0f);
        
         rotation=Quaternion.LookRotation(desiredForward);
    }
//cuando el animator cambie 
    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position+movement*_animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
       
    }
}
