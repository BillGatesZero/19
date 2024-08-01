using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPackage : Toolsid
{
    public float goldSpeed = 10f;
    // Start is called before the first frame update
    public GameObject GoldPrefab;
    private GameObject goldGo;
    public Transform trans;
    // Update is called once per frame
    private void Start() {
        if(tag=="Interactable"){
             spawnBullet();
        }
       
    }
    public override void Pay()
    {   
        //print(trans.position);
        goldGo=Instantiate(GoldPrefab, trans.position, trans.rotation);
        goldGo.GetComponent<Rigidbody>().velocity = trans.forward*goldSpeed;
        

}
    private void spawnBullet() {
        goldGo=Instantiate(GoldPrefab, trans.position, trans.rotation);
        goldGo.transform.parent = trans;
        if(tag=="Interactable"){
            Destroy(goldGo.GetComponent<GoldBullet>());
            goldGo.GetComponent<Rigidbody>().useGravity=true;
            goldGo.tag="Interactable";
            PickableObject pickable=goldGo.AddComponent<PickableObject>();
            pickable.itemSO=GetComponent<PickableObject>().itemSO;
            goldGo.transform.parent = null;
            Destroy(this.gameObject);
    }
    }
}