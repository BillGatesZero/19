using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimeManager instance{get;private set;}
    private float totalseconds=0;
    public int seconds;
    public int minutes;
    public int hour;
    public int day;
    public int month;
    public int year;
    public void Awake()
    {
        seconds=0;
        minutes=0;
        hour=10;
        day=10;
        month=5;
        year=2014;
    }
    private void FixedUpdate(){
        
    totalseconds+=Time.deltaTime;
    if(totalseconds>=0.099f){
            totalseconds=0;
            seconds++; 
    if(seconds>=60){
        minutes++;print(year+"-"+month+"-"+day+" "+hour+":"+minutes);
        seconds=0;
        if(minutes>=60){
            minutes=0;
            hour++;
            if(hour>=24){
                hour=0;
            }
            
        }
        }

    }}
    public void SetDate(int year,int month,int day){
        this.year=year;
        this.month=month;
        this.day=day;
    }
}
