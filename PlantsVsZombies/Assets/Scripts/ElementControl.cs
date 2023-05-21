using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementControl : MonoBehaviour
{
    [SerializeField] public List<Plant.Element> elements;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateElements()
    {
        elements = new List<Plant.Element>();
        
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Plant");
        List<Plant> plants = new List<Plant>();

        List<Plant.Element> plantelements = new List<Plant.Element>();

        foreach (GameObject go in gameObjects)
        {
            List<Plant.Element> temp = new List<Plant.Element>();
            temp = go.GetComponent<Plant>().containsElements;

            foreach (Plant.Element element in temp)
            {
                elements.Add(element);
            }
        }
    }
}
