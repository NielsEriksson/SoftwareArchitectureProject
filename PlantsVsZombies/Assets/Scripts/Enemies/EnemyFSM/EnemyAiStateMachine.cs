using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAiStateMachine : EnemyBaseStateMachine
{
    [HideInInspector] 
    public EnemyAttack attackState;
    public EnemyMove moveState;
    public EnemyDie dieState;
    [HideInInspector]
    public Enemy enemy;



    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();
        moveState = new EnemyMove(this);
        attackState = new EnemyAttack(this);   
        dieState = new EnemyDie(this);
    }

    protected override EnemyBaseState GetInitialState()
    {
        return moveState;
    }
}
