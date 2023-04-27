using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D bombRange;
    List<Collider2D> bombColliders;
    [SerializeField] private float explosionTimer;
    public Bomber bomber;
    void Start()
    {
        bombRange = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        explosionTimer -= Time.deltaTime;
        //timeticking animation
        if (explosionTimer < 0 )
        {
            //ExplosionAnimation
            Explode();
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        //ExplosionAnimation
        foreach (var collider in bombColliders)
        {
            collider.GetComponent<Plant>().TakeDamage(bomber.damage);
        }
        bomber.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant" )
        {
            bombColliders.Add(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            bombColliders.Remove(collision);
        }
    }

}
