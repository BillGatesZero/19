using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private FSMController fsmController;
    private GameObject enemy;
    public GameObject player;
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
        animator.SetInteger("SkillAnimationID", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist=Vector3.Distance(player.transform.position, enemy.transform.position);
        //fsmController.SetFloat("Distance",dist);
        //print(dist);
        UpdateSkills();
        ChangeStates();
        execute();
    }

    public void ChangeStates()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")||animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
        switch (currentState)
        {
            case BaseStateType.IdleWait:
                if(dist < 20f){SwitchState(BaseStateType.Pursue);}
                break;
            case BaseStateType.Pursue:
                if(dist > 30f){SwitchState(BaseStateType.IdleWait);}
                if(dist < 2f||(dist < 10f&&dist>=2f&&BossSkills[0].canAttack)){SwitchState(BaseStateType.AttackState);}
                break;
            case BaseStateType.AttackState:
                if(dist >= 10f||(dist < 10f&&dist>=2f&&!BossSkills[0].canAttack)){SwitchState(BaseStateType.Pursue);}
                break;
            default:
                break;
        }}}
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

    public void UpdateSkills()
    {

        foreach (BossSkill skill in BossSkills){
            if(skill.cooltimeLeft > 0){skill.cooltimeLeft -= Time.deltaTime;}
            if(skill.durationLeft > 0){skill.durationLeft -= Time.deltaTime;}
            if ((skill.cooltimeLeft <= 0&&dist < skill.Distance)||(skill.durationLeft > 0)){skill.canAttack = true;}
            else{skill.canAttack = false;}}
    }
}
