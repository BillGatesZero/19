using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public int damage=10;
    public float speed=100f;
    public GameObject Gunspark;
    //public GameObject firepoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(tag!="Interactable"){Destroy(gameObject, 3f);}
        rb.useGravity = false;
        
        
        rb.velocity = this.transform.right*(-1) * speed;
        //this.transform.rotation = firepoint.transform.rotation;
        
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision colli){
        if(colli.collider.tag == "Enemy"){
            colli.gameObject.GetComponent<Enemy>().takeMoney(damage);
        }
        GameObject spark=Instantiate(Gunspark,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
