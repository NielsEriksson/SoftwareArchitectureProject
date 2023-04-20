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

    public bool isInRange;

    public Plant plant;
    

    private void Awake()
    {
        idleState = new PlantIdle(this);
        attackState = new PlantAttack(this);
    }

    protected override PlantBaseState GetInitialState()
    {
        return idleState;
    }
}
