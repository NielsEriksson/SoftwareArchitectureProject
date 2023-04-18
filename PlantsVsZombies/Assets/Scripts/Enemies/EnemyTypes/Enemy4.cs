using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        enemyWeigth = 4;
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