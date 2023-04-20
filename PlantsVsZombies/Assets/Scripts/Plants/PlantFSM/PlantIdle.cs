using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIdle : PlantBaseState
{
    private PlantAiStateMachine sm;
    public PlantIdle(PlantAiStateMachine stateMachine) : base("Idle", stateMachine) { sm = (PlantAiStateMachine)stateMachine; }
    public override void Enter() { }
    public override void Update()
    {
        sm.plant.Idle();
    }
    public override void Transition()
    {
        if (sm.isInRange)
        {
            sm.ChangeState(sm.attackState);
            sm.isInRange = false;
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLIDING!!!!");
        if (other.gameObject.tag == "Enemy")
        {
            sm.isInRange = true;
            //Physics2D.BoxCast
        }
    }
}
