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
    //private NavMeshAgent Playeragent;
    //private GameObject Maincamera;
    //private GameObject Player;
    //CharacterController characterController;
    //private Transform trans;
    public float movespeed = 0.1f;
    public float rotateSpeed = 30f;
    public float realHeigth = 1.5f;
    public float bodyRadius = 0.25f;
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
    public CharacterController characterController;
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        //Player = this.gameObject;
        //Playeragent = GetComponent<NavMeshAgent>();
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
        characterController = GetComponent<CharacterController>();
        //Maincamera = GameObject.Find("Main Camera");
        //trans=GetComponent<Transform>();
    }

    // Update is called once per frame transform
    
    void Update(){
        
    //print(Vector3.Distance(transform.position,new Vector3(484,6,392)));
    float h = Input.GetAxis("Horizontal");
    float r = 5f*Input.GetAxis("Mouse X");
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
    
    Vector3 aimPos = ((this.transform.right*h+  this.transform.forward*v)* movespeed * Time.deltaTime)+ transform.position;
    characterController.Move(AntiPenetrationPos(aimPos)-transform.position);
    
    
    if(cdleft>0){cdleft-=Time.deltaTime;}
    playerAttribute.Adddistance(movespeed*Time.deltaTime*Math.Sqrt(h*h+v*v));}
    if(EventSystem.current.IsPointerOverGameObject()){return;}

    if(isdodge==true){
        Vector3 aimPos = ((this.transform.right*h+ this.transform.forward*v)* 2*movespeed * Time.deltaTime) + transform.position;
        characterController.Move(AntiPenetrationPos(aimPos)-transform.position);
        dodgetimeleft -= Time.deltaTime;
        playerAttribute.Adddistance(movespeed*Time.deltaTime*Math.Sqrt(9*h*h+9*v*v));
        animator.SetBool("dodge",true);
        if(dodgetimeleft <= 0){
            isdodge = false;
            dodgetimeleft = dodgetime;
            cdleft = cd;}}


    //control Attack animation
    
    if(playerAttack.tool!=null){
    if(isaiming){
        Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2-40, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)&&Vector3.Dot(this.gameObject.transform.forward,Vector3.Normalize(hit.point  -toolPrefab.transform.position))>0.6f)
            {
            
            toolPrefab.transform.LookAt(hit.point);
            toolPrefab.transform.Rotate(new Vector3(0,90,0));
            //toolPrefab.transform.localEulerAngles=new Vector3(0,toolPrefab.transform.localEulerAngles.y,toolPrefab.transform.localEulerAngles.z);
            //toolPrefab.transform.localEulerAngles=new Vector3(0,toolPrefab.transform.localEulerAngles.y,toolPrefab.transform.localEulerAngles.z);
            //toolPrefab.transform.forward = Vector3.Cross(hit.point - toolPrefab.transform.position, Vector3.up);
            }}else if(toolPrefab!=null){toolPrefab.transform.localEulerAngles=new Vector3(0,0,0);toolPrefab=null;}
        
    if(playerAttack.tool.isShootingTool==true&&Input.GetKeyDown(KeyCode.V)){
        if(!this.isaiming){isaiming=true;
        toolPrefab=playerAttack.tool.gameObject;
        toolPrefab.transform.rotation=this.gameObject.transform.rotation;
        leftIK.GetComponent<TwoBoneIKConstraint>().data.target=toolPrefab.transform.Find("LHandGrip");
        rightIK.GetComponent<TwoBoneIKConstraint>().data.target=toolPrefab.transform.Find("RHandGrip");
        Invoke("ToBuildRig",0.3f);
        animator.SetInteger("Attack",4);
        }else{isaiming=false;
        leftIK.GetComponent<TwoBoneIKConstraint>().data.target=null;
        rightIK.GetComponent<TwoBoneIKConstraint>().data.target=null;
        ToBuildRig();
        animator.SetInteger("Attack",3);
        }

    }else if (playerAttack.tool.isShootingTool==false){isaiming=false;}
    
    





    if(Input.GetKey(KeyCode.C)){
        switch(playerAttack.tool.id){
            case 3:animator.SetInteger("Attack",1);break;
            case 1:animator.SetInteger("Attack",1);break;

        }
        
    }else{if(playerAttack.tool.id==4){if(!isaiming){animator.SetInteger("Attack",3);}}else{animator.SetInteger("Attack",0);}}}
    else{isaiming=false;}



    
    }
        InteractWithObject();
       //if(Mathf.Abs(this.gameObject.transform.rotation.x)>=0&&Mathf.Abs(this.gameObject.transform.rotation.z)>=0){this.gameObject.transform.rotation=Quaternion.Euler(0,this.gameObject.transform.rotation.y,0);}

        
    }
    public void ToBuildRig(){this.gameObject.GetComponent<RigBuilder>().Build();}
    protected void InteractWithObject(){
        if(Input.GetMouseButtonDown(0)) {
            
            Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2-40, Screen.height / 2));
            print(new Vector3(Screen.width / 2, Screen.height / 2)-Input.mousePosition);   
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);if(hasHit){
                //if(hit.collider.tag == "Ground")
                //{   Playeragent.stoppingDistance = 0F;
                //    Playeragent.SetDestination(hit.point);}else 
                if(hit.collider.tag == "Interactable"){hit.collider.GetComponent<InteractableObject>().Onclick();}}}
    }
    private Vector3 AntiPenetrationPos(Vector3 _aimPos)
    {
        if (transform.position == _aimPos)
        {
            return transform.position;
        }
        //判定横纵的可移动性
        bool couldHmove = true;
        bool couldVmove = true;
        //获取角色横纵偏移向量
        Vector3 dirH = (new Vector3(_aimPos.x - transform.position.x, 0, 0)).normalized;
        Vector3 dirV = (new Vector3(0, 0, _aimPos.z - transform.position.z)).normalized;
        RaycastHit hit;


        Vector3 bodyPos = transform.position;
        float tempPercent = 3;
        bodyPos.y += realHeigth / tempPercent;

        //判定横向
        if (dirH != Vector3.zero && Physics.Raycast(new Ray(bodyPos, dirH), out hit, bodyRadius))
        {
            if (hit.collider.tag != "Walkable") {couldHmove = false;}
        }
        else
        {

            if (Physics.Raycast(new Ray(bodyPos + dirH * bodyRadius, Vector3.up), realHeigth / tempPercent))
            {
                couldHmove = false;
            }
        }
        //判定纵向
        if (dirV != Vector3.zero && Physics.Raycast(new Ray(bodyPos, dirV),out hit, bodyRadius))
        {
            if(hit.collider.tag!="Walkable"){couldVmove = false;}
            
        }
        else
        {
            if (Physics.Raycast(new Ray(bodyPos + dirV * bodyRadius, Vector3.up), realHeigth / tempPercent))
            {
                couldVmove = false;

            }
        }
        //画线调试
        Debug.DrawLine(bodyPos, dirH * bodyRadius + bodyPos, Color.red);
        Debug.DrawLine(bodyPos, dirV * bodyRadius + bodyPos, Color.red);

        Vector3 temp = bodyPos + dirH * bodyRadius;
        Debug.DrawLine(temp, temp + Vector3.up * realHeigth, Color.red);
        temp = bodyPos + dirV * bodyRadius;
        Debug.DrawLine(temp, temp + Vector3.up * realHeigth, Color.red);


        Vector3 aimPos = _aimPos;
        if (!couldHmove) aimPos.x = transform.position.x;
        if (!couldVmove) aimPos.z = transform.position.z;

        return aimPos;

        //return _aimPos;
    }
}
