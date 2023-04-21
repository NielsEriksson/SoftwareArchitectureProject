using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    bool isDragging = false;
    Vector2 startPosition;
    PlayerCards playerCards;
    [HideInInspector] public int handIndex;
    [HideInInspector] public Vector2 moveDestination;
    [HideInInspector] public Vector2 scaleDestination = startScale;
    [HideInInspector] public bool isDiscarded = false;

    static Vector2 startScale = new Vector2 (0.5f, 0.5f);
    float transitionSpeed = 10.0f;

    void Start()
    {
        playerCards = GameObject.FindGameObjectWithTag("Hand").GetComponent<PlayerCards>();
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
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
        playerCards.selectedCard = handIndex;
        playerCards.UpdateHand();
    }

    public void EndDrag()
    {
        isDragging = false;
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
        playerCards.selectedCard = 0;
    }

    bool IsDestinationValid()
    {
        return true;
    }
}
