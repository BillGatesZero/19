using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
public class ItemDetailUI : MonoBehaviour
{
    public TextMeshProUGUI description;
    public GameObject PropertyGrid;
    public GameObject ProperT;
    private ItemUI itemUI;
    private ItemGroup items;
    private GameObject Player;
    // Start is called before the first frame update
    public void Start()
    {
        ProperT.SetActive(false);
        this.gameObject.SetActive(false);
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void UpdateItemDetailUI(ItemGroup itemGroup,ItemUI itemUI)
    {
        this.items = itemGroup;
        this.itemUI = itemUI;
        this.gameObject.SetActive(true);
        description.text = items.item.Description;
        foreach (Transform child in PropertyGrid.transform){if(child.gameObject.activeSelf){Destroy(child.gameObject);}}
        //foreach (Transform child in PropertyGrid.transform){Destroy(child.gameObject);}
        foreach (ItemSO.Itemproperty itemproperty in items.item.Properties)
        {
            string property=" " ;
            string propertyStr=" " ;
            switch (itemproperty.PropertyType)
            {
                case ItemSO.ItempropertyType.MindValue:
                    propertyStr = "SAN";
                    break;
                case ItemSO.ItempropertyType.LuckValue:
                    propertyStr = "LUCK";
                    break; 
                case ItemSO.ItempropertyType.MoneyValue:
                    propertyStr = "MONEY";
                    break;
            }
            property+=propertyStr;
            property+=itemproperty.Value;
            GameObject GO=Instantiate(ProperT);
            GO.transform.SetParent(PropertyGrid.transform);
            
            //GO.transform.Find("PropertyType").GetComponent<TextMeshProUGUI>().text = property;
            GO.SetActive(true);
            //GameObject property = Instantiate(ProperT, PropertyGrid.transform);
            //property.transform.Find("PropertyType").GetComponent<TextMeshProUGUI>().text = itemproperty.PropertyType.ToString();

    }
    
}
    public void OnUseButtonClick(){
        
        InventoryUI.inventoryUI.OnItemUse(items,itemUI);
        this.gameObject.SetActive(false);
    }
}
