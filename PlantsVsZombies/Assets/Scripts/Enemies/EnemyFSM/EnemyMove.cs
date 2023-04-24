using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyBaseState
{
    private EnemyAiStateMachine sm;

    public EnemyMove(EnemyAiStateMachine stateMachine) : base("Shoot", stateMachine) { sm = (EnemyAiStateMachine)stateMachine; }
    public override void Enter()
    {

    }
    public override void Update()
    {
        sm.enemy.Move();
    }
    public override void Transition()
    {
        if (sm.enemy.health <= 0)
        {
            sm.ChangeState(sm.dieState);
        }
        if (sm.enemy.isInRange)
        {
            sm.ChangeState(sm.attackState);
        }
    }
}
