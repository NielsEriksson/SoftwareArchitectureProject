using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField]Slider waveTimer;
    EnemySpawner spawner;
    [SerializeField] GameObject[] avEnemyImages;

    float time;
    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        waveTimer.maxValue = spawner.timeBetweenWaves * spawner.currentLevel.waves;
        for (int i = 0; i <spawner.currentLevel.availableEnemies.Count; i++)
        {
            avEnemyImages[i].GetComponent<Image>().color = spawner.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().color ;
            avEnemyImages[i].GetComponent<Image>().sprite = spawner.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().sprite;
            avEnemyImages[i].SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        waveTimer.value = time;
        Debug.Log(waveTimer.value);
    }
    public void ResetUI()
    {
        time = 0;
        waveTimer.value = 0;
        waveTimer.maxValue = spawner.timeBetweenWaves * spawner.currentLevel.waves;
        for (int i = 0; i < avEnemyImages.Length; i++)
        {
            avEnemyImages[i].SetActive(false);
        }

        for (int i = 0; i < spawner.currentLevel.availableEnemies.Count; i++)
        {
            avEnemyImages[i].GetComponent<Image>().color = spawner.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().color;
            avEnemyImages[i].GetComponent<Image>().sprite = spawner.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().sprite;
            avEnemyImages[i].SetActive(true);
        }
    }
}
