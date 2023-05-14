using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
    [SerializeField] int playerHealths;
    [SerializeField] GameObject LooseScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            playerHealths--;
        }
    }
    public void Update()
    {
        if(playerHealths <= 0)
        {
            Time.timeScale = 0f;
            LooseScreen.SetActive(true);
        }
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
