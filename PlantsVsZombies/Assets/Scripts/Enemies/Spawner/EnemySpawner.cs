using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<Level> levels;
    public Level[] levelsInstances;
    public Level currentLevel;
    private int currentLevelNum;
    [SerializeField] private int currentEnemy;
    [SerializeField] public List<Enemy> enemiesInLevel;
    private Enemy enemyToSpawn;
    float spawnWaveTimer;
    [SerializeField] public float timeBetweenWaves;
    [SerializeField] float spawnEnemyDelay;
    WaveUI waveUI;
    bool isSpawningWave;
    public bool levelRunning = true;
 

    // Start is called before the first frame update
    void Awake()
    {
        levelsInstances = new Level[levels.Count];
        Debug.Log(Resources.Load<Level>("Level1"));
       
        for (int i =0; i < levels.Count ; i++)
        {            
            levelsInstances[i] = Resources.Load<Level>(levels[i].name);
        }
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
        currentLevel = levelsInstances[currentLevelNum];
        currentLevel.UpdateChances();
        GenerateLevel();   
        waveUI = FindObjectOfType<WaveUI>();

    }
    public void FixedUpdate()
    {
        if (levelRunning)
        {
            spawnWaveTimer -= Time.deltaTime;
            if (spawnWaveTimer < 0 && !isSpawningWave)
            {
                isSpawningWave = true;
                StartCoroutine(SpawnWave());
                spawnWaveTimer = timeBetweenWaves;
            }
        }
    }
    public void ChangeLevel()
    {
        currentLevelNum++;
        currentLevel= levels[currentLevelNum];
        currentLevel.UpdateChances();
        ResetLevel();
        GenerateLevel();
        waveUI.ResetUI();
        Time.timeScale = 0f;
        levelRunning = true;

    }
    public void GenerateLevel()
    {
        if (enemiesInLevel.Count > 0) { enemiesInLevel.Clear(); }
        //Can be made better to automatically add new enemy types without manually adding anything here
        int enemy1SpawnChance = currentLevel.SmasherSpawnChance;
        int enemy2SpawnChance = currentLevel.ShieldedSmasherSpawnChance + enemy1SpawnChance;
        int enemy3SpawnChance = currentLevel.ArcherSpawnChance + enemy2SpawnChance;
        int enemy4SpawnChance = currentLevel.CamouflageSpawnChance + enemy3SpawnChance;
        int enemy5SpawnChance = currentLevel.BomberSpawnChance + enemy4SpawnChance;
        for (int i = 0; i <= currentLevel.enemyMaxWieght;)
        {
            int enemySpawnChance = Random.Range(0, 100);
           
            if (enemySpawnChance <= enemy1SpawnChance && currentLevel.SmasherSpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[0]);
                i += currentLevel.availableEnemies[0].enemyWeigth;
            }
           
            else if (enemySpawnChance <= enemy2SpawnChance && currentLevel.ShieldedSmasherSpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[1]);
                i += currentLevel.availableEnemies[1].enemyWeigth;
            }
            else if (enemySpawnChance <= enemy3SpawnChance && currentLevel.ArcherSpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[2]);
                i += currentLevel.availableEnemies[2].enemyWeigth;
            }
            else if (enemySpawnChance <= enemy4SpawnChance && currentLevel.CamouflageSpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[3]);
                i += currentLevel.availableEnemies[3].enemyWeigth;
            }
            else if (enemySpawnChance <= enemy5SpawnChance && currentLevel.BomberSpawnChance > 0)
            {
                enemiesInLevel.Add(currentLevel.availableEnemies[4]);
                i += currentLevel.availableEnemies[4].enemyWeigth;
            }
            //Debug.Log("i = " +currentLevel.availableEnemies[0].enemyWeigth);
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
        spawnWaveTimer=0;
    }
}
