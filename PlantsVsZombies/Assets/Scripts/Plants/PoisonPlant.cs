using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : Plant
{
    public override void Start()
    {
        base.Start();
        if(isUpgraded)
        {
            health *= 2;
        }
    }
    public override void Attack()
    {

    }
    public override void Action()
    {

    }
    public override void Idle()
    {
        base.Idle();
    }
}
