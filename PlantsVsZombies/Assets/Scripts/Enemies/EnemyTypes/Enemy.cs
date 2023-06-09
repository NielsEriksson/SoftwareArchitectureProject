using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Plant target;
    [HideInInspector] public Rigidbody2D rb;
    public int damage;
    [SerializeField] protected float speed;
    protected Vector2 direction = new Vector2(-1, 0);
    public int enemyWeigth;
    public int health;
    private float attackTimer;  
    [SerializeField] private float attackTimerReset;
    private bool canAttack;
     public bool isInRange;
    [HideInInspector] public LevelClearedCheck lvlClearer;
    // Start is called before the first frame update
    public virtual void Start()
    {
        attackTimer = attackTimerReset;
        lvlClearer = FindObjectOfType<LevelClearedCheck>();
        rb = GetComponent<Rigidbody2D>();   
    }
    public virtual void Update()
    {
        if (attackTimer>= 0) 
        { 
            attackTimer -= Time.deltaTime;            
        }  
        if (attackTimer < 0)
        {
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
        
    }
   
    public virtual void TakeDamage(int damage)
    {
     
        health -= damage;
    }
    public virtual void Die()
    {
        //DeathAnimation
       
        FindObjectOfType<LevelClearedCheck>().enemiesKilled++;
        if (FindObjectOfType<EnemySpawner>().currentWave < FindObjectOfType<EnemySpawner>().currentLevel.waves)
        {
            FindObjectOfType<EnemySpawner>().DrawCardsWaveCleared();
        }
        Destroy(gameObject);
    }
  
}

