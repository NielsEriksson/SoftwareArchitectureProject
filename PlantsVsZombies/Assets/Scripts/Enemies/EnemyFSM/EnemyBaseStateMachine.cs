using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBaseStateMachine : MonoBehaviour
{
    protected EnemyBaseState currentState;

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
       
    }
   
    public void ChangeState(EnemyBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    protected virtual EnemyBaseState GetInitialState()
    {
        return null;
    }    
}
