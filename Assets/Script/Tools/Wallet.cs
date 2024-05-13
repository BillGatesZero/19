using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : Tools
{   
    //public const string ANIM_PARM_IS_PAYING = "Atk";
    //private Animator anim;
    public int money = 50;
    private bool isPay = false;

    private void Start(){
        isPay=false;
        //anim = GetComponent<Animator>();
    }
    public override void Pay(){
        //anim.SetTrigger(ANIM_PARM_IS_PAYING);
        isPay = true;
    }
    public override void UnPay(){
        isPay = false;
    }

    private void Update(){
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == Tag.SEL&&isPay){
            other.GetComponent<AutoSeller>().takeMoney(money);
        }
    }
}
