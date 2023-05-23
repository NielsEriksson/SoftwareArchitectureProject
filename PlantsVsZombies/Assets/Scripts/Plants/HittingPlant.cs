using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingPlant : Plant
{
    [SerializeField] GameObject hitArea;
    public override void Start()
    {
        base.Start();
    }
    public override void Attack()
    {
        base.Attack();
        GameObject instantiation = Instantiate(hitArea, transform.position + new Vector3(1, 0, 0), Quaternion.identity);

        if (isUpgraded)
        {
            Vector3 baseScale = hitArea.transform.localScale;
            instantiation.transform.localScale = new Vector3(baseScale.x, baseScale.y * 3, baseScale.z);
        }

        StartCoroutine(Hit());
    }

    public IEnumerator Hit()
    {
        while (true)
        {
            PlantHit ph = hitArea.GetComponent<PlantHit>();
            ph.DealDamageToEachEnemy();

        }
    }

    public override void StopAttack()
    {
        StopAllCoroutines();
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
