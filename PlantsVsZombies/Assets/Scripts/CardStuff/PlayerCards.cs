using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    public GameObject baseCard;
    public int handLimit;
    Card[] tempCards;
    public GameObject deck;
    public GameObject discard;
    [HideInInspector] public int selectedCard = 0;

    List<Card> handCards = new List<Card>();
    List<Card> deckCards = new List<Card>();
    List<Card> discardCards = new List<Card>();
    List<GameObject> cardObjects = new List<GameObject>();
    List<GameObject> discardingCards = new List<GameObject>();

    float handCardDistance = 10f;
    float cardWidth;

    // Start is called before the first frame update
    void Start()
    {
        //tempCards = (Card[])Resources.FindObjectsOfTypeAll(typeof(Card));
        //tempCards = (Card[])FindObjectsOfType(typeof(Card));
        tempCards = Resources.LoadAll<Card>("Cards");
        //tempCards = new Card[temp.Length];
        //for (int i = 0; i < temp.Length; i++)
        //{
        //    tempCards[i] = temp[i];
        //}
        Debug.Log(tempCards.Length);

        cardWidth = baseCard.GetComponent<RectTransform>().sizeDelta.x;
        for (int i = 0; i < 20; i++)
        {
            deckCards.Add(tempCards[Random.Range(0, tempCards.Length)]);
        }

        DrawCard(handLimit);

        //CreateHand();
    }

    // Update is called once per frame
    void Update()
    {
        deck.GetComponent<Text>().text = deckCards.Count.ToString();
        discard.GetComponent<Text>().text = discardCards.Count.ToString();

        if (Input.GetMouseButtonDown(1))
        {
            DrawCard(1);
        }

        for (int i = 0; i < cardObjects.Count; i++)
        {
            if (Vector2.Distance(cardObjects[i].transform.position, discard.transform.position) <= 5f)
            {
                RemoveCard(i);
                i--;
            }
        }

        //for (int i = 0; i < discardingCards.Count; i++)
        //{
        //    if (discardingCards[i].transform.position == discard.transform.position)
        //    {
        //        Debug.Log("Card Discarded");
        //        discardingCards.RemoveAt(i);
        //        i--;
        //    }
        //}
    }

    void CreateCard(int aCard)
    {
        GameObject tempObject = Instantiate(baseCard, transform);
        tempObject.GetComponent<CardDisplay>().card = handCards[aCard];
        tempObject.transform.position = deck.transform.position;
        DragDrop tempDragDrop = tempObject.GetComponent<DragDrop>();
        tempDragDrop.handIndex = aCard + 1;
        tempDragDrop.scaleDestination = Vector2.one;
        tempDragDrop.transform.localScale = Vector2.zero;

        cardObjects.Add(tempObject);
        UpdateHand();
    }

    public void UpdateHand()
    {
        int tempCounter = 0;
        int tempHandSize = 0;

        for (int i = 0; i < handCards.Count; i++)
        {
            if (i + 1 != selectedCard && !cardObjects[i].GetComponent<DragDrop>().isDiscarded)
            {
                tempHandSize++;
            }
        }

        string tempDebug = "";

        handCardDistance = (Screen.width / 3 * 2) / handLimit;

        for (int i = 0; i < cardObjects.Count; i++)
        {
            DragDrop tempDragDrop = cardObjects[i].GetComponent<DragDrop>();

            if (i + 1 != selectedCard && !tempDragDrop.isDiscarded)
            {
                float tempSlot = GetHandSlot(tempCounter, tempHandSize);
                bool tempIsMinus = tempSlot < 0;
                tempSlot = Mathf.Pow(tempSlot, 2);
                if (tempIsMinus)
                    tempSlot = -tempSlot;

                tempDebug += (i + 1) + ", ";
                tempDragDrop.moveDestination = GetHandPosition(tempCounter, tempHandSize);
                tempDragDrop.rotationDestination = Quaternion.Euler(0, 0, tempSlot * -2);
                tempDragDrop.moveDestination.y -= Mathf.Abs(tempSlot) * (handCardDistance / 20);
                if (tempIsMinus)
                    tempDragDrop.moveDestination.x += Mathf.Abs(tempSlot) * 1;
                else
                    tempDragDrop.moveDestination.x += Mathf.Abs(tempSlot) * -1;

                tempCounter++;
            }
        }
    }

    public void RemoveCard(int anIndex)
    {
        //GameObject tempGameObject = Instantiate(cardObjects[selectedCard - 1], cardObjects[selectedCard - 1].transform);
        //tempGameObject.GetComponent<DragDrop>().moveDestination = discard.transform.position;
        //discardingCards.Add(tempGameObject);
        Destroy(cardObjects[anIndex]);
        discardCards.Add(handCards[anIndex]);
        handCards.RemoveAt(anIndex);
        cardObjects.RemoveAt(anIndex);
        UpdateIndex();
    }

    void UpdateIndex()
    {
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].GetComponent<DragDrop>().handIndex = i + 1;
        }
    }

    float GetHandSlot(int aSlot, int aSlotAmount)
    {
        return ((float)(aSlotAmount - 1) / 2) - aSlot;
    }

    Vector3 GetHandPosition(int aSlot, int aSlotAmount)
    {
        Vector3 tempTransform;
        float tempHandSlot = GetHandSlot(aSlot, aSlotAmount);
        tempTransform = transform.position + new Vector3((tempHandSlot * (/*cardWidth +*/ handCardDistance)), 0, 0);
        return tempTransform;
    }

    public void DrawCard(int anAmount)
    {
        for (int i = 0; i < anAmount; i++)
        {
            if (deckCards.Count <= 0)
            {
                ShuffleDiscardIntoDeck();
            }

            if (handCards.Count < handLimit)
            {
                int tempIndex = Random.Range(0, deckCards.Count);
                Card tempCard = deckCards[tempIndex];
                deckCards.RemoveAt(tempIndex);
                handCards.Add(tempCard);
                CreateCard(handCards.Count - 1);
                UpdateHand();
                //Debug.Log("draw card");
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
