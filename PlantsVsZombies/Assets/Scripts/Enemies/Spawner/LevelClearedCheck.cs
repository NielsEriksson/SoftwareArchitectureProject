using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelClearedCheck : MonoBehaviour
{
    public int enemiesKilled;

    private MapManager mapManager;
    [SerializeField] GameObject InterLevelUI;
    [SerializeField] GameObject VictoryScreen;
    Enemy[] enemies;
    Plant[] plants;
    // Start is called before the first frame update
    void Start()
    {    
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == EnemySpawner.Instance.enemiesSpawned && EnemySpawner.Instance.enemiesSpawned >= EnemySpawner.Instance.enemiesInLevel.Count)
        {
            LevelCleared();
            LoadInterLevelUI();
        }
    }
    public void LevelCleared()
    {
        EnemySpawner.Instance.levelRunning= false;
        //Do something
        EnemySpawner.Instance.ResetLevel();
        enemiesKilled = 0;
        enemies = FindObjectsOfType<Enemy>().ToArray();
        plants = FindObjectsOfType<Plant>().ToArray();
        for (int i = 0; i < enemies.Length ; i++)
        {
            if (enemies[i]!=null)
            {
                Destroy(enemies[i].gameObject);
            }
         
        }
        mapManager.ClearGrid();

    }
    public void LoadInterLevelUI()
    {
        if (EnemySpawner.Instance.currentLevelNum == EnemySpawner.Instance.levels.Count - 1)
        {
            VictoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            InterLevelUI.SetActive(true);

            Time.timeScale = 0f;
        }
        FindObjectOfType<CardSelection>().GenetateCards();


    }
}
