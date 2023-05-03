using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camouflage : Enemy
{
    private bool isVisible = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        if(isInRange && !isVisible)
        {
            BecomeVisible();
        }
        base.Update(); 
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
        if (isVisible)
        {
            target.TakeDamage(damage);
        }
    }
    public override void TakeDamage(int damage)
    {
        if (isVisible)
        {
            base.TakeDamage(damage);
        }
    }
    public void BecomeVisible()
    {
        isVisible = true;
        var tempColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        tempColor.a = 0.4f;
        this.gameObject.GetComponent<SpriteRenderer>().color = tempColor;

    }
}