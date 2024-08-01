using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCobject : InteractableObject
{
    // Start is called before the first frame update
    public string NPCname;
    public string[] contentList;
    public DialogeUI dialogueUI;
    protected override void Interact()
    {
        dialogueUI.Show(NPCname, contentList);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
