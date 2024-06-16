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
    private BossSkill currentskill;
    public override void Tick(){
        transform.LookAt(playerTransform);
        UseSkill();

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
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")||animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            foreach(BossSkill skill in enemyManager.BossSkills){
                if(skill.canAttack){
                    animator.SetInteger("SkillAnimationID", skill.AnimationID);
                    currentskill=skill;
                    if(skill.cooltimeLeft <= 0){skill.cooltimeLeft = skill.cooltime;skill.durationLeft = skill.duration;}
                    break;
                    
                }
            }
            
        if(currentskill.cooltimeLeft > 0&&currentskill.durationLeft <= 0){
                    animator.SetInteger("SkillAnimationID", 0);}
            
        }

    }
    
}
