using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carabine : Tools
{
    // Start is called before the first frame update
    
    public int damage=10;
    public float interval=0.3f;
    private float timer=0f;
    public GameObject bullet;
    public GameObject firepoint;
    public GameObject Gunspark;
    void Start()
    {
        id=4;
        isShootingTool=true;
        firepoint=GameObject.Find("Firepoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=0){timer-=Time.deltaTime;}
        if(Input.GetKey(KeyCode.C)&&timer<=0){
            Fire();
            
        }
    }
    public void Fire(){
        timer=interval;
        GameObject obj=Instantiate(bullet,firepoint.transform.position,firepoint.transform.rotation);
        GameObject spark=Instantiate(Gunspark,firepoint.transform.position,firepoint.transform.rotation);
        obj.GetComponent<RifleBullet>().damage=damage;
        //obj.GetComponent<RifleBullet>().firepoint=firepoint;
        print("c");
    }
    
}
