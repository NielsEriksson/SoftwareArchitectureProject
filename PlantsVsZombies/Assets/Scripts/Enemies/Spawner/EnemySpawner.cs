using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<Level> levels;
    private Level currentLevel;
    private int currentLevelNum;
    [SerializeField] private int currentEnemy;
    [SerializeField] public List<Enemy> enemiesInLevel;
    private Enemy enemyToSpawn;
    [SerializeField] float spawnWaveTimer;
    [SerializeField] float spawnWaveTimerReset;
    [SerializeField] float spawnEnemyDelay;
    bool isSpawningWave;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        enemiesInLevel = new List<Enemy>();
        currentEnemy = 0;
        currentLevelNum = 0;        
        currentLevel = levels[currentLevelNum];
        currentLevel.UpdateChances();
        GenerateLevel();    
    }
    public void FixedUpdate()
    {
        spawnWaveTimer -= Time.deltaTime;
        if (spawnWaveTimer < 0 && !isSpawningWave)
        {
            isSpawningWave = true;
            StartCoroutine(SpawnWave());
            spawnWaveTimer = spawnWaveTimerReset;
        }
    }
    public void ChangeLevel()
    {
        currentLevelNum++;
        currentLevel= levels[currentLevelNum];
        currentLevel.UpdateChances();
    }
    public void GenerateLevel()
    {
        if (enemiesInLevel.Count > 0) { enemiesInLevel.Clear(); }

        for (int i = 0; i <= currentLevel.enemyMaxWieght;i++)
        {
            int enemySpawnChance = Random.Range(0, 100);
            if (enemySpawnChance <= currentLevel.enemy1SpawnChance && currentLevel.enemy1SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[0]);
                i += currentLevel.availableEnemies[0].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy2SpawnChance && currentLevel.enemy2SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[1]);
                i += currentLevel.availableEnemies[1].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy3SpawnChance && currentLevel.enemy3SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[2]);
                i += currentLevel.availableEnemies[2].enemyWeigth;
            }
            else if (enemySpawnChance <= currentLevel.enemy4SpawnChance && currentLevel.enemy4SpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[3].enemyWeigth;
            }
            Debug.Log("i = " + i);
        }
        if (enemiesInLevel.Count % currentLevel.waves == 0)
        {
            currentLevel.enemiesPerWave = enemiesInLevel.Count / currentLevel.waves;
        }
        else
        {
            currentLevel.enemiesPerWave = enemiesInLevel.Count / currentLevel.waves ;
        }
    }
    public IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentLevel.enemiesPerWave; i++)
        {
            yield return new WaitForSeconds(spawnEnemyDelay);
            if (currentEnemy < enemiesInLevel.Count)
            {
                int enemySpawPoint = Random.Range(0, spawnPoints.Count);
                enemyToSpawn = enemiesInLevel[currentEnemy];
                GameObject.Instantiate(enemyToSpawn, spawnPoints[enemySpawPoint].transform.position, Quaternion.identity);               
                currentEnemy++;
            }
        }
        isSpawningWave = false;        
    }
    public void SpawnExtraEnemy()
    {
        enemyToSpawn = currentLevel.availableEnemies[0];
        int SpawnPoint = Random.Range(0, spawnPoints.Count-1); 
        GameObject.Instantiate(enemyToSpawn, spawnPoints[SpawnPoint].transform.position, Quaternion.identity);
    }
    public void ResetLevel()
    {
        currentEnemy = 0;
        enemiesInLevel.Clear();
    }
}
