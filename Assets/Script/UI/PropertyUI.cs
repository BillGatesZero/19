using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PropertyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static PropertyUI instance{get;private set;}
    private GameObject UIobject;
    private Image mindBar;
    private TextMeshProUGUI mindText;

    private GameObject propertygrid;
    private GameObject propertemplate;

    private PlayerAttribute playerAttribute;

    private void Awake()
    {
        if(instance != null && instance != this){Destroy(this.gameObject);}
        instance = this;
    }
    void Start()
    {
        UIobject = transform.Find("UI").gameObject;
        mindBar = transform.Find("UI/Mind/Bg").GetComponent<Image>();
        mindText= transform.Find("UI/Mind/Text").GetComponent<TextMeshProUGUI>();
        propertygrid = transform.Find("UI/Propertylist").gameObject;
        propertemplate = transform.Find("UI/Propertylist/Propertytemplate").gameObject;
        propertemplate.SetActive(false);
        GameObject Player = GameObject.Find("Player");
        playerAttribute=Player.GetComponent<PlayerAttribute>();
        UpdatePropertyUI();
        Hide();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            if(UIobject.activeSelf){Hide();}else{UpdatePropertyUI();Show();}
        }
    }
    public void UpdatePropertyUI(){
        mindBar.fillAmount = 1-playerAttribute.Mind / 1000f;
        mindText.text = "SAN  " + playerAttribute.Mind + "/1000";
        clear();
        AddProperty("Maths Knowledge: " + playerAttribute.MathsKnowledge);
        AddProperty("Physics Knowledge: " + playerAttribute.PhysicsKnowledge);
    }
    private void clear(){
        foreach (Transform child in propertygrid.transform)
        {
            if (child.gameObject.activeSelf) { Destroy(child.gameObject); }
        }
    }
    private void AddProperty(string name){
        GameObject property = GameObject.Instantiate(propertemplate);
        property.SetActive(true);
        property.transform.SetParent(propertygrid.transform);
        property.transform.GetComponent<TextMeshProUGUI>().text = name;
    }
    public void Show(){UIobject.SetActive(true);}
    public void Hide(){UIobject.SetActive(false);}
}
