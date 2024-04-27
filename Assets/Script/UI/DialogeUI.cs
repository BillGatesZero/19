using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogeUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Name;
    public TextMeshProUGUI ContentText;
    public List<string> ContentList;
    public Button ContinueButton;
    private int index=0;
    public void Start(){
        
        Name=transform.Find("Name").GetComponent<TextMeshProUGUI>();
        ContentText=transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        ContinueButton=transform.Find("Button").GetComponent<Button>();
        ContinueButton.onClick.AddListener(this.OnClick);
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name, string[] Content){

Name.text = name;
ContentList=new List<string>();
ContentList.AddRange(Content);
ContentText.text=ContentList[0];
gameObject.SetActive(true);
    }
    // Update is called once per frame
    private void Hide(){
        gameObject.SetActive(false);
    }
    public void OnClick(){
        if(index>=ContentList.Count-1){
            Hide();
            index=0;
            return;
        }
        index++;
        ContentText.text=ContentList[index];
        
    }
}
