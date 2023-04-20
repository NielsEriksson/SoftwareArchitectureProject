using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HoldingCard : MonoBehaviour
{
    public GameObject card;
    //public Card card;
    public bool isHolding = false;
    CardDisplay cardDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //cardDisplay = GetComponentInChildren<CardDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
        //    Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        //tempPos.z = transform.position.z;
        //transform.position = tempPos;

        //card.SetActive(isHolding);

        //if (/*isHolding &&*/ Input.GetMouseButtonUp(0))
        //{
        //    isHolding = false;
        //}
    }
}
