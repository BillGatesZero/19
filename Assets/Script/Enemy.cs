using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health=200;
    public int mind=1;
    public int currentprice;
    public void Start(){currentprice=health;}
    public void takeMoney(int money){
        currentprice-=money;
        if(currentprice<=0){Bought();Destroy(this.gameObject);}}
    private void Bought(){//for (int i = 0; i < 2; i++){

        ItemSO item=ItemDBManager.instance.itemDB.items[1];
                print(transform.position);
                GameObject obj=Instantiate(item.Prefab,transform.position+Vector3.up,Quaternion.identity);
                obj.tag="Interactable";
                Animator anim=obj.GetComponent<Animator>();
                if(anim!=null){anim.enabled=false;}
                PickableObject pickable=obj.AddComponent<PickableObject>();
                pickable.itemSO=item;
                Collider col=obj.GetComponent<Collider>();
                if(col!=null){
                    col.enabled=true;
                    col.isTrigger=false;
                }
                Rigidbody rb=obj.GetComponent<Rigidbody>();
                if(rb==null){rb=obj.AddComponent<Rigidbody>();}
                rb.isKinematic=false;
                rb.useGravity=true;
                
            //}
        EventsManager.EnemyDeath(this);
    }
    void Update(){//if(Input.GetKeyDown(KeyCode.Space)){takeMoney(100);}
    }
    // Update is called once per frame
   
}