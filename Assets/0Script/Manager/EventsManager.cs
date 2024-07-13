using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<AutoSeller> OnAutoSell;
    public static event Action<Enemy> OnEnemyDeath;
    // Update is called once per frame
    public static void EnemyDeath(Enemy enemy){
        OnEnemyDeath?.Invoke(enemy);
    }
    public static void AutoSell(AutoSeller autoSeller){
        OnAutoSell?.Invoke(autoSeller);
    }
}
