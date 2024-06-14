using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private FSMController fsmController;
    private GameObject enemy;
    private GameObject player;
    private float dist;
    public BaseStateType currentState;
    public List<BossSkill> BossSkills;
    public BaseState IdleWait;
    public BaseState Pursue;
    public BaseState AttackState;
    public BaseState ReadyAttack;
   // public bool isInvulerable; 
   // public bool isSuperArmor; 
    public Animator animator;

    public bool isPreformingAction = false;
    void Start()
    {
        //fsmController = GetComponent<FSMController>();
        //fsmController.SetFloat("Distance", 50f);
        IdleWait = this.GetComponent<IdleWait>();
        Pursue = this.GetComponent<Pursue>();
        AttackState = this.GetComponent<AttackState>();
        ReadyAttack = this.GetComponent<ReadyAttack>();
        currentState = BaseStateType.IdleWait;
        enemy = this.gameObject;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist=Vector3.Distance(player.transform.position, enemy.transform.position);
        //fsmController.SetFloat("Distance",dist);
        //print(dist);
        ChangeStates();
        execute();
    }

    public void ChangeStates()
    {
        switch (currentState)
        {
            case BaseStateType.IdleWait:
                if(dist < 20f){SwitchState(BaseStateType.Pursue);}
                break;
            case BaseStateType.Pursue:
                if(dist > 30f){SwitchState(BaseStateType.IdleWait);}

                break;
            default:
                break;
        }}
    public void SwitchState(BaseStateType newState){
        switch(currentState){
            case BaseStateType.IdleWait: IdleWait.OnExit();break;
            case BaseStateType.Pursue: Pursue.OnExit();break;
            case BaseStateType.AttackState: AttackState.OnExit();break;
            case BaseStateType.ReadyAttack: ReadyAttack.OnExit();break;
            default:
                break;}
        currentState = newState;
        switch(currentState){
            case BaseStateType.IdleWait: IdleWait.OnEnter();break;
            case BaseStateType.Pursue: Pursue.OnEnter();break;
            case BaseStateType.AttackState: AttackState.OnEnter();break;
            case BaseStateType.ReadyAttack: ReadyAttack.OnEnter();break;
            default:
                break;
        }
    }
    public void execute(){
        switch(currentState){
            case BaseStateType.IdleWait: IdleWait.Tick();break;
            case BaseStateType.Pursue: Pursue.Tick();break;
            case BaseStateType.AttackState: AttackState.Tick();break;
            case BaseStateType.ReadyAttack: ReadyAttack.Tick();break;
            default:break;

    }
}
}
