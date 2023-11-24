using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float timer = 0;
    StateMachine sm;

    public void OnEnterState(StateMachine stateMachine)
    {
        sm = stateMachine;
        sm.InitDebugText();


        Debug.Log("entering idle state");

        // this is how to access a method that can be shared between all states
        sm.ExampleSharedMethod();
    }
    public void UpdateState()
    {
        sm.ReadButtons();

        if( sm.rightButtonDown )
        {
            sm.MoveSprite(1, 0);
            sm.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(sm.leftButtonDown)
        {
            sm.MoveSprite(-1, 0);
            sm.transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (sm.rightButtonDown == false)
        {
            sm.ChangeState(sm.runState);
        }

        if(sm.leftButtonDown == false)
        {
            sm.ChangeState(sm.runState);
        }
    }



    public void FixedUpdateState()
    {
    }
    public void OnExitState()
    {
        Debug.Log("Exiting idle state ");
    }
}
