using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] int speed;
    [SerializeField] int damage;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
