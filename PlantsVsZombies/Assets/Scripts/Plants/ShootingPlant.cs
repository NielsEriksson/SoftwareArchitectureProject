using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlant : Plant
{
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected GameObject bullet;
    [SerializeField] float shootingSpeed;
    [SerializeField] float shootingDelay;
    float baseAnimationSpeed; 

    public override void Start()
    {
        base.Start();
        if (isUpgraded)
        {
            shootingSpeed /= 2;
            shootingDelay /= 2;
        }
        baseAnimationSpeed = animator.speed;
    }
    public override void Attack()
    {
        base.Attack();
        StartCoroutine(Shoot());

        if(isUpgraded)
        {
            animator.speed *= 2;
        }
    }
    public override void StopAttack()
    {
        StopAllCoroutines();

        if (isUpgraded)
        {
            animator.speed = baseAnimationSpeed;
        }
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
