using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlant : Plant
{
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected GameObject bullet;

    public override void Attack()
    {
        GameObject.Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
    }
    public override void Idle()
    {
       
    }
    public override void Action()
    {
        
    }
}
