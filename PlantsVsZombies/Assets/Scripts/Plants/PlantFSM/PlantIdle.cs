using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIdle : PlantBaseState
{
    private PlantAiStateMachine sm;
    public PlantIdle(PlantAiStateMachine stateMachine) : base("Idle", stateMachine) { sm = (PlantAiStateMachine)stateMachine; }
    public override void Enter() { }
    public override void Update()
    {
        sm.plant.Idle();
    }
    public override void Transition()
    {
        Debug.Log("PlantIdle Transition");
        if (sm.plant.isInRange)
        {
            sm.ChangeState(sm.attackState);
        }
    }
}
