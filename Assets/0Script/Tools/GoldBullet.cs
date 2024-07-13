using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBullet : MonoBehaviour
{
    public int money=50;
    private Rigidbody rb;
    private Collider col;
    private void Start(){
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        if(tag!="Interactable"){Destroy(gameObject, 10f);}
    }
    private void OnCollisionEnter(Collision colli){
        if(colli.collider.tag == "Player"){return;
            
        }
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        col.enabled = false;
        transform.parent = colli.collider.transform;
        Destroy(gameObject, 0.5f);
        if(colli.gameObject.tag == "Seller"){

            colli.gameObject.GetComponent<AutoSeller>().takeMoney(money);
        }
    }
    // Start is called before the first frame update
}
