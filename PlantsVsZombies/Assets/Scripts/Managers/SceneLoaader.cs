using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaader : MonoBehaviour
{
    public void RetryLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", EnemySpawner.Instance.currentLevelNum);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void LoadMenu()
    {
        PlayerPrefs.SetInt("HighestLevel", EnemySpawner.Instance.currentLevelNum);
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
