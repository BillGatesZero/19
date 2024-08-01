using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.collider.gameObject.tag == "Interactable"){
            PickableObject pickableObject = hit.collider.gameObject.GetComponent<PickableObject>();
            if(pickableObject != null){
                InventoryManager.instance.AddItem(pickableObject.itemSO);
                Destroy(hit.collider.gameObject);
                
            }
        }
    }
}
