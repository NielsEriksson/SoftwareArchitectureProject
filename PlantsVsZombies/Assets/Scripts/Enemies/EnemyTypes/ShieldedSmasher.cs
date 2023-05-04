using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShieldedSmasher : Smasher
{
    private bool hasShield;
    public int shieldHealth;
    public int noShieldDamage;
    public int noShieldSpeed;
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
    public override void TakeDamage(int damage)
    {
        if (hasShield)
        {
            shieldHealth -=damage;
        }
        if (shieldHealth <= 0)
        {
            hasShield = false;  
        }
        if(!hasShield)
        {
            base.TakeDamage(damage);
        }        
    }
    public void LooseShield()
    {
        damage = noShieldDamage;
        speed = noShieldSpeed;
    }
}
