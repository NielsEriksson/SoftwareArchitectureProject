using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : BaseState
{
    float speed;
    private AiStateMachine sm;
    public Evade(AiStateMachine stateMachine) : base("Evade", stateMachine) { sm = (AiStateMachine)stateMachine; }
    public override void Enter()
    {
        speed = 3f;
    }
    public override void Update() 
    {
        sm.AIrb.velocity = (sm.AIrb.transform.position - sm.playerrb.transform.position).normalized * speed ;
    }
    public override void Transition()
    {
        if (Vector2.Distance(sm.AIrb.transform.position, sm.playerrb.transform.position) > 6)
        {
            sm.ChangeState(sm.shootState);
        }

    }
}
