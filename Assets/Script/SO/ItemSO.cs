using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    // Start is called before the first frame update
    public int ID;
    public string Name;
    public Itemtype type;
    public string Description;
    public List<Itemproperty> Properties;
    public Sprite Image;
    public GameObject Prefab;
    public int count=1;//counting
    // Update is called once per frame
    public enum Itemtype{
        Tools,
        Consumable

    }
    [Serializable]
    public class Itemproperty{
        public ItempropertyType PropertyType;
        public int Value;
        public void ItemProperty()
        {
        }
        public void ItemProperty(ItempropertyType type,int value){
            this.PropertyType=type;
            this.Value=value;
        }
        
    }
    public enum ItempropertyType{
        MoneyValue,
        MindValue,
        LuckValue,
        StaminaValue,
        ConfidenceValue,
        AttractionValue,
        LiberalKnowledgeValue,
        MathsKnowledgeValue,
        PhysicsKnowledgeValue,
        ComputerKnowledgeValue,
        ChemistryKnowledgeValue
    }
}
