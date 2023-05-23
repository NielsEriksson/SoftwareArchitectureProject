using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [HideInInspector] public Card card;
    public TMP_Text nameText;
    public RawImage art;
    public TMP_Text descriptionText;
    public TMP_Text extraDescriptionText;

    Plant.Element[] conditions;
    public Texture2D[] elementIcons = new Texture2D[Enum.GetNames(typeof(Plant.Element)).Length];

    // Start is called before the first frame update
    void Start()
    {
        if (card != null)
        {
            nameText.text = card.cardName;
            art.texture = card.cardImage;
            descriptionText.text = card.cardDescription;
            conditions = card.conditions;
            extraDescriptionText.text = card.extraDescription;

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
