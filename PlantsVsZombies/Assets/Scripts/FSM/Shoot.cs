using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : BaseState
{
    private AiStateMachine sm;
    public float bulletSpeed;
    Vector2 bulletdirection;
    public float shotDelay;
    public Shoot(AiStateMachine stateMachine) : base("Shoot", stateMachine) { sm = (AiStateMachine)stateMachine; }
    public override void Enter() {
        bulletSpeed = 9f;
        shotDelay = 0.75f;
        sm.AIrb.velocity = Vector2.zero;
    }
    public override void Update() 
    {

        if (shotDelay > 0)
        {
            shotDelay -= Time.deltaTime; 
        }
        else
        {
            GameObject bullet = GameObject.Instantiate(sm.bullet, sm.AIrb.position, Quaternion.identity);
            bulletdirection = -(sm.AIrb.transform.position - sm.playerrb.transform.position).normalized;
            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
            brb.velocity = bulletdirection * bulletSpeed;
            shotDelay = 0.75f;
        }
    }
    public override void Transition() 
    {
        if (Vector2.Distance(sm.AIrb.transform.position, sm.playerrb.transform.position) < 6)
        {
            sm.ChangeState(sm.evadeState);
        }
        if (Vector2.Distance(sm.AIrb.transform.position, sm.playerrb.transform.position) > 10)
        {
            sm.ChangeState(sm.idleState);
        }
    }
}
