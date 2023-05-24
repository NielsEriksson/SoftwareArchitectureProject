using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : PlantBaseState
{
    private PlantAiStateMachine sm;
    public float bulletSpeed;
    Vector2 bulletdirection;
    public float shotDelay;
    public PlantAttack(PlantAiStateMachine stateMachine) : base("Attack", stateMachine) { sm = (PlantAiStateMachine)stateMachine; }
    public override void Enter() {
        sm.plant.Attack();
    }
    public override void Update() 
    {
    }
    public override void Transition() 
    {
        if (!sm.plant.isInRange)
        {
            sm.ChangeState(sm.idleState);
        }
        if(sm.plant.health <= 0)
        {
            sm.ChangeState(sm.dieState);
        }
    }
    public override void Exit()
    {
        sm.plant.StopAttack();
    }
}
