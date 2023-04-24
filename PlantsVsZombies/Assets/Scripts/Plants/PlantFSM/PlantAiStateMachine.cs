using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantAiStateMachine : PlantBaseStateMachine
{
    [HideInInspector]
    public PlantIdle idleState;
    [HideInInspector]
    public PlantAttack attackState;
    [HideInInspector]
    public PlantDie dieState;

    public bool isInRange;

    public Plant plant;
    

    private void Awake()
    {
        idleState = new PlantIdle(this);
        attackState = new PlantAttack(this);
        dieState = new PlantDie(this);
    }

    protected override PlantBaseState GetInitialState()
    {
        return idleState;
    }
}
