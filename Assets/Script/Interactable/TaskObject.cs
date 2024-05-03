using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : InteractableObject
{
    public string Name;
    public GameTaskSO GameTaskso;
    public DialogeUI DialogeUI;
    private PlayerAttribute player;
    public GameObject next;
    private TimeManager timeManager;
    public void Start(){
        GameTaskso.state = GameTaskState.UnStart;
        //playerAttribute=Player.GetComponent<PlayerAttribute>();
        player=GameObject.Find("Player").GetComponent<PlayerAttribute>();
        timeManager=GameObject.Find("ItemDBManager").GetComponent<TimeManager>();
    }
    protected override void Interact()
    {
        if(GameTaskso.state!=GameTaskState.End){
        DialogeUI.Show(Name,GameTaskso.dialogue,OnDialogueEnd);
        print(GameTaskso.state);}
    }
    public void OnDialogueEnd()
    {
        print(GameTaskso.state);
        switch (GameTaskso.state)
        {
            case GameTaskState.UnStart:
                InventoryManager.instance.AddItem(GameTaskso.start);
                GameTaskso.Start();
                break;
            case GameTaskState.InProgress:
                GameTaskso.state = GameTaskState.InProgress;
                break;
        }
    }
    public void Update(){
        if(GameTaskso.state==GameTaskState.Complete){
            player.Taskcomplete(GameTaskso);
            GameTaskso.state = GameTaskState.End;
            next.SetActive(true);
            Destroy(this.gameObject);
            timeManager.SetDate(2014,5,11);
        }
    }
}
