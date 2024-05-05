using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : InteractableObject
{
    public string Name;
    public List<GameTaskSO> GameTaskso;
    private GameTaskSO CurrentTask;
    public DialogeUI DialogeUI;
    private PlayerAttribute player;
    public GameObject next;
    private TimeManager timeManager;
    public void Start(){
        foreach (GameTaskSO task in GameTaskso){
            task.state = GameTaskState.UnStart;}
            CurrentTask=GameTaskso[0];
        //playerAttribute=Player.GetComponent<PlayerAttribute>();
        player=GameObject.Find("Player").GetComponent<PlayerAttribute>();
        timeManager=GameObject.Find("ItemDBManager").GetComponent<TimeManager>();}
        
    protected override void Interact()
    {   foreach (GameTaskSO task in GameTaskso){
        if(task.state!=GameTaskState.End){
        DialogeUI.Show(Name,task.dialogue,OnDialogueEnd);
        print(task.state);
        break;}}
    }
    public void OnDialogueEnd()
    {
        switch (CurrentTask.state)
        {
            case GameTaskState.UnStart:
                CurrentTask.Starttask();
                break;
            case GameTaskState.InProgress:
                CurrentTask.state = GameTaskState.InProgress;
                break;
        }
    }
    public void Update(){
        CurrentTask.UpdateState();
        if(CurrentTask.state==GameTaskState.Complete){
            player.Taskcomplete(CurrentTask);
            CurrentTask.state = GameTaskState.End;
            print(GameTaskso.IndexOf(CurrentTask));
            foreach (GameTaskSO task in GameTaskso){print(task.state);
                if(task.state!=GameTaskState.End){task.Starttask();CurrentTask=task;return;}}

            next.SetActive(true);
            Destroy(this.gameObject);
            timeManager.SetDate(2014,5,11);}
        
    }
}
