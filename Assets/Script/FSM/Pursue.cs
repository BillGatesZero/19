using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Pursue : BaseState
{
    private GameObject player;
    private GameObject enemy;
    private NavMeshAgent agent;
    public Animator animator;
    public override void OnEnter()
    {
        player = GameObject.Find("Player");
        enemy = gameObject;
        agent = enemy.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }
    public override void Tick(){
        agent.stoppingDistance = 2f;
        agent.SetDestination(player.transform.position);
        if(agent.remainingDistance >= agent.stoppingDistance){
            animator.SetBool("Run",true);}
        else{
            animator.SetBool("Run",false);
        }
    }

    

    public override void OnExit()
    {animator.SetBool("Run",false);}
    
}
