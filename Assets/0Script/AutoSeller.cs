using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSeller : MonoBehaviour
{
    // Start is called before the first frame update
    public int price=100;
    public int mind=1;
    private int currentprice;
    public void Start(){currentprice=price;}
    public void takeMoney(int money){
        currentprice-=money;
        if(currentprice<=0){Bought();}}
    private void Bought(){//for (int i = 0; i < 2; i++){
         ItemSO item=ItemDBManager.instance.itemDB.items[0];
                print(transform.position);
                GameObject obj=Instantiate(item.Prefab,transform.position+Vector3.up,Quaternion.identity);
                obj.tag="Interactable";
                Animator anim=obj.GetComponent<Animator>();
                if(anim!=null){
                    anim.enabled=false;
                }
                PickableObject pickable=obj.AddComponent<PickableObject>();
                pickable.itemSO=item;
                Collider col=obj.GetComponent<Collider>();
                if(col!=null){
                    col.enabled=true;
                    col.isTrigger=false;
                }
                Rigidbody rb=obj.GetComponent<Rigidbody>();
                if(rb!=null){
                    rb.isKinematic=false;
                    rb.useGravity=true;
                }
            //}
        currentprice=100;
        EventsManager.AutoSell(this);
    }
    void Update(){//if(Input.GetKeyDown(KeyCode.Space)){takeMoney(100);}
    }
    // Update is called once per frame
   
}
