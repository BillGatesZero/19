using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BaseStateType
{
    IdleWait,
    Pursue,
    AttackState,
    ReadyAttack
}
public abstract class BaseState : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Tick();
}
