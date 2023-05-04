using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    bool isDragging = false;
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
        bool isTrue = mapManager.GetTileIsFull();

        if (isTrue)
        {
            mapManager.OccupyTile(GetComponentInChildren<Card>().plantPrefab);
            //Plant
        }

        return isTrue;
    }

    public void StartHover()
    {
        if (!isDragging)
        {
            transform.parent = heldCardCanvas;
            scaleDestination = hoverScale;
            rotationDestination = Quaternion.Euler(0, 0, 0);
            previousRotation = transform.rotation;

            Vector2 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            //moveDestination.y = Mathf.Clamp(transform.position.y, minScreenBounds.y + 115, maxScreenBounds.y);
            Debug.Log(Screen.width);
        }
    }

    public void EndHover()
    {
        if (!isDragging)
        {
            transform.parent = playerCards.transform;
            //rotationDestination = previousRotation;
            scaleDestination = new Vector2(1f, 1f);
            playerCards.UpdateHand();
        }
    }
}
