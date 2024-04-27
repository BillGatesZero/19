using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    //public Dictionary<ItemPropertyType, List<ItemProperty>> propertiDict;
    public int Mind = 500;//0
    public int Luck = 0;//1
    public int Stamina = 0;//2
    public int Confidence = 0;//3
    public int Attraction = 0;//4
    public int LiberalKnowledge = 0;//5
    public int MathsKnowledge = 0;//6
    public int PhysicsKnowledge = 0;//7
    public int ComputerKnowledge = 0;//8
    public int ChemistryKnowledge = 0;//9

    void Start()
    {
        //propertiDict = new Dictionary<ItemPropertyType, List<ItemProperty>>();
        //propertiDict.Add(ItemPropertyType.MindValue, new List<ItemProperty>());
        //propertiDict.Add(ItemPropertyType.LuckValue, new List<ItemProperty>());
        //propertiDict.Add(ItemPropertyType.MoneyValue, new List<ItemProperty>());
        //AddProperty(ItemPropertyType.MindValue, 500);
        //AddProperty(ItemPropertyType.LuckValue, 0);
        //AddProperty(ItemPropertyType.MoneyValue, 0);
    }
    
    //public void AddProperty(ItemPropertyType type, int value){List<ItemProperty> list;
     //   propertiDict.TryGetValue(type, out list);
     //   list.Add(new ItemProperty(type,value));}
    //public void RemoveProperty(ItemPropertyType type, int value){List<ItemProperty> list;
      // propertiDict.TryGetValue(type, out list);
      //  list.Remove(list.Find(x => x.Value == value));}

    public void ChangeAttribute(ItemSO.ItempropertyType type, int value)
    {
        switch (type)
        {
            case ItemSO.ItempropertyType.MindValue: Mind += value; if(Mind > 1000) Mind = 1000; return;
            case ItemSO.ItempropertyType.LuckValue: Luck += value; if(Luck > 1000) Luck = 1000; return;
            case ItemSO.ItempropertyType.StaminaValue: Stamina += value; if(Stamina > 1000) Stamina = 1000; return;
            case ItemSO.ItempropertyType.ConfidenceValue: Confidence += value;if(Confidence > 1000) Confidence = 1000; return;
            case ItemSO.ItempropertyType.AttractionValue: Attraction += value;if(Attraction > 1000) Attraction = 1000; return;
            case ItemSO.ItempropertyType.LiberalKnowledgeValue: LiberalKnowledge += value; return;
            case ItemSO.ItempropertyType.MathsKnowledgeValue: MathsKnowledge += value; return;
            case ItemSO.ItempropertyType.PhysicsKnowledgeValue: PhysicsKnowledge += value; return;
            case ItemSO.ItempropertyType.ComputerKnowledgeValue: ComputerKnowledge += value; return;
            case ItemSO.ItempropertyType.ChemistryKnowledgeValue: ChemistryKnowledge += value; return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
