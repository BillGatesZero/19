using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerAttack playerAttack;
    private PlayerAttribute playerAttribute;
    public void Start(){playerAttack=GetComponent<PlayerAttack>();
        playerAttribute=GetComponent<PlayerAttribute>();}
    public void UseItem(ItemSO itemSO){
        switch(itemSO.type){
            case ItemSO.Itemtype.Tools:
                playerAttack.LoadTool(itemSO);
                break;
            case ItemSO.Itemtype.Consumable:
                playerAttribute.UseConsumable(itemSO);
                break;
        }
        
    }
}
