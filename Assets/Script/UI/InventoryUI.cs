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
    void Awake()
    {
        if(inventoryUI!=null && inventoryUI!=this){Destroy(this.gameObject);
        }
        inventoryUI=this;
        
    }
    void Start()
    {
        inventory=transform.Find("UI").gameObject;
        content=transform.Find("UI/Bg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }
    // Update is called once per frame
    public void Show(){inventory.SetActive(true);}
    public void Hide(){inventory.SetActive(false);}
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
    public void AddItem(ItemSO itemSO){

    
        GameObject itemGo= GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(content.transform);
        ItemUI itemUI=itemGo.GetComponent<ItemUI>();
        itemUI.initItem(itemSO);
    }
    public void OnIClick(ItemSO itemSO,ItemUI itemUI){itemDTUI.UpdateItemDetailUI(itemSO,itemUI);}
    public void OnItemUse(ItemSO itemSO,ItemUI itemUI){
        Destroy(itemUI.gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UseItem(itemSO);
        //player.GetComponent<Player>().UseItem(itemSO);
        InventoryManager.instance.RemoveItem(itemSO);
        
        
    }
}
