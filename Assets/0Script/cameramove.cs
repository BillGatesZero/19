using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public bool isfirst=false;
    void Start(){
        isfirst=false;
        transform.localPosition=new Vector3(0,5f,-8f);
        transform.rotation=Quaternion.Euler(0,0,0);
    }
    void Update()
    {
        float h = 0.04f*Input.GetAxis("Mouse Y");
        //if((transform.localPosition.z>-20f||h<0)&&(transform.localPosition.z<-0.8f||h>0)){
        //transform.Translate(0, h*(transform.localPosition.y-1f), h*transform.localPosition.z*0.5f);
        transform.Rotate(-50f*h, 0, 0);
        //}

        if(Input.GetKeyDown(KeyCode.H)){if(isfirst==false){isfirst=true;transform.localPosition=new Vector3(0,2.3f,0.08f);}
        else{isfirst=false;transform.localPosition=new Vector3(0,5f,-8f);}}
            
        
        //transform.Rotate(5f*h, 0, 0);
    }
}