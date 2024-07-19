using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryUI inventoryUI{get;private set;}
    private GameObject inventory;
    private GameObject content;
    public GameObject itemPrefab;
    private bool isshow=false;
    public ItemDetailUI itemDTUI;
    private InventoryManager inventoryManager;
    public ItemGroup CurrentItem;
    void Awake()
    {
        if(inventoryUI!=null && inventoryUI!=this){Destroy(this.gameObject);
        }
        inventoryUI=this;
        CurrentItem=null;
    }
    void Start()
    {
        inventoryManager=GameObject.Find("ItemDBManager").GetComponent<InventoryManager>();
        inventory=transform.Find("UI").gameObject;
        content=transform.Find("UI/Bg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }
    // Update is called once per frame
    public void Show(){
        foreach (ItemGroup item in inventoryManager.itemLs){AddItemtoUI(item);}
        inventory.SetActive(true);}
    public void Hide(){
        for(int i = 0;i < content.transform.childCount; i++)
            {
                
                Destroy(content.transform.GetChild(i).gameObject);
            }
        inventory.SetActive(false);}
    public void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            
            if(isshow){
                Hide();
                isshow=false;
            }else{
                Show();
                isshow=true;
            }
        }
    }
    public void AddItemtoUI(ItemGroup itemGroup){

        
        GameObject itemGo= GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(content.transform);
        ItemUI itemUI=itemGo.GetComponent<ItemUI>();
        itemUI.initItem(itemGroup);
    }
    public void OnIClick(ItemGroup items,ItemUI itemUI){itemDTUI.UpdateItemDetailUI(items,itemUI);}
    public void OnItemUse(ItemGroup items,ItemUI itemUI){
        if(!GameObject.FindGameObjectWithTag("Player").GetComponent<Playermove>().isaiming){//&&GameObject.Find("Player").GetComponent<Inventory>())
        if(items.item.type==ItemSO.Itemtype.Consumable){
            itemUI.itemcount.text = (int.Parse(itemUI.itemcount.text) - 1).ToString();
            items.count--;
            if(items.count<=0){Destroy(itemUI.gameObject);}}
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UseItem(items.item);
        //player.GetComponent<Player>().UseItem(itemSO);
        if(items.item.type==ItemSO.Itemtype.Consumable){InventoryManager.instance.RemoveItem(items);}
        if(items.item.type==ItemSO.Itemtype.Tools){inventoryManager.GetCurrentItem(items);}
        
    }}
}
