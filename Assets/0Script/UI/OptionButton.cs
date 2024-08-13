using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class OptionButton : MonoBehaviour
{
    public TextMeshProUGUI optiontext;
    public int index;
    public DialogeUI dialogueUI;

    // Start is called before the first frame update
    public void initOption(NextDialogue nextDialogue){
        optiontext.text=nextDialogue.Nextword;
        index=nextDialogue.index;
    }

    // Update is called once per frame
    public void OnClick(){
        Debug.Log(index);
        dialogueUI.OnnClick(index);
    }
}
