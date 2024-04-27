using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
public class ItemUI : MonoBehaviour
{
    //public Image itemimage;
    public TextMeshProUGUI itemtext;
    public TextMeshProUGUI itemType;
    private ItemSO itemSO;
    // Start is called before the first frame update

    // Update is called once per frame
    
    public void initItem(ItemSO itemSO)
    {
        
        string type="";
        switch(itemSO.type){
            case ItemSO.Itemtype.Consumable:
                type="Consumable";break;
            case ItemSO.Itemtype.Tools:
                type="Tools";break;
        }
        itemtext.text = itemSO.name;
        itemType.text = type;
        this.itemSO = itemSO;
    }
    public void OnClick()
    {
       
        if(itemSO!=null){InventoryUI.inventoryUI.OnIClick(itemSO,this);}
    }
}
