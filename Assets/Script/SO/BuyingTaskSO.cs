using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuyingTaskSO : GameTaskSO
{
    public int toolscount=2;
    public int currentcount=0;
    // Start is called before the first frame update
    public override void Starttask()
        {
            currentcount=0;
            state = GameTaskState.InProgress;
            if(start!=null){InventoryManager.instance.AddItem(start);}
            EventsManager.OnAutoSell += OnAutoSell;
        }
    public void OnAutoSell(AutoSeller autoSeller)
        {
            currentcount++;
            if (currentcount >= toolscount){
                state = GameTaskState.Complete;
                Complete();
            }
        }
    public override void Complete()
        {
            //foreach (ItemSO.Itemproperty property in Properties){playerAttribute.ChangeAttribute(property.PropertyType, property.Value);}
            if(end!=null){InventoryManager.instance.AddItem(end);}
            EventsManager.OnAutoSell -= OnAutoSell;
        }
}
