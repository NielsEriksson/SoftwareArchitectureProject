using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingPlant : Plant
{
    [SerializeField] GameObject pushBackArea;
    public override void Start()
    {
        base.Start();
    }
    public override void Attack()
    {
        base.Attack();
        GameObject instantiation = Instantiate(pushBackArea, transform.position + new Vector3(1, 0, 0), Quaternion.identity);

        if (isUpgraded)
        {
            Vector3 baseScale = pushBackArea.transform.localScale;
            instantiation.transform.localScale = new Vector3(baseScale.x, baseScale.y * 3, baseScale.z);
        }
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
