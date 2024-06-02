using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Drivableobject drivableobject;
    public float acceleration = 1f;
    public float rotateSpeed = 1f;
    private float currentSpeed = 0f;

    private Vector3 lastpos ;
    private Vector3 curpos ;
    //private float speed = 0f;
    void Start()
    {
       drivableobject = GetComponent<Drivableobject>();  
       lastpos = this.transform.position;
       curpos = this.transform.position;
       //speed = 0f;
       currentSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //curpos = this.transform.position;//当前点
        //speed = (Vector3.Magnitude(curpos - lastpos) / Time.deltaTime);//与上一个点做计算除去当前帧花的时间。
		//lastpos = curpos;//把当前点保存下一次用
        //print(currentSpeed);

        float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Vertical");
        if(drivableobject.isdriven){
            //this.GetComponent<Rigidbody>().AddForce(10,0,0);
            currentSpeed += acceleration* b * Time.deltaTime;
            currentSpeed -= currentSpeed*0.02f*acceleration*Time.deltaTime;
            transform.Translate(new Vector3(0, 0, 1) * currentSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, a, 0) * rotateSpeed*currentSpeed * Time.deltaTime);
            //transform.Translate(new Vector3(0, 0, 1) * movespeed * Time.deltaTime);
            //transform.Rotate(new Vector3(0, 10, 0) * rotateSpeed * Time.deltaTime);
            }
    }
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag!=Tag.GND){currentSpeed/=1.4f;}
    }
    
}
