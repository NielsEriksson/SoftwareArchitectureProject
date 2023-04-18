using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<Level> levels;
    private Level currentLevel;
    private int currentLevelNum;
    private int currentEnemy;
    List<Enemy> enemiesInLevel;
    private Enemy enemyToSpawn;
    [SerializeField] float spawnWaveTimer;
    float spawnWaveTimerReset;
    //[SerializeField] float spawnEnemyDelay;
    //float spawnEnemyDelayReset;

    // Start is called before the first frame update
    void Start()
    {
        spawnWaveTimerReset = spawnWaveTimer; 
        //spawnEnemyDelayReset = spawnEnemyDelay;
        currentEnemy = 0;
        currentLevelNum = 0;
        currentLevel = levels[currentLevelNum];
        currentLevel.UpdateChances();
        GenerateLevel();
    }
    public void FixedUpdate()
    {
        spawnWaveTimer -= Time.deltaTime;
        if (spawnWaveTimer < 0 ) 
        {
            for ( int i = 0; i < currentLevel.enemiesPerWave; i++ )
            {
                SpawnNextEnemy();
            }
            spawnWaveTimer = spawnWaveTimerReset;
        }
        
    }
    public void ChangeLevel()
    {
        currentLevelNum++;
        currentLevel= levels[currentLevelNum];
    }
    public void GenerateLevel()
    {
        enemiesInLevel.Clear();
        for (int i = 0; i < currentLevel.enemyMaxWieght;)
        {
            int enemySpawnChance = Random.Range(0, 100);
            if(enemySpawnChance <= currentLevel.enemy1SpawnChance && currentLevel.enemy1SpawnChance >0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[0].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy2SpawnChance && currentLevel.enemy2SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[1].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy3SpawnChance && currentLevel.enemy3SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[2].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy4SpawnChance && currentLevel.enemy4SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[3].enemyWeigth;
            }
        }
        currentLevel.enemiesPerWave = enemiesInLevel.Count/currentLevel.waves;

    }
    public void SpawnNextEnemy()
    {
        int enemySpawPoint = Random.Range(0, spawnPoints.Count - 1);
        enemyToSpawn = enemiesInLevel[currentEnemy];
        GameObject.Instantiate(enemyToSpawn, spawnPoints[enemySpawPoint].transform.position, Quaternion.identity);
        currentEnemy++;
    }
    public void SpawnExtraEnemy()
    {
        enemyToSpawn = currentLevel.availableEnemies[0];
        int SpawnPoint = Random.Range(0, spawnPoints.Count-1); 
        GameObject.Instantiate(enemyToSpawn, spawnPoints[SpawnPoint].transform.position, Quaternion.identity);
    }
}
