using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHit : MonoBehaviour
{
    [SerializeField] int dealDamage;

    List<Enemy> enemyList = new List<Enemy>();
    private void Update()
    {
        DealDamageToEachEnemy();
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
            //Debug.Break();
            enemy.TakeDamage(dealDamage);
        }
    }

    public void DestroyArea()
    {
        Destroy(this.gameObject);
    }

}
