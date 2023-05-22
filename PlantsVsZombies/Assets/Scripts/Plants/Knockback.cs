using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] private float destroyTimer;
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
    private void Update()
    {
        foreach(Enemy enemy in enemyList)
        {
            //enemy.PushBack();
            Debug.Log("Enemy PushBack");
        }
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
