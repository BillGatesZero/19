using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ItemDBManager instance{ get; private set; }
    public ItemDB itemDB;
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    public ItemSO GetRandomItem(){
        int randomIndex = Random.Range(0, itemDB.items.Count);
        return itemDB.items[randomIndex];
    }
}
