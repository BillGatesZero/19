using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Playermove : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent Playeragent;
    //CharacterController characterController;
    //Transform trans;
    public float movespeed = 0.1f;
    public float rotateSpeed = 30f;
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        Playeragent = GetComponent<NavMeshAgent>();
        //trans=transform;
    }

    // Update is called once per frame
    void Update()
    {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    if(v != 0||h != 0){
       
    }
　　//朝一个方向移动 new Vector3(0, 0, v) * speed * Time.deltaTime是个向量

    transform.Translate(new Vector3(0, 0, v) * movespeed * Time.deltaTime);//前后移动

    transform.Rotate(new Vector3(0, h, 0) * rotateSpeed * Time.deltaTime);
        
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit );
            if(hasHit){
                //if(hit.collider.tag == "Ground")
                //{   Playeragent.stoppingDistance = 0F;
                //    Playeragent.SetDestination(hit.point);}else 
                if(hit.collider.tag == "Interactable"){
                    hit.collider.GetComponent<InteractableObject>().Onclick(Playeragent);
                    
                }
                }
        }
    }
}
