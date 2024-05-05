using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System;
public class Playermove : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerAttribute playerAttribute;
    private NavMeshAgent Playeragent;
    //CharacterController characterController;
    //private Transform trans;
    public float movespeed = 0.1f;
    public float rotateSpeed = 30f;
    private Animator animator;
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        Playeragent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerAttribute = GetComponent<PlayerAttribute>();
        //trans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    //print(Vector3.Distance(transform.position,new Vector3(484,6,392)));
    float h = Input.GetAxis("Horizontal");
    float r = 10f*Input.GetAxis("Mouse X");
    float v = Input.GetAxis("Vertical");
    //if(v != 0||h != 0){}
　　//朝一个方向移动 new Vector3(0, 0, v) * speed * Time.deltaTime是个向量

    animator.SetFloat("Speed",Math.Abs(h)+2*v);
    //print(v+" "+h);
    transform.Translate(new Vector3(h, 0, v) * movespeed * Time.deltaTime);//前后移动
    transform.Rotate(new Vector3(0, r, 0) * rotateSpeed * Time.deltaTime);
    playerAttribute.Adddistance(movespeed*Time.deltaTime*Math.Sqrt(h*h+v*v));
        
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
