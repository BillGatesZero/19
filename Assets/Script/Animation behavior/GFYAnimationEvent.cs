using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFYAnimationEvent : MonoBehaviour
{
    public Animator animator;
    public GameObject prefab;
    public GameObject firepoint;
    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        firepoint = GameObject.Find("Firepoint");
    }

    // Update is called once per frame
    public void Cast(){
        GameObject.Instantiate(prefab, firepoint.transform.position, firepoint.transform.rotation);
    }
}
