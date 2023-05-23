using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ElementControl : MonoBehaviour
{
    [SerializeField] public List<Plant.Element> elements = new List<Plant.Element>();
    [SerializeField] private TMP_Text Water;
    [SerializeField] private TMP_Text Sun;
    [SerializeField] private TMP_Text Poison;
    int WaterNumber;
    int SunNumber;
    int PoisonNumber;
    // Start is called before the first frame update
    void Start()
    {
        UpdateElements();
    }

    public void UpdateElements()
    {
        elements.Clear();
        WaterNumber = 0;
        SunNumber = 0;
        PoisonNumber = 0;
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
                if (element == Plant.Element.Light){
                    SunNumber++;
                }
                else if (element == Plant.Element.Water){
                    WaterNumber++;
                }
                else if (element == Plant.Element.Poison){
                    PoisonNumber++;
                }
            }
        }
        Water.text = WaterNumber.ToString();
        Sun.text = SunNumber.ToString();
        Poison.text = PoisonNumber.ToString();
    }
}
