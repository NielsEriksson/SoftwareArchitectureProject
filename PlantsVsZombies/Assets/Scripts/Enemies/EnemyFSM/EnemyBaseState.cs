using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState 
{
    public string name;
    protected EnemyBaseStateMachine stateMachine;
    public EnemyBaseState(string name, EnemyBaseStateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Transition() { }
    public virtual void Exit() { }

}
