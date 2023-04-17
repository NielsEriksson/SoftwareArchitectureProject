using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    public int handLimit = 3;
    List<Card> handCards = new List<Card>();
    List<Card> deckCards = new List<Card>();
    List<Card> discardCards = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        if (handCards.Count < handLimit && deckCards.Count > 0) 
        {
            Card tempCard = deckCards[Random.Range(0, deckCards.Count)];
        }
    }
}
