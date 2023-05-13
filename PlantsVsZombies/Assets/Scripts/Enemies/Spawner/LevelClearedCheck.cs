using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelClearedCheck : MonoBehaviour
{
    public int enemiesKilled;
    private EnemySpawner spawner;
    private MapManager mapManager;
    [SerializeField] GameObject InterLevelUI;
    Enemy[] enemies;
    Plant[] plants;
    // Start is called before the first frame update
    void Start()
    {
        spawner= GetComponent<EnemySpawner>();
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == spawner.enemiesInLevel.Count)
        {
            if (FindObjectsOfType<Enemy>().Count() == 0)
            {
                //Level Cleared Method
            }
        }
    }
    public void LevelCleared()
    {
        spawner.levelRunning= false;
        //Do something
        spawner.ResetLevel();
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
