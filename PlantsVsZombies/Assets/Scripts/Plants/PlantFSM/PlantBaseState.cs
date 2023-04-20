using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBaseState : MonoBehaviour
{
    public string stateName;
    protected PlantBaseStateMachine stateMachine;
    public PlantBaseState(string name, PlantBaseStateMachine stateMachine)
    {
        this.stateName = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Transition() { }
    public virtual void Exit() { }

}
