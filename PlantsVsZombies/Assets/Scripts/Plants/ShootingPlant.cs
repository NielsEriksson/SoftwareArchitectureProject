using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlant : Plant
{
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected GameObject bullet;
    [SerializeField] float shootingSpeed;
    [SerializeField] float shootingDelay;

    public override void Start()
    {
        base.Start();
        //shootingDelay = new WaitForSeconds(shootingSpeed);
    }
    public override void Attack()
    {
        base.Attack();
        StartCoroutine(Shoot());
    }
    public override void StopAttack()
    {
        StopAllCoroutines();
    }
    public override void Idle()
    {
        base.Idle();
    }
    public override void Action()
    {

    }
    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootingDelay);
        while (true)
        {
            GameObject.Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            yield return new WaitForSeconds(shootingSpeed);
        }
    }
}
