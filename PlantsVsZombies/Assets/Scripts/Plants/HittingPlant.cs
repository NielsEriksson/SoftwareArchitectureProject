using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingPlant : Plant
{
    [SerializeField] GameObject pushBackArea;
    public override void Attack()
    {
        base.Attack();
        Instantiate(pushBackArea, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
    }
    public override void StopAttack()
    {
        
    }
    public override void Action()
    {
        //throw new System.NotImplementedException();
    }
    public override void Idle()
    {
        base.Idle();
    }
}
