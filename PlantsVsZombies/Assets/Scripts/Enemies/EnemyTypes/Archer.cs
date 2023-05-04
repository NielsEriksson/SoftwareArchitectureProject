using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
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
       arrowPrefab.GetComponent<arrowScript>().archer = this;
       Instantiate(arrowPrefab,arrowSpawn.transform.position , Quaternion.Euler(0,0,-90));
    }
}
