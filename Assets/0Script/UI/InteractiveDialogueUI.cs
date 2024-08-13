using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public class NextDialogue{
    public int index;
    public string Nextword;
}
[Serializable]
public class InteractiveDialogue{
    public string option;
    public string word;
    public List<NextDialogue> NextDialogueList;
}
[Serializable]
public class InteractiveDialogueList{
    public List<InteractiveDialogue> dialogueList;
}
public class InteractiveDialogueUI : MonoBehaviour
{
    // Start is called before the first frame update
    public InteractiveDialogueList dialogueList;
    public InteractiveDialogue currentDialogue;
    public Action onDialogueEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
