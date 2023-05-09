using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName ="Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public List<Enemy> availableEnemies;
    public int enemyMaxWieght;
    [Header("Min 5 waves or UI is messed up")]
    public int waves;
    public int enemiesPerWave;
    public int SmasherSpawnChance, ShieldedSmasherSpawnChance, ArcherSpawnChance, CamouflageSpawnChance, BomberSpawnChance;

    public void UpdateChances()
    {
        int enemy1SpawnChance = SmasherSpawnChance;
        int enemy2SpawnChance = ShieldedSmasherSpawnChance + enemy1SpawnChance;
        int enemy3SpawnChance = ArcherSpawnChance + enemy2SpawnChance;
        int enemy4SpawnChance = CamouflageSpawnChance + enemy3SpawnChance;
        int enemy5SpawnChance = BomberSpawnChance + enemy4SpawnChance;

    }
}
