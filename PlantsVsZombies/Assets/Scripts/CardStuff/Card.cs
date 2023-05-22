using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public bool isStartingCard;
    public string cardName;
    public Image cardImage; 
    public string cardDescription;
    public Plant.Element[] conditions;
    public string extraDescription;

    public Plant plantPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
