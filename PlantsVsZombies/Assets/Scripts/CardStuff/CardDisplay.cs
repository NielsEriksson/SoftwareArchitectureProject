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
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
