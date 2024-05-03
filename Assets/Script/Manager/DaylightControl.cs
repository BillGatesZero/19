using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightControl : MonoBehaviour
{
    private TimeManager timeManager;
    public void Start()
    {
        timeManager = GameObject.Find("ItemDBManager").GetComponent<TimeManager>();
    }
    public void Update(){
        float a=(15f*timeManager.hour+0.25f*timeManager.minutes+timeManager.seconds/240f-90);
        gameObject.transform.rotation=Quaternion.Euler(a,90,0);
    }
}
