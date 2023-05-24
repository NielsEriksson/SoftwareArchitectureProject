using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingPlant : Plant
{
    [SerializeField] GameObject hitArea;
    [SerializeField] float hitTime;
    private PlantHit plantHit;

    public override void Start()
    {
        base.Start();
    }
    public override void Attack()
    {
        base.Attack();
        GameObject instantiation = Instantiate(hitArea, transform.position + new Vector3(1, 0, 0), Quaternion.identity, transform);

        if (isUpgraded)
        {
            Vector3 baseScale = hitArea.transform.localScale;
            instantiation.transform.localScale = new Vector3(baseScale.x, baseScale.y * 3, baseScale.z);
        }

        plantHit = hitArea.GetComponent<PlantHit>();
    }

    public override void StopAttack()
    {
    }
    public override void Action()
    {
    }
    public override void Idle()
    {
        base.Idle();
    }
    public override void Die()
    {
        base.Die();
    }
}
