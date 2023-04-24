using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName ="Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public List<Enemy> availableEnemies;
    public int enemyMaxWieght;
    public int waves;
    public int enemiesPerWave;
    public int enemy1SpawnChance, enemy2SpawnChance, enemy3SpawnChance, enemy4SpawnChance;

    public void UpdateChances()
    {
        if(enemy2SpawnChance > 0) 
        {
            enemy2SpawnChance += enemy1SpawnChance;
        }
        if(enemy3SpawnChance > 0)
        {
            enemy3SpawnChance += enemy2SpawnChance;
        }
        if(enemy4SpawnChance > 0)
        {
            enemy4SpawnChance += enemy3SpawnChance;
        }
    }
}
