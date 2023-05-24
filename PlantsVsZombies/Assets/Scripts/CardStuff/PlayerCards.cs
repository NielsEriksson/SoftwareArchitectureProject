using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    List<Card> baseDeck = new List<Card>();
    [SerializeField] public SavedDeck savedDeck;
    int startDeckSize = 20;
    int cardSelectionAmount = 3;

    float handCardDistance = 10f;
    float cardWidth;

    // Start is called before the first frame update
    void Awake()
    {
        tempCards = Resources.LoadAll<Card>("Cards");

        cardWidth = baseCard.GetComponent<RectTransform>().sizeDelta.x;

        if (savedDeck.savedCards.Count == 0)
        {
            CreateStartingDeck();
            ShuffleDeck();
        }
        else
        {
            CreateSavedDeck();
        }
   
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
    }

    void ShuffleDeck()
    {
        handCards.Clear();
        deckCards.Clear();
        discardCards.Clear();

        foreach (Card card in baseDeck)
        {
            deckCards.Add(card);
        }

        DrawCard(handLimit);
    }

    void CreateStartingDeck()
    {
        do
        {
            int tempIndex = Random.Range(0, tempCards.Length);
            if (tempCards[tempIndex].isStartingCard)
            {
                baseDeck.Add(tempCards[tempIndex]);
                savedDeck.savedCards.Add(tempCards[tempIndex]);
            }

        } while (baseDeck.Count < startDeckSize);
    }   
    public void CreateSavedDeck()
    {
        for (int i = 0; i < savedDeck.savedCards.Count; i++) 
        {
            deckCards.Add(savedDeck.savedCards[i]);
        }
        DrawCard(handLimit);
    }
    

    public Card[] GenerateCardChoices()
    {
        Card[] tempChoices = new Card[cardSelectionAmount];

        for (int i = 0; i < tempChoices.Length; i++)
        {
            int tempIndex = 0;
            do
            {
                tempIndex = Random.Range(0, tempCards.Length);
            } while (tempCards[tempIndex].isStartingCard);

            tempChoices[i] = tempCards[tempIndex];
        }

        return tempChoices;
    }

    public void AddCardToDeck(Card aCard)
    {
        baseDeck.Add(aCard);
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
