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
    [SerializeField] GameObject[] waveIndicators;
    [SerializeField] HorizontalLayoutGroup wavesGroup;

    int initialSpacing = 26; //spacing for 10 waves
    float spacingMultiplier = 1.346f;
    int maxWaves = 10;
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
        for (int i = 0; i < spawner.currentLevel.waves; i++)
        {
            waveIndicators[i].gameObject.SetActive(true);
        }
        wavesGroup.spacing = initialSpacing *(Mathf.Pow(spacingMultiplier, maxWaves -spawner.currentLevel.waves))-0.5f;

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
