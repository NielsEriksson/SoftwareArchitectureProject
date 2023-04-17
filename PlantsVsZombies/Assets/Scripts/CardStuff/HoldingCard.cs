using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
            Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        tempPos.z = transform.position.z;
        transform.position = tempPos;
    }
}
