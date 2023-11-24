using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    float timer = 0;
    float xVelocity = 1;
    StateMachine sm;
    public void OnEnterState(StateMachine stateMachine)
    {
        sm = stateMachine;
        sm.InitDebugText();

    }
    public void UpdateState()
    {
        sm.ReadButtons();

        if (sm.rightButtonDown)
        {
            sm.ChangeState(sm.idleState);
        }

        if (sm.leftButtonDown)
        {
            sm.ChangeState(sm.idleState);
        }
    }

    public void FixedUpdateState()
    {
        // Physics update
    }
    public void OnExitState()
    {
        // Exiting this state
    }
}
