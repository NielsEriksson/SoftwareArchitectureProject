using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAiStateMachine : EnemyBaseStateMachine
{
    [HideInInspector] 
    public EnemyAttack attackState;
    [HideInInspector]
    public Enemy enemy;



    private void Awake()
    {        
        attackState = new EnemyAttack(this);     
    }

    protected override EnemyBaseState GetInitialState()
    {
        return attackState;
    }
}
