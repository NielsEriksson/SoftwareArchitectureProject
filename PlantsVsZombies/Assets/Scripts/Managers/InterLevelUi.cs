using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterLevelUi : MonoBehaviour
{
    public bool cardSelected =false;
    [SerializeField] public  GameObject nextLvlButton;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(cardSelected)
        {
           nextLvlButton.SetActive(true);
        }
    }
}
