using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackState : BaseState
{
    // Start is called before the first frame update
    private EnemyManager enemyManager;
    private Transform playerTransform;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
    public BossSkill currentskill;
    public List<BossSkill> availableSkills;
    public override void Tick(){
        transform.LookAt(playerTransform);
        UseSkill();
        //availableSkills = new List<BossSkill>();
        
        }
        

    public override void OnEnter()
    {
        enemyManager=GetComponent<EnemyManager>();
        playerTransform=enemyManager.player.transform;
        transform.LookAt(playerTransform);
        animator = GetComponent<Animator>();
        animator.SetBool("Run",false);
        agent=GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.stoppingDistance = 20f;
    }

    public override void OnExit()
    {animator.SetInteger("SkillAnimationID", 0);}
    private void UseSkill(){
        //if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")||animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            availableSkills.Clear();
            foreach(BossSkill skill in enemyManager.BossSkills){
                if(skill.canAttack){availableSkills.Add(skill);
                if(availableSkills.Count!=0){print(availableSkills.Count);}}
                if(skill.canAttack){
                    animator.SetInteger("SkillAnimationID", skill.AnimationID);
                    currentskill=skill;
                    if(skill.cooltimeLeft <= 0){skill.cooltimeLeft = skill.cooltime;}
                    if(skill.durationLeft <= 0){skill.durationLeft = skill.duration;}
                    currentskill.attacking = true;
                    break;
                    
                }
            }
            if(currentskill!=null){
                if(currentskill.attacking){
                    animator.SetInteger("SkillAnimationID", currentskill.AnimationID);
                }else{animator.SetInteger("SkillAnimationID", 0);
                currentskill.attacking = false;
                currentskill=null;}

            }

               
            
        //}

    }
    
}
