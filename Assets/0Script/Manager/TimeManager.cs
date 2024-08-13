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
    public int weather=0;
    //0 Clear 1 Cloudy 2 Overcast 3 light rain 4 heavy rain 5 typhoon 6 Rainstorm 7 Snowstorm
    public float currenttemperature=300;
    public float lowesttemp=300;
    public Light directLight;
    //最低气温=（基准气温+昨日最低气温)/2+-（350-基准)/10
    public int season=1;
    private float lightStrength;
    private float shadowStrength;
    //0 Early Spring 1 Late Spring 2 early summer 3 late summer 4 fall 5 winter
    public void Awake()
    {
        seconds=0;
        minutes=0;
        hour=10;
        day=1;
        directLight=GameObject.Find("Directional Light").GetComponent<Light>();

    }
    private void FixedUpdate(){
        
    totalseconds+=Time.deltaTime;
    if(totalseconds>=0.009f){
            totalseconds=0;
            seconds++; 
    if(seconds>=60){
        minutes++;//print(year+"-"+month+"-"+day+" "+hour+":"+minutes);
        seconds=0;
        if(minutes>=60){
            minutes=0;
            hour++;
            if(hour>=24){
                hour=0;
                day++;
            }}}
    }}
    public void adjustlight(float intensity, float shadowcast){
        if (intensity!=directLight.intensity){
            if(intensity>directLight.intensity){
                directLight.intensity+=Time.deltaTime;
            }else if(intensity<directLight.intensity){
                directLight.intensity-=Time.deltaTime;
            }
        }

        if (shadowcast!=directLight.shadowStrength){
            if(shadowcast>directLight.shadowStrength){
                directLight.shadowStrength+=Time.deltaTime;
            }else if(shadowcast<directLight.shadowStrength){
                directLight.shadowStrength-=Time.deltaTime;
            }
        }
    }
    public void setlight(float intensity, float shadowcast){
        this.lightStrength=intensity;
        this.shadowStrength=shadowcast;
    }
    public void SetDate(int day){
        this.day=day;
    }



    private float basetemperature=288f;
    public float GenerateLowesttemperature(float previousTemperature){
        basetemperature=(288f+12f*Mathf.Cos((day-78)*2*3.14159265359f/365.25f));
        return (basetemperature+previousTemperature)/2+Random.Range(-1f,1f)*(350f-basetemperature)/10f;
    }
    public void GenerateWeather(){
        weather=Random.Range(0,7);
    }
    public void UpdateWeatherEnvironment(int weatherid){
        switch(weatherid){
        case 0: setlight(0.5f,0.5f);break;
        
        
        }
    }
}
