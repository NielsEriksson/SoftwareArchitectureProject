using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlant : Plant
{
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected GameObject bullet;
    [SerializeField] private float shootingSpeed;
    private WaitForSeconds shootingDelay;

    public override void Start()
    {
        base.Start();
        shootingDelay = new WaitForSeconds(shootingSpeed);
    }
    public override void Attack()
    {
        StartCoroutine(Shoot());
    }
    public override void StopAttack()
    {
        StopAllCoroutines();
    }
    public override void Idle()
    {

    }
    public override void Action()
    {

    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            GameObject.Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            yield return shootingDelay;
        }
    }
}
