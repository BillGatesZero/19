using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : Tools
{   
    public const string ANIM_PARM_IS_PAYING = "Atk";
    private Animator anim;
    private void Start(){
        anim = GetComponent<Animator>();
    }
    public override void Pay(){
        anim.SetTrigger(ANIM_PARM_IS_PAYING);
    }
    private void Update(){
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Seller"){
        print("Pay");
        }
    }
}
