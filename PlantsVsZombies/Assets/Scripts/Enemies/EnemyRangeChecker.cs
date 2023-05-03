using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeChecker : MonoBehaviour
{
    public bool hasTarget = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            //To make sure it only hits 1 target at a time unless stated otherwise(might be more applicable to plants though)
            if (!hasTarget)
            {
                gameObject.GetComponentInParent<Enemy>().target = collision.gameObject.GetComponent<Plant>();
                hasTarget = true;
            }
            gameObject.GetComponentInParent<Enemy>().isInRange = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            //To make sure it only hits 1 target at a time unless stated otherwise(might be more applicable to plants though)
            if (!hasTarget)
            {
                gameObject.GetComponentInParent<Enemy>().target = collision.gameObject.GetComponent<Plant>();
                hasTarget = true;
            }
            gameObject.GetComponentInParent<Enemy>().isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            if (gameObject.GetComponentInParent<Enemy>().target == collision.gameObject.GetComponent<Plant>())
            {
                hasTarget = false;
                gameObject.GetComponentInParent<Enemy>().target = null;
            }
            gameObject.GetComponentInParent<Enemy>().isInRange = false;
        }
    }
}
