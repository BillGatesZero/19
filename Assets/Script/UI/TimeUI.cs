using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TimeUI : MonoBehaviour
{
    private TimeManager timeManager;
    private TextMeshProUGUI timeText;
    //private string seconds;
    private string minutes;
    private string hour;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("ItemDBManager").GetComponent<TimeManager>(); 
        timeText = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeManager.hour<10){hour="0"+timeManager.hour;}else{hour=timeManager.hour.ToString();}
        if(timeManager.minutes<10){minutes="0"+timeManager.minutes;}else{minutes=timeManager.minutes.ToString();}
        //if(timeManager.seconds<10){seconds="0"+timeManager.seconds;}else{seconds=timeManager.seconds.ToString();}
        timeText.text=hour+":"+minutes;
    }
}
