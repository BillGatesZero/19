using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager instance{get;private set;}
    
    private void Awake()
    {
        if(instance != null && instance != this){Destroy(this.gameObject);}
        instance = this;
    }
    //IEnumerator Start(){
        //yield return new WaitForSeconds(0.5f);
        //AddItem(defaultItem);}
    public List<ItemSO> itemLs = new List<ItemSO>();
    public void AddItem(ItemSO item){
        itemLs.Add(item);
        InventoryUI.inventoryUI.AddItem(item);
    }
    public void RemoveItem(ItemSO item){
        itemLs.Remove(item);
    }
}
