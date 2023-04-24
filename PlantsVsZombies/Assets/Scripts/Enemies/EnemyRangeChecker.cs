using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            gameObject.GetComponentInParent<Enemy>().isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            gameObject.GetComponentInParent<Enemy>().isInRange = false;
        }
    }
}
