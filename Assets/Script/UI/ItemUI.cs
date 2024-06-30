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
    public TextMeshProUGUI itemcount;
    private ItemSO itemSO;
    private ItemGroup itemGroup;
    // Start is called before the first frame update

    // Update is called once per frame
    
    public void initItem(ItemGroup itemGroup)
    {
        string type="";
        switch(itemGroup.item.type){
            case ItemSO.Itemtype.Consumable:
                type="Consumable";break;
            case ItemSO.Itemtype.Tools:
                type="Tools";break;
        }
        itemtext.text = itemGroup.item.name;
        itemType.text = type;
        itemcount.text = itemGroup.count.ToString();
        this.itemSO = itemGroup.item;
        this.itemGroup = itemGroup;
    }
    public void OnClick()
    {
       
        if(itemSO!=null){InventoryUI.inventoryUI.OnIClick(itemGroup,this);}
    }
}
