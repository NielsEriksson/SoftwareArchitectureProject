using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField]Slider waveTimer;
  
    [SerializeField] GameObject[] avEnemyImages;
    [SerializeField] GameObject[] waveIndicators;
    [SerializeField] HorizontalLayoutGroup wavesGroup;

    int initialSpacing = 26; //spacing for 10 waves
    float spacingMultiplier = 1.346f;
    int maxWaves = 10;
    float time;
    private void Start()
    {
        
        waveTimer.maxValue = EnemySpawner.Instance.timeBetweenWaves * (EnemySpawner.Instance.currentLevel.waves-1);
        for (int i = 0; i < EnemySpawner.Instance.currentLevel.availableEnemies.Count; i++)
        {
            avEnemyImages[i].GetComponent<Image>().color = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().color ;
            avEnemyImages[i].GetComponent<Image>().sprite = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().sprite;
            avEnemyImages[i].SetActive(true);

        }
        for (int i = 0; i < EnemySpawner.Instance.currentLevel.waves; i++)
        {
            waveIndicators[i].gameObject.SetActive(true);
        }
        wavesGroup.spacing = initialSpacing *(Mathf.Pow(spacingMultiplier, maxWaves - EnemySpawner.Instance.currentLevel.waves))-0.5f;

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        waveTimer.value = time;
      
    }
    public void ResetUI()
    {
        time = 0;
        waveTimer.value = 0;
        waveTimer.maxValue = EnemySpawner.Instance.timeBetweenWaves * EnemySpawner.Instance.currentLevel.waves;
        for (int i = 0; i < avEnemyImages.Length; i++)
        {
            avEnemyImages[i].SetActive(false);
        }

        for (int i = 0; i < EnemySpawner.Instance.currentLevel.availableEnemies.Count; i++)
        {
            avEnemyImages[i].GetComponent<Image>().color = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().color;
            avEnemyImages[i].GetComponent<Image>().sprite = EnemySpawner.Instance.currentLevel.availableEnemies[i].GetComponent<SpriteRenderer>().sprite;
            avEnemyImages[i].SetActive(true);
        }
    }
}
