using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] public List<Level> levels;
    public Level[] levelsInstances;
    public Level currentLevel;
    public int currentLevelNum;
    private int currentWave=0;
    [SerializeField] int numberOfLevels;
    [SerializeField] private int currentEnemy;
    [SerializeField] public List<Enemy> enemiesInLevel;
    private Enemy enemyToSpawn;
    float spawnWaveTimer;
    [SerializeField] public float timeBetweenWaves;
    [SerializeField] float spawnEnemyDelay;
    WaveUI waveUI;
    bool isSpawningWave;
    public bool levelRunning = true;
    public int enemiesSpawned;
    [SerializeField] private int cardsPerWave;


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
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
        }
        //Remove this when done

        currentLevelNum = PlayerPrefs.GetInt("CurrentLevel");
       
        currentLevel = levelsInstances[currentLevelNum];
        currentLevel.UpdateChances();
        GenerateLevel();   
        waveUI = FindObjectOfType<WaveUI>();
        Time.timeScale = 1.0f;
        
    }
    public void FixedUpdate()
    {
        if (levelRunning)
        {
            spawnWaveTimer -= Time.deltaTime;
            if (spawnWaveTimer < 0 && !isSpawningWave)
            {
                currentWave++;
                isSpawningWave = true;
                StartCoroutine(SpawnWave());
                spawnWaveTimer = timeBetweenWaves;
            }
        }
    }
    public void ChangeLevel()
    {
        if (currentLevelNum < numberOfLevels-1)
        {
            Debug.Log("Chaning LEvel");
            currentLevelNum++;
            PlayerPrefs.SetInt("CurrentLevel", currentLevelNum);
            currentLevelNum = PlayerPrefs.GetInt("CurrentLevel");
            currentLevel = levelsInstances[currentLevelNum];
            currentLevel.UpdateChances();
            ResetLevel();
            GenerateLevel();
            waveUI.ResetUI();
            Time.timeScale = 1f;
            levelRunning = true;
         
          
        }

    }
    public void GenerateLevel()
    {
        if (enemiesInLevel.Count > 0) { enemiesInLevel.Clear(); }
        //Could be made better to automatically add new enemy types without manually adding anything here
        int enemy1SpawnChance = currentLevel.SmasherSpawnChance;
        int enemy2SpawnChance = currentLevel.ShieldedSmasherSpawnChance + enemy1SpawnChance;
        int enemy3SpawnChance = currentLevel.ArcherSpawnChance + enemy2SpawnChance;
        int enemy4SpawnChance = currentLevel.CamouflageSpawnChance + enemy3SpawnChance;
        int enemy5SpawnChance = currentLevel.BomberSpawnChance + enemy4SpawnChance;
        for (int i = 0; i < currentLevel.enemyMaxWieght;)
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

           
        }

        currentLevel.enemiesPerWave = enemiesInLevel.Count / currentLevel.waves;

    }
    public IEnumerator SpawnWave()
    {
        FindObjectOfType<PlayerCards>().DrawCard(cardsPerWave);
        int amountOfEnemiesToSpawn = currentLevel.enemiesPerWave;
        if(currentWave == currentLevel.waves) 
        {
            amountOfEnemiesToSpawn = enemiesInLevel.Count - enemiesSpawned;
        }
        for (int i = 0; i < amountOfEnemiesToSpawn; i++)
        {
            yield return new WaitForSeconds(spawnEnemyDelay);
            if (currentEnemy < enemiesInLevel.Count)
            {
                int enemySpawPoint = Random.Range(0, spawnPoints.Count);
                enemyToSpawn = enemiesInLevel[currentEnemy];
                GameObject.Instantiate(enemyToSpawn, spawnPoints[enemySpawPoint].transform.position, Quaternion.identity);               
                currentEnemy++;
                enemiesSpawned++;
            }
        }
        isSpawningWave = false;        
    }
    public void SpawnExtraEnemy()
    {
        enemyToSpawn = currentLevel.availableEnemies[0];
        int SpawnPoint = Random.Range(0, spawnPoints.Count-1); 
        GameObject.Instantiate(enemyToSpawn, spawnPoints[SpawnPoint].transform.position, Quaternion.identity);
        enemiesSpawned++;
    }
    public void ResetLevel()
    {
        currentEnemy = 0;
        enemiesInLevel.Clear();
        spawnWaveTimer=0;
        enemiesSpawned = 0;
        isSpawningWave=false;
    }
}
