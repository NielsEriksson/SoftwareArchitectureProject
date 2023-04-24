using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    [SerializeField] private GameObject bomb;
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
    public override void SpecificAttack()
    {
        Vector2 bombPos = transform.position - new Vector3(5,0);
        bomb.GetComponent<Bomb>().bomber = this;
        GameObject.Instantiate(bomb, bombPos, Quaternion.identity);
        base.SpecificAttack();
    }
    
}