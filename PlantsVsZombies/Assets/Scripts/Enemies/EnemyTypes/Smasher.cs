using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
       
        base.Start();
    }

    // Update is called once per frame
    public override void Move()
    {

        base.Move();
    }
    public override void Attack()
    {
        base.Attack(); 
    }
    public override void SpecificAttack()
    {
        target.TakeDamage(damage);
    }
}
