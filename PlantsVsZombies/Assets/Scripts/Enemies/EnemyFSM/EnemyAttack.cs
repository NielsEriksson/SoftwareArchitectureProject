using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBaseState
{
    private EnemyAiStateMachine sm;
 
    public EnemyAttack(EnemyAiStateMachine stateMachine) : base("Shoot", stateMachine) { sm = (EnemyAiStateMachine)stateMachine; }
    public override void Enter() {

    }
    public override void Update() 
    {


    }
    public override void Transition() 
    {
  
    }
}
