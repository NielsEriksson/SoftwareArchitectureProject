using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    HoldingCard holdingCard;
    public Card card;
    public TextMesh nameText;
    public TextMesh descriptionText;
    public Image art;

    // Start is called before the first frame update
    void Start()
    {
        holdingCard = GameObject.FindGameObjectWithTag("Holding Card").GetComponent<HoldingCard>();
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!holdingCard.isHolding)
        {
            holdingCard.card.GetComponent<CardDisplay>().card = card;
            holdingCard.isHolding = true;
        }
    }
}
