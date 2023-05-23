using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [HideInInspector] public Card card;
    public TMP_Text nameText;
    public RawImage art;
    public TMP_Text descriptionText;
    public TMP_Text extraDescriptionText;
    public GameObject baseElement;

    Plant.Element[] conditions;
    public Texture2D[] elementIcons = new Texture2D[Enum.GetNames(typeof(Plant.Element)).Length];
    List<GameObject> elementObject = new List<GameObject>();

    const float elementDistance = 20f;

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

            int counter = 0;
            foreach (var element in conditions)
            {
                GameObject tempObject = Instantiate(baseElement, GetComponentInChildren<HorizontalLayoutGroup>().gameObject.transform);
                tempObject.GetComponent<RawImage>().texture = elementIcons[(int)element];
                //float tempX = ((float)(conditions.Length - 1) / 2) - counter;
                //tempObject.transform.position += new Vector3(tempX * elementDistance, 0, 0);
                elementObject.Add(tempObject);
            }
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
