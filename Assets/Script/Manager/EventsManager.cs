using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<AutoSeller> OnAutoSell;
    // Update is called once per frame
    public static void AutoSell(AutoSeller autoSeller){
        OnAutoSell?.Invoke(autoSeller);
    }
}
