using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantBaseStateMachine : MonoBehaviour
{
    protected PlantBaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {       
        if (currentState != null)
        {        
            currentState.Update();
            currentState.Transition();
        }
        GameObject.Find("CUrrentState").GetComponent<TMP_Text>().text = currentState.name;
    }
   
    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    protected virtual BaseState GetInitialState()
    {
        return null;
    }    
}
