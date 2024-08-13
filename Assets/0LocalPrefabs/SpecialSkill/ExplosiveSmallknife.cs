using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSmallknife : MonoBehaviour
{
    public GameObject explosion;
    public int damage = 10;
    private Transform Explodepoint;
    // Start is called before the first frame update
    void Start()
    {
        this.Explodepoint = transform.Find("Explodepoint");
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision colli)
    {
        if(colli.gameObject.tag == "Player"){
            colli.gameObject.GetComponent<PlayerAttribute>().ChangeAttribute(ItemSO.ItempropertyType.MindValue, -this.damage);
            GameObject.Instantiate(explosion, this.Explodepoint.position, this.Explodepoint.rotation);
            Destroy(this.gameObject);
        }else if(colli.gameObject.tag == "Ground"){
            GameObject.Instantiate(explosion, this.Explodepoint.position, this.Explodepoint.rotation);
            Destroy(this.gameObject);
        }
    }
}
