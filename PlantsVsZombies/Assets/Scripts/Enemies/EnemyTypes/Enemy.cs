using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    protected Vector2 direction = new Vector2(-1, 0);
    public int enemyWeigth;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        rb.velocity = direction * speed;
    }
    public virtual void Attack()
    {

    }
}
