using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEnemies : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();

    public void Start()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(i <EnemySpawner.Instance.currentLevel.availableEnemies.Count)
            {
         
                enemies[i].GetComponent<SpriteRenderer>().color = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().color;
                enemies[i].GetComponent<SpriteRenderer>().sprite = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {              
                int j = Random.Range(0, EnemySpawner.Instance.currentLevel.availableEnemies.Count );
                enemies[i].GetComponent<SpriteRenderer>().color = EnemySpawner.Instance.currentLevel.availableEnemies[j].GetComponent<SpriteRenderer>().color;
                enemies[i].GetComponent<SpriteRenderer>().sprite = EnemySpawner.Instance.currentLevel.availableEnemies[j].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}
