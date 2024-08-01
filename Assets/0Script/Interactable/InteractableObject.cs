using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclick(){
       
        
        //Playeragent.SetDestination(transform.position);

        Interact();
    }
    protected virtual void Interact(){
        print("Interact");
    }
}
