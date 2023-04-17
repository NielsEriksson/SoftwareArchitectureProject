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
}
