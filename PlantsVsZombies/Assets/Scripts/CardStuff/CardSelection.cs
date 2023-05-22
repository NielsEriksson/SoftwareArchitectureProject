using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    PlayerCards playerCards;
    Card[] cardChoices;
    List<GameObject> cardObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerCards = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerCards>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardChoices == null)
        {
            GenetateCards();
        }
    }

    void GenetateCards()
    {
        cardChoices = playerCards.GenerateCardChoices();

        for (int i = 0; i < cardChoices.Length; i++)
        {
            Debug.Log("card generated");
            GameObject tempObject = Instantiate(playerCards.baseCard, transform);
            tempObject.GetComponent<CardDisplay>().card = cardChoices[i];
            tempObject.GetComponent<DragDrop>().isChoice = true;
            tempObject.GetComponent<DragDrop>().enabled = false;
            tempObject.transform.localScale = new Vector2(2, 2);
            tempObject.transform.localPosition = Vector2.zero;
            cardObjects.Add(tempObject);
        }
    }
}
