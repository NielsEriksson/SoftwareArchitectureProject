using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRangeChecker : MonoBehaviour
{
    private Plant plant;
    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponentInParent<Plant>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           plant.isInRange = true;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            plant.isInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            plant.isInRange = false;
        }
    }
}
