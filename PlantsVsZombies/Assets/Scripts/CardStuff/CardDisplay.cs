using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TMP_Text nameText;
    public Image art;
    public TMP_Text descriptionText;
    public TMP_Text extraDescriptionText;

    Plant.Element[] conditions;
    public Image[] elementIcons = new Image[Enum.GetNames(typeof(Plant.Element)).Length];

    // Start is called before the first frame update
    void Start()
    {
        if (card != null)
        {
            nameText.text = card.cardName;
            descriptionText.text = card.cardDescription;
            //extraDescriptionText.text = card.extraDescription;
            //conditions = card.conditions;

            //public string cardName;
            //public Image cardImage;
            //public string cardDescription;
            //public Plant.Element[] conditions;
            //public string extraDescription;
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
