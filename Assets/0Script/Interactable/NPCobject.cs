using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCobject : InteractableObject
{
    // Start is called before the first frame update
    public string NPCname;
    public ComplexDialogueSO dialogue;
    public int index = 0;
    public DialogeUI dialogueUI;
    protected override void Interact()
    {
        dialogueUI.Show(NPCname, dialogue.dialogueList[index]);
    }
    public void SetIndex(int i){index=i;}
    // Update is called once per frame
    void Update()
    {
        
    }
}
