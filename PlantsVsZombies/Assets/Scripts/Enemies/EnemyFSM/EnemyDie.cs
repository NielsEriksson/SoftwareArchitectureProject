using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyBaseState
{
    private EnemyAiStateMachine sm;

    public EnemyDie(EnemyAiStateMachine stateMachine) : base("Shoot", stateMachine) { sm = (EnemyAiStateMachine)stateMachine; }
    public override void Enter()
    {

    }
    public override void Update()
    {
        sm.enemy.Die();
    }
   
}
