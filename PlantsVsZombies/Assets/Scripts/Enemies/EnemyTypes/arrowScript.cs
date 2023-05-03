using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public Archer archer;
    public int arrowSpeed;
    private Vector2 direction = new Vector2(-1, 0);
    public void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            collision.gameObject.GetComponent<Plant>().TakeDamage(archer.damage);
            Destroy(gameObject);
        }
    }
}
