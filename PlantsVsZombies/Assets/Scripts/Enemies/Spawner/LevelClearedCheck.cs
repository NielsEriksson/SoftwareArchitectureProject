using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelClearedCheck : MonoBehaviour
{
    public int enemiesKilled;

    private MapManager mapManager;
    [SerializeField] GameObject InterLevelUI;
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
        if (enemiesKilled == EnemySpawner.Instance.enemiesSpawned && EnemySpawner.Instance.enemiesSpawned>= EnemySpawner.Instance.enemiesInLevel.Count)
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
        //Clear grid an UnOccupy all tiles.
    }
    public void LoadInterLevelUI()
    {
        InterLevelUI.SetActive(true);
        InterLevelUI.GetComponent<InterLevelUi>().cardSelected = false;
        InterLevelUI.GetComponent<InterLevelUi>().nextLvlButton.enabled = false;
        Time.timeScale = 0f;
    }
}
