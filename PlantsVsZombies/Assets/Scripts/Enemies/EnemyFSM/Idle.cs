using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    private AiStateMachine sm;
    public Idle(AiStateMachine stateMachine) : base("Idle", stateMachine) { sm = (AiStateMachine)stateMachine; }
    public override void Enter() { sm.AIrb.velocity = Vector2.zero; }
    public override void Update() { }
    public override void Transition() 
    {
        if (Vector2.Distance(sm.AIrb.transform.position , sm.playerrb.transform.position) < 6)
        {
            sm.ChangeState(sm.evadeState);
        }
        if (Vector2.Distance(sm.AIrb.transform.position, sm.playerrb.transform.position) < 10)
        {
            sm.ChangeState(sm.shootState);
        }
    }
    
}
