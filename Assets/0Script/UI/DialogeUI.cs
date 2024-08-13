using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class DialogeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Name;//name
    public TextMeshProUGUI ContentText;//content of this sentence
    public InteractiveDialogueList ContentList;//content of this dialogue
    public GameObject ContinueButton;//continue button set
    public GameObject OptionButton;
    private int currentindex=0;
    private Action onDialogueEnd;
    public void Start(){
        
        Name=transform.Find("Name").GetComponent<TextMeshProUGUI>();
        ContentText=transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        ContinueButton=transform.Find("Options").gameObject;
        //ContinueButton.onClick.AddListener(this.OnClick);
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name, InteractiveDialogueList Content,Action onDialogueEnd=null){
        this.ContentList=Content;
        Name.text = name;
//ContentList=new List<string>();
//ContentList.AddRange(Content);
        ContentText.text=ContentList.dialogueList[0].word;
        gameObject.SetActive(true);
        this.onDialogueEnd=onDialogueEnd;
        AddOption(ContentList.dialogueList[0]);
    }
    public void AddOption(InteractiveDialogue dialogue){
        clearOption();
        if(dialogue.NextDialogueList.Count<=0){
            
            GameObject optionButton = Instantiate(OptionButton);
            optionButton.transform.SetParent(ContinueButton.transform);
            optionButton.GetComponent<OptionButton>().dialogueUI=this;
            optionButton.GetComponent<OptionButton>().optiontext.text="End";
            optionButton.GetComponent<OptionButton>().index=-1;
        }else{
        for (int i = 0; i < dialogue.NextDialogueList.Count; i++){
            GameObject optionButton = Instantiate(OptionButton);
            optionButton.transform.SetParent(ContinueButton.transform);
            optionButton.GetComponent<OptionButton>().dialogueUI=this;
            optionButton.GetComponent<OptionButton>().initOption(dialogue.NextDialogueList[i]);
        }}
    }
    public void clearOption(){
        for(int i=0;i<ContinueButton.transform.childCount;i++){
            
            Destroy(ContinueButton.transform.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    private void Hide(){
        gameObject.SetActive(false);
    }
    public void OnnClick(int index){
        next(index);
        
    }
    public void next(int index){
        print("next "+index);
        if(index>=ContentList.dialogueList.Count||index<0){
            Hide();
            index=0;
            onDialogueEnd?.Invoke();
            return;
        }
        currentindex=index;
        ContentText.text=ContentList.dialogueList[currentindex].word;
        AddOption(ContentList.dialogueList[currentindex]);
    }
}
