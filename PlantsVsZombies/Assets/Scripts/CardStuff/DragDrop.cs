using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class DragDrop : MonoBehaviour
{
    bool isDragging = false;
    bool isHovering = false;
    Vector2 startPosition;
    Quaternion previousRotation;
    PlayerCards playerCards;
    MapManager mapManager;
    Transform heldCardCanvas;
    [HideInInspector] public int handIndex;
    [HideInInspector] public Vector2 moveDestination;
    [HideInInspector] public Vector2 scaleDestination = startScale;
    [HideInInspector] public Quaternion rotationDestination;
    [HideInInspector] public bool isDiscarded = false;

    static Vector2 startScale = new Vector2 (0.5f, 0.5f);
    static Vector2 hoverScale = new Vector2 (2f, 2f);
    float transitionSpeed = 10.0f;

    void Start()
    {
        playerCards = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerCards>();
        heldCardCanvas = playerCards.GetComponentInChildren<Canvas>().transform;
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, moveDestination, Time.deltaTime * transitionSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, moveDestination.rotation, Time.deltaTime * transitionSpeed);
        }

        transform.localScale = Vector2.Lerp(transform.localScale, scaleDestination, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationDestination, Time.deltaTime * transitionSpeed);
    }

    public void StartDrag()
    {
        // Move card to held canvas
        transform.parent = heldCardCanvas;

        scaleDestination = new Vector2(1f, 1f);
        startPosition = transform.position;
        rotationDestination = Quaternion.Euler(0, 0, 0);
        isDragging = true;
        playerCards.selectedCard = handIndex;
        playerCards.UpdateHand();
    }

    public void EndDrag()
    {
        // Move card back to hand
        transform.parent = playerCards.transform;

        isDragging = false;
        playerCards.selectedCard = 0;
        if (IsDestinationValid())
        {
            moveDestination = playerCards.discard.transform.position;
            scaleDestination = startScale;
            isDiscarded = true;
        }
        else
        {
            moveDestination = startPosition;
            playerCards.UpdateHand();
        }
    }

    bool IsDestinationValid()
    {
        bool isValid = !mapManager.GetTileIsFull();
        //Debug.Log(isValid);

        if (isValid)
        {
            //Debug.Log("Plant");
            mapManager.OccupyTile(GetComponent<CardDisplay>().card.plantPrefab);
            //Plant
        }

        return isValid;
    }

    public void StartHover()
    {
        if (!isDragging)
        {
            isHovering = true;
            transform.parent = heldCardCanvas;
            scaleDestination = hoverScale;
            rotationDestination = Quaternion.Euler(0, 0, 0);
            previousRotation = transform.rotation;

            Vector2 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector2 cardSize = GetComponent<RectTransform>().sizeDelta;

            //moveDestination.y = cardSize.y;

            if (transform.position.y - (cardSize.y / 2) <-35)
            {
                Debug.Log(Screen.height / 2);
            }
            else
            {
            }

            //moveDestination.y;
            //float temp = Mathf.Clamp(transform.position.y, minScreenBounds.y, maxScreenBounds.y);
            //Debug.Log("pos: " + transform.position.y + " height: " + (cardSize.y / 2) + " screen: " + Screen.height);
            //Vector2 pos = moveDestination;
            //var refRes = (canv.transform as RectTransform).sizeDelta;

            //if (pos.y > refRes.y - rectBody.sizeDelta.y) pos.y = refRes.y - rectBody.sizeDelta.y;//up

            //Debug.Log(moveDestination.y);
            //moveDestination.y = Mathf.Clamp(moveDestination.y, 0 + cardSize.y / 2, Screen.height - cardSize.y / 2);
            //Debug.Log(moveDestination.y);
        }
    }

    public void EndHover()
    {
        if (!isDragging)
        {
            isHovering = false;
            transform.parent = playerCards.transform;
            //rotationDestination = previousRotation;
            scaleDestination = new Vector2(1f, 1f);
            playerCards.UpdateHand();
        }
    }
}
