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
    public int SmasherSpawnChance, ShieldedSmasherSpawnChance, ArcherSpawnChance, CamouflageSpawnChance, BomberSpawnChance;

    public void UpdateChances()
    {
        if(ShieldedSmasherSpawnChance > 0) 
        {
            ShieldedSmasherSpawnChance += SmasherSpawnChance;
        }
        if(ArcherSpawnChance > 0)
        {
            ArcherSpawnChance += ShieldedSmasherSpawnChance;
        }
        if(CamouflageSpawnChance > 0)
        {
            CamouflageSpawnChance += ArcherSpawnChance;
        }
        if (BomberSpawnChance > 0)
        {
            BomberSpawnChance += CamouflageSpawnChance;
        }
    }
}
