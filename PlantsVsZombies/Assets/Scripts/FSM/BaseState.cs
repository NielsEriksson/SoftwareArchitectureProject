using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{
    public string name;
    protected BaseStateMachine stateMachine;
    public BaseState(string name, BaseStateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Transition() { }
    public virtual void Exit() { }

}
