using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    // Start is called before the first frame update
  
    private Rigidbody rb;
    private Collider col;
    public GameObject Explosion;
    private void Start(){
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        if(tag!="Interactable"){Destroy(gameObject, 6f);}
        rb.useGravity = false;
        rb.velocity = transform.forward * 33f;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision colli){
        if(colli.collider.tag != "Enemy"){
            Explode();
    }}
    private void Explode(){
        GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        col.enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
