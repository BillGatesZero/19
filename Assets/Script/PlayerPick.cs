using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Interactable"){
            PickableObject pickableObject = collision.gameObject.GetComponent<PickableObject>();
            if(pickableObject != null){
                InventoryManager.instance.AddItem(pickableObject.itemSO);
                Destroy(collision.gameObject);
                
            }
        }
    }
}
