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
        
    }
    public override void Update() 
    {
        sm.plant.Attack();
    }
    public override void Transition() 
    {
        sm.ChangeState(sm.idleState);  
    }
}
