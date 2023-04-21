using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDie : PlantBaseState
{
    private PlantAiStateMachine sm;
    public PlantDie(PlantAiStateMachine stateMachine) : base("Die", stateMachine) { sm = (PlantAiStateMachine)stateMachine; }
    public override void Enter()
    {

    }
    public override void Update()
    {
        sm.plant.Die();
    }
    public override void Transition()
    {
        //sm.ChangeState(sm.idleState);
    }
}
