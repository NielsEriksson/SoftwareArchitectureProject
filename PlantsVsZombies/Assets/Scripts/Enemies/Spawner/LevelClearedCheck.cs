using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelClearedCheck : MonoBehaviour
{
    public int enemiesKilled;
    private EnemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner= GetComponent<EnemySpawner>();
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

    }
}
