using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    //transform es un componente 
    //vector 3  es un dato NO ES UN COMPORTAMIENTO

    public Transform player;

    private bool isPlayerInRange;
    public GameEnding gameEnding;
    
    private void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            
            Debug.DrawRay(transform.position,direction,Color.yellow,Time.deltaTime,true);
            
            RaycastHit raycastHit;
            if (Physics.Raycast(ray,out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform==player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform==player)
        {
         
            isPlayerInRange = false;   
        }
    }
    
    // no se muestra cuando se compila el juego 
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(transform.position,0.1f);
        Gizmos.color=Color.blue;
        Gizmos.DrawLine(transform.position,player.position+Vector3.up);
    }

    
}
