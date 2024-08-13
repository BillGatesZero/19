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

    public class GameTaskSO : ScriptableObject
    {
        public GameTaskState state;
        public InteractiveDialogueList dialogue;
        public ItemSO start;
        public ItemSO end;
        public List<ItemSO.Itemproperty> Properties;
        public bool isfail;
        public virtual void Starttask(){state = GameTaskState.InProgress;
        if(start!=null){InventoryManager.instance.AddItem(start);
        isfail=false;}}
        public virtual void UpdateState(){}
        public virtual void Fail(){isfail=true;
            state = GameTaskState.UnStart;}

        public virtual void Complete()
        {
            state = GameTaskState.Complete;
            //foreach (ItemSO.Itemproperty property in Properties){playerAttribute.ChangeAttribute(property.PropertyType, property.Value);}
            if(end!=null){InventoryManager.instance.AddItem(end);}
        }
    }
   // }
