using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : InteractableObject
{
    
    // Start is called before the first frame update
    private bool islocked = false;
    private GameObject door;
    private GameObject soliddoor;
    public void Start(){
        //hinge = this.GetComponent<HingeJoint>();
        //rb = this.GetComponent<Rigidbody>();
        door = transform.Find("Door").gameObject;
        soliddoor = transform.Find("Cube").gameObject;
        soliddoor.SetActive(false);
        islocked = false;
    }
    // Update is called once per frame
    protected override void Interact()
    {
        if (islocked){islocked = false;
        soliddoor.SetActive(true);
        door.SetActive(false);
        }else{islocked = true;
        soliddoor.SetActive(false);
        door.SetActive(true);
       
        }
    }
}
