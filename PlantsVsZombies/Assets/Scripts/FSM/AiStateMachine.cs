using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AiStateMachine : BaseStateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Shoot shootState;
    [HideInInspector]
    public Evade evadeState;
    public Rigidbody2D AIrb;
    public Rigidbody2D playerrb;
    public GameObject bullet;



    private void Awake()
    {
        Debug.Log(Vector2.Distance(AIrb.position, playerrb.position));
        idleState = new Idle(this);
        shootState = new Shoot(this);
        evadeState = new Evade(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
