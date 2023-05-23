using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
    [SerializeField] int playerHealths;
    [SerializeField] GameObject LooseScreen;
    [SerializeField] GameObject healthPot1;
    [SerializeField] GameObject healthPot2;
    [SerializeField] GameObject healthPot3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            playerHealths--;
            UpdateHealthUI();
            CheckDeath();
        }
    }
    public void CheckDeath()
    {
        if(playerHealths <= 0)
        {
            Time.timeScale = 0f;
            LooseScreen.SetActive(true);
        }
    }
    private void UpdateHealthUI()
    {
        if (playerHealths == 1)
        {
            healthPot1.SetActive(true);
            healthPot2.SetActive(false);
            healthPot3.SetActive(false);
        }
        else if (playerHealths == 2)
        {
            healthPot1.SetActive(true);
            healthPot2.SetActive(true);
            healthPot3.SetActive(false);
        }
        else if (playerHealths == 1)
        {
            healthPot1.SetActive(true);
            healthPot2.SetActive(true);
            healthPot3.SetActive(true);
        }
        else if (playerHealths == 0)
        {
            healthPot1.SetActive(false);
            healthPot2.SetActive(false);
            healthPot3.SetActive(false);
        }
    }
   
}
