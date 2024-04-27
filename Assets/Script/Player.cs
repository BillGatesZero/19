using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerAttack playerAttack;
    public void Start(){playerAttack=GetComponent<PlayerAttack>();}
    public void UseItem(ItemSO itemSO){
        switch(itemSO.type){
            case ItemSO.Itemtype.Tools:
                playerAttack.LoadTool(itemSO);
                break;
            case ItemSO.Itemtype.Consumable:
                break;
        }
        
    }
}
