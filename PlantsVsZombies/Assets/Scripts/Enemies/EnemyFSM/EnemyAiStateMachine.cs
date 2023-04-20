using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAiStateMachine : EnemyBaseStateMachine
{
    [HideInInspector] 
    public Attack attackState;
    [HideInInspector]
    public Rigidbody2D AIrb;
    public Rigidbody2D playerrb;
    public GameObject bullet;



    private void Awake()
    {
        Debug.Log(Vector2.Distance(AIrb.position, playerrb.position));
   
        attackState = new Attack(this);
     
    }

    protected override EnemyBaseState GetInitialState()
    {
        return attackState;
    }
}
