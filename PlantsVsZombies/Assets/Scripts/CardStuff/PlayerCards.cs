using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{
    public GameObject cardObject;
    public Card tempCard;
    public Card tempCard2;
    public int handLimit;
    List<Card> handCards = new List<Card>();
    List<Card> deckCards = new List<Card>();
    List<Card> discardCards = new List<Card>();

    float handCardDistance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        while (handCards.Count < handLimit)
        {
            handCards.Add(tempCard);
            //handCards.Add(tempCard2);
        }
        UpdateHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHand()
    {
        GameObject[] tempCards = new GameObject[handCards.Count];
        int tempCounter = 0;
        foreach (Card card in handCards)
        {
            GameObject tempObject = Instantiate(cardObject, transform);
            tempObject.GetComponent<CardDisplay>().card = card;
            Vector3 tempPosition = tempObject.transform.position;
            float tempCardWidth = cardObject.GetComponent<Renderer>().bounds.size.x;
            float tempHandSlot = ((float)(handCards.Count - 1) / 2) - tempCounter;
            tempObject.transform.position = transform.position + new Vector3(tempHandSlot * (tempCardWidth + handCardDistance), 0, 0);
            //tempObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 
            //    transform.rotation.z + tempHandSlot, transform.rotation.w);

            tempCards[tempCounter] = tempObject;
            tempCounter++;
            Debug.Log(tempCounter + " - " + tempHandSlot);
        }
    }

    public void DrawCard(int anAmount)
    {
        for (int i = 0; i < anAmount; i++)
        {
            if (handCards.Count < handLimit && deckCards.Count > 0)
            {
                Card tempCard = deckCards[Random.Range(0, deckCards.Count)];
            }
        }
    }

    public void ShuffleDiscardIntoDeck()
    {
        foreach (Card card in discardCards) 
        { 
            deckCards.Add(card);
        }
        discardCards.Clear();
    }
}
