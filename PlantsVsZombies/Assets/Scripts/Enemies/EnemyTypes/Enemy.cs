using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    protected Vector2 direction = new Vector2(-1, 0);
    public int enemyWeigth;
    public int health;
    private float attackTimer;  
    [SerializeField] private float attackTimerReset;
    private bool canAttack;
    [HideInInspector] public bool isInRange;
    [HideInInspector] public LevelClearedCheck lvlClearer;
    // Start is called before the first frame update
    public virtual void Start()
    {
       
        lvlClearer = FindObjectOfType<LevelClearedCheck>();
        rb = GetComponent<Rigidbody2D>();
        health = 1;
     
    }
    public virtual void Update()
    {
        if (attackTimer>= 0) 
        { 
            attackTimer -= Time.deltaTime;
            canAttack = true;
        }
  
    }

    // Update is called once per frame
    public virtual void Move()
    {
        rb.velocity = direction * speed;
    }
    public virtual void Attack()
    {
        if (canAttack)
        {
            SpecificAttack();
            canAttack = false;
            attackTimer = attackTimerReset;
        }
    }
    public virtual void SpecificAttack() 
    {
        //plantTakeDamage
    }
   
    public virtual void TakeDamage(int damage)
    {
        //DeathAnimation
        health -= damage;
    }
    public virtual void Die()
    {
        //DeathAnimation

        Destroy(gameObject);
    }
}

