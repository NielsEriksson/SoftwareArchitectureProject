using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    public GameObject baseCard;
    public Card tempCard;
    public Card tempCard2;
    public int handLimit;
    List<Card> handCards = new List<Card>();
    List<Card> deckCards = new List<Card>();
    List<Card> discardCards = new List<Card>();
    GameObject[] cardObjects;

    float handCardDistance = 20f;

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
        cardObjects = new GameObject[handCards.Count];
        int tempCounter = 0;
        Camera cam = Camera.main;
        float halfViewport = (cam.orthographicSize * cam.aspect);
        Debug.Log(halfViewport);

        foreach (Card card in handCards)
        {
            GameObject tempObject = Instantiate(baseCard, transform);
            tempObject.GetComponent<CardDisplay>().card = card;
            Vector3 tempPosition = tempObject.transform.position;
            float tempCardWidth = baseCard.GetComponent<RectTransform>().sizeDelta.x;
            float tempHandSlot = ((float)(handCards.Count - 1) / 2) - tempCounter;
            tempObject.transform.position = transform.position + new Vector3((tempHandSlot * (tempCardWidth + handCardDistance)), 0, 0);
            //tempObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 
            //    transform.rotation.z + tempHandSlot, transform.rotation.w);

            cardObjects[tempCounter] = tempObject;
            tempCounter++;
            //Debug.Log(tempCardWidth);
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
