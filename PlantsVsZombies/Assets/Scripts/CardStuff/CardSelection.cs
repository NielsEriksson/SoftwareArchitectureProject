using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    [SerializeField] PlayerCards playerCards;
    [SerializeField] InterLevelUi interLevelUi;
    Card[] cardChoices;
    List<GameObject> cardObjects = new List<GameObject>();
    public int numberOfCardsToAdd = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerCards = FindObjectOfType<PlayerCards>();
    }

    // Update is called once per frame
  

    public void GenetateCards()
    {
        if (cardChoices == null)
        {
           
            cardChoices = playerCards.GenerateCardChoices();

            for (int i = 0; i < cardChoices.Length; i++)
            {
                GameObject tempObject = Instantiate(playerCards.baseCard, transform);
                tempObject.GetComponent<CardDisplay>().card = cardChoices[i];
                tempObject.GetComponent<DragDrop>().isChoice = true;
                //tempObject.GetComponent<DragDrop>().enabled = false;
                tempObject.transform.localScale = new Vector2(2, 2);
                tempObject.transform.localPosition = Vector2.zero;
                cardObjects.Add(tempObject);
            }
        }
    }

    public void DeleteCards()
    {
    
        interLevelUi.cardSelected = true;
        foreach (var card in cardObjects)
        {
            Destroy(card);
        }
     
    }
}
