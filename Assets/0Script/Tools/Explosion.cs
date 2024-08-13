using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public void Start(){
        Destroy(gameObject, 1f);
    }
    // Update is called once per frame
    
    public void OnTriggerEnter(Collider colli){
        if(colli.gameObject.tag == "Player"){colli.gameObject.GetComponent<PlayerAttribute>().ChangeAttribute(ItemSO.ItempropertyType.MindValue,-damage);}
    }
}
