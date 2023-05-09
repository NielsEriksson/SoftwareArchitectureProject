using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSpreaderPlant : Plant
{
    [SerializeField] GameObject vine;
    public override void Attack()
    {
        Instantiate(vine, transform.position + new Vector3(1, 0, 0), vine.transform.rotation);
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
        
    }
}
