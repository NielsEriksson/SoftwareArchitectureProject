using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    HoldingCard holdingCard;
    public string cardName;
    public string cardDescription;

    // Start is called before the first frame update
    void Start()
    {
        holdingCard = GameObject.FindGameObjectWithTag("Holding Card").GetComponent<HoldingCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
