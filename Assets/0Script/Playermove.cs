using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Animations.Rigging;
public class Playermove : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerAttribute playerAttribute;
    private NavMeshAgent Playeragent;
    //private GameObject Maincamera;
    //private GameObject Player;
    //CharacterController characterController;
    //private Transform trans;
    public float movespeed = 0.1f;
    public float rotateSpeed = 30f;
    private Animator animator;
    public bool isstop = false;
    private bool isdodge = false;
    private float dodgetime ;
    private float dodgetimeleft = 0f;
    private float cd;
    private float cdleft = 0f;
    private PlayerAttack playerAttack;
    public bool isaiming = false;

    private GameObject leftIK;
    private GameObject rightIK;
    private GameObject toolPrefab;
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        //Player = this.gameObject;
        Playeragent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerAttribute = GetComponent<PlayerAttribute>();
        isstop=false;
        isdodge=false;
        dodgetime = 0.4f;
        dodgetimeleft = dodgetime;
        cd=2.5f;
        cdleft = cd;
        playerAttack = GetComponent<PlayerAttack>();
        isaiming = false;
        toolPrefab=null;
        leftIK = GameObject.Find("Rig/LefthandHP");
        rightIK = GameObject.Find("Rig/RighthandHP");
        //Maincamera = GameObject.Find("Main Camera");
        //trans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
    //print(Vector3.Distance(transform.position,new Vector3(484,6,392)));
    float h = Input.GetAxis("Horizontal");
    float r = 10f*Input.GetAxis("Mouse X");
    float v = Input.GetAxis("Vertical");
    //if(Maincamera!=null){if(Maincamera.GetComponent<cameramove>().isfirst!=false){this.gameObject.layer=2;}else{this.gameObject.layer=0;}}
    transform.Rotate(new Vector3(0, r, 0) * rotateSpeed * Time.deltaTime);
    //if(v != 0||h != 0){}
　　// new Vector3(0, 0, v) * speed * Time.deltaTime
    
    
    if(isstop == false){
    if(Input.GetKey(KeyCode.LeftShift)&&cdleft<=0){isdodge=true;}

    if(isdodge==false){
    animator.SetBool("dodge",false);
    animator.SetFloat("Speed",Math.Abs(h)+2*v);
    //print(v+" "+h);
    transform.Translate(new Vector3(h, 0, v) * movespeed * Time.deltaTime);
    if(cdleft>0){cdleft-=Time.deltaTime;}
    playerAttribute.Adddistance(movespeed*Time.deltaTime*Math.Sqrt(h*h+v*v));}


    //control Attack animation
    
    if(playerAttack.tool!=null){
    if(playerAttack.tool.isShootingTool==true&&Input.GetKeyDown(KeyCode.V)){
        if(this.isaiming==false){isaiming=true;
        toolPrefab=playerAttack.tool.gameObject;
        leftIK.GetComponent<TwoBoneIKConstraint>().data.target=toolPrefab.transform.Find("LHandGrip");
        rightIK.GetComponent<TwoBoneIKConstraint>().data.target=toolPrefab.transform.Find("RHandGrip");
        this.gameObject.GetComponent<RigBuilder>().Build();
        }else{isaiming=false;
        leftIK.GetComponent<TwoBoneIKConstraint>().data.target=null;
        rightIK.GetComponent<TwoBoneIKConstraint>().data.target=null;
        this.gameObject.GetComponent<RigBuilder>().Build();
        }

    }else if (playerAttack.tool.isShootingTool==false){isaiming=false;}
    
    
    




    if(Input.GetKey(KeyCode.C)){
        switch(playerAttack.tool.id){
            case 3:animator.SetInteger("Attack",1);break;
            case 4:animator.SetInteger("Attack",2);break;

        }
        
    }else{if(playerAttack.tool.id==4){Debug.Log(playerAttack.tool.id);animator.SetInteger("Attack",3);}else{animator.SetInteger("Attack",0);}}}
    else{isaiming=false;}



    //
    if(isdodge==true){
        transform.Translate(new Vector3(2*h, 0, 2*v) * movespeed * Time.deltaTime);
        dodgetimeleft -= Time.deltaTime;
        playerAttribute.Adddistance(movespeed*Time.deltaTime*Math.Sqrt(9*h*h+9*v*v));
        animator.SetBool("dodge",true);
        if(dodgetimeleft <= 0){
            isdodge = false;
            dodgetimeleft = dodgetime;
            cdleft = cd;}}}
        


        if(Input.GetMouseButtonDown(0)) {
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2+25, Screen.height / 2));
            print(new Vector3(Screen.width / 2, Screen.height / 2)-Input.mousePosition);   
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);if(hasHit){
                //if(hit.collider.tag == "Ground")
                //{   Playeragent.stoppingDistance = 0F;
                //    Playeragent.SetDestination(hit.point);}else 
                if(hit.collider.tag == "Interactable"){hit.collider.GetComponent<InteractableObject>().Onclick(Playeragent);}}}
    }
}
