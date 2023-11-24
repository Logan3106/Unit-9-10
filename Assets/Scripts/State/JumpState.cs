using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    StateMachine sm;
    
    public void OnEnterState(StateMachine statemachine)
    {
        sm = statemachine;
        sm.InitDebugText();

        //Debug.Log("entering jump state");
    }

    public void UpdateState()
    { 

        if (sm.rightButtonDown || sm.leftButtonDown)
        {
            sm.ChangeState(sm.runState);
        }
    }

    public void FixedUpdateState()
    {

    }

    public void OnExitState()
    {
        //Debug.Log("Exiting jump state ");
    }
}
