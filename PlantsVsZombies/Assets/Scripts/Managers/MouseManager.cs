using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    private MapManager mapManager;
    void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && mapManager.GetTileIsEmpty(mousePos)){ //if we press the button and position is empty
        //     print("hello");
        //     GameObject newObject = Instantiate(spawnObject); //spawn object
        //     newObject.transform.position = mapManager.GetTilePos(mousePos); //set pos
        //     mapManager.OcupyTile(mousePos); //ocupy the place
        }
        
    }
}
