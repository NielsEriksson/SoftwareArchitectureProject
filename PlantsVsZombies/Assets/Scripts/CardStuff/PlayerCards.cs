using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    public GameObject baseCard;
    public int handLimit;
    public Card tempCard;
    public Card tempCard2;
    public Text deckText;
    public Text discardText;
    [HideInInspector] public int selectedCard = 0;

    List<Card> handCards = new List<Card>();
    List<Card> deckCards = new List<Card>();
    List<Card> discardCards = new List<Card>();
    List<GameObject> cardObjects = new List<GameObject>();

    float handCardDistance = 20f;
    float cardWidth;

    // Start is called before the first frame update
    void Start()
    {
        cardWidth = baseCard.GetComponent<RectTransform>().sizeDelta.x;
        while (handCards.Count < handLimit)
        {
            handCards.Add(tempCard);
            //handCards.Add(tempCard2);
        }
        CreateHand();
    }

    // Update is called once per frame
    void Update()
    {
        deckText.text = deckCards.Count.ToString();
        discardText.text = discardCards.Count.ToString();
    }

    void CreateHand()
    {
        cardObjects.Clear(); /*=  new GameObject[handCards.Count];*/
        int tempCounter = 0;
        Camera cam = Camera.main;
        float halfViewport = (cam.orthographicSize * cam.aspect);
        Debug.Log(halfViewport);

        foreach (Card card in handCards)
        {
            GameObject tempObject = Instantiate(baseCard, transform);
            tempObject.GetComponent<CardDisplay>().card = card;
            Vector3 tempPosition = tempObject.transform.position;
            //tempObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 
            //    transform.rotation.z + tempHandSlot, transform.rotation.w);
            tempObject.transform.position = GetHandPosition(tempCounter, handCards.Count);
            tempObject.GetComponent<DragDrop>().handIndex = tempCounter + 1;

            cardObjects.Add(tempObject);
            tempCounter++;
            //Debug.Log(tempCardWidth);
        }
    }

    public void UpdateHand()
    {
        int tempCounter = 0;
        int tempHandSize = handCards.Count;
        if (selectedCard != 0)
            tempHandSize--;

        string tempDebug = "";

        for (int i = 0; i < cardObjects.Count; i++)
        {
            if (i + 1 != selectedCard)
            {
                tempDebug += (i + 1) + ", ";
                cardObjects[i].transform.position = GetHandPosition(tempCounter, tempHandSize);
                tempCounter++;
            }
        }
    }

    public void RemoveSelectedCard()
    {
        Destroy(cardObjects[selectedCard - 1]);
        discardCards.Add(handCards[selectedCard - 1]);
        handCards.RemoveAt(selectedCard - 1);
        cardObjects.RemoveAt(selectedCard - 1);
        selectedCard = 0;
        UpdateIndex();
    }

    void UpdateIndex()
    {
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].GetComponent<DragDrop>().handIndex = i + 1;
        }
    }

    Vector3 GetHandPosition(int aSlot, int aSlotAmount)
    {
        Vector3 tempTransform;
        float tempHandSlot = ((float)(aSlotAmount - 1) / 2) - aSlot;
        tempTransform = transform.position + new Vector3((tempHandSlot * (cardWidth + handCardDistance)), 0, 0);
        return tempTransform;
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
