using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        enemyWeigth = 3;
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
}