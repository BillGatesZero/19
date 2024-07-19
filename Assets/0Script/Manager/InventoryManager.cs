using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager instance{get;private set;}
    public List<ItemGroup> itemLs;
    public List<Clothing> clothingLs;
    public ItemGroup CurrentItem;
    private void Awake()
    {
        itemLs=new List<ItemGroup>();
        clothingLs=new List<Clothing>();
        if(instance != null && instance != this){Destroy(this.gameObject);}
        instance = this;
        CurrentItem=null;
    }
    //IEnumerator Start(){
        //yield return new WaitForSeconds(0.5f);
        //AddItem(defaultItem);}
    public void AddItem(ItemSO items){
        Debug.Log("add item "+items.count);
        foreach(ItemGroup itemAs in itemLs){if(itemAs.item.name==items.name){itemAs.count+=items.count;return;}}
        ItemGroup itemGroup=new ItemGroup();
        itemGroup.count=items.count;
        itemGroup.item=items;
        itemLs.Add(itemGroup);
        foreach (ItemGroup item in itemLs){Debug.Log(item.item.name+" "+item.count);}
    }
    public void RemoveItem(ItemGroup item){
        itemLs.Remove(item);
    }
    public void GetCurrentItem(ItemGroup item){
        foreach(ItemGroup itemAs in itemLs){if(itemAs.item.name==item.item.name){CurrentItem=itemAs;return;}}
        
    }
}
