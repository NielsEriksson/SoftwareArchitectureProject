using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlantHit : MonoBehaviour
{
    [SerializeField] int dealDamage;
    [SerializeField] float timeBetweenHits = 1f;

    private float timer = 0;
    public bool isAlive;

    List<Enemy> enemyList = new List<Enemy>();
    private void Start()
    {
        isAlive = true;
    }
    private void Update()
    {
        if (!isAlive)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;

        if (timer > timeBetweenHits)
        {
            DealDamageToEachEnemy();
            timer = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyList.Add(collision.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyList.Remove(collision.GetComponent<Enemy>());
        }
    }

    public void DealDamageToEachEnemy()
    {
        foreach (Enemy enemy in enemyList)
        {
            enemy.TakeDamage(dealDamage);
        }
    }
}
