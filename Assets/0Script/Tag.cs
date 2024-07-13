using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Tag
{
    // Start is called before the first frame update
    public const string PLY = "Player";
    public const string SEL = "Seller";
    public const string ITA = "Interactable";
    public const string GND = "Ground";
    public const string TOL = "Tools";
    public const string ENM = "Enemy";
    
}
[Serializable]
public class ItemGroup{
    public ItemSO item;
    public int count;
}
[Serializable]
public class Clothing{
    public int id;
    public string name;
    public Material material;
    public bool isUnlocked;
}