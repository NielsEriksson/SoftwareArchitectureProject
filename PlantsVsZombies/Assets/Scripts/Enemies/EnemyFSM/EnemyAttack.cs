using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBaseState
{
    private EnemyAiStateMachine sm;
 
    public EnemyAttack(EnemyAiStateMachine stateMachine) : base("Shoot", stateMachine) { sm = (EnemyAiStateMachine)stateMachine; }
    public override void Enter() {
        sm.enemy.rb.velocity = Vector2.zero;
    }
    public override void Update() 
    {
        sm.enemy.Attack();
    }
    public override void Transition() 
    {
        if(sm.enemy.health <=0)
        {
            sm.ChangeState(sm.dieState);
        }
        if(!sm.enemy.isInRange)
        {
            sm.ChangeState(sm.moveState);
        }
    }
}
