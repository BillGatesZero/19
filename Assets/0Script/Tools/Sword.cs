using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Tools
{
    // Start is called before the first frame update
    public int money = 10;
    private bool isPay = false;

    private void Start(){
        isPay=false;
        isShootingTool = false;
        id=3;
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
        if((other.tag == Tag.ENM)&&isPay){
            other.GetComponent<Enemy>().takeMoney(money);
        }
    }
}
