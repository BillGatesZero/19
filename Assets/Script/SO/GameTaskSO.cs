using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//public class GameTask : MonoBehaviour{
    // Start is called before the first frame update
    public enum GameTaskState
    {
        UnStart,
        InProgress,
        Complete,
        End
    }
    [CreateAssetMenu()]
    public class GameTaskSO : ScriptableObject
    {
        public GameTaskState state;
        public string[] dialogue;
        public ItemSO start;
        public ItemSO end;
        public List<ItemSO.Itemproperty> Properties;
        public int toolscount=2;
        public int currentcount=0;
        
        public void Start()
        {
            currentcount=0;
            state = GameTaskState.InProgress;
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
        public void Complete()
        {
            //foreach (ItemSO.Itemproperty property in Properties){playerAttribute.ChangeAttribute(property.PropertyType, property.Value);}
            if(end!=null){InventoryManager.instance.AddItem(end);}
            EventsManager.OnAutoSell -= OnAutoSell;
        }
    }
   // }
