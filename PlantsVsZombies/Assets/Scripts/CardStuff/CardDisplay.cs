using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMesh nameText;
    public TextMesh descriptionText;
    public Image art;

    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2D tempCollision = GetComponent<BoxCollider2D>();
        //tempCollision.size = GetComponent<RectTransform>().sizeDelta;

        //holdingCard = GameObject.FindGameObjectWithTag("Holding Card").GetComponent<HoldingCard>();
        if (card != null)
        {
            //descriptionText.text = card.cardDescription;
            //nameText.text = card.cardName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //if (!holdingCard.isHolding)
        //{
        //    holdingCard.card.GetComponent<CardDisplay>().card = card;
        //    holdingCard.isHolding = true;
        //}
    }
}
