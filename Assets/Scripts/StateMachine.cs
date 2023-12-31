using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(StateMachine sm);
    public void OnExitState();
}
public class StateMachine : MonoBehaviour
{
     // attach this script to your player or enemy object that requires a state machine
    public IState currentState, lastState;
    public IdleState idleState = new IdleState();
    public RunState runState = new RunState();
    public JumpState jumpState = new JumpState();
    public Rigidbody2D rb;
    public float speed = 2;
    public float baseVelocity = 1;

    public bool rightButtonDown;
    public bool leftButtonDown;

        // debug text
    public string text;


      private void Start()
      {
        text = "";  // clear debug text

        rb = GetComponent<Rigidbody2D>();

        lastState = null;
        // this is the inital state
        ChangeState(idleState);
      }

      public void Update()
      {
        if (currentState != null)
        {
          currentState.UpdateState();
        }

      }

      private void FixedUpdate()
      {
        if (currentState != null)
        {
          currentState.FixedUpdateState();
        }
      }

      public void ChangeState(IState newState)
      {
        if (currentState != null)
        {
          currentState.OnExitState();
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
      }


      public IState GetState()
      {
        return currentState;
      }


            // Debug Text Draw - draws the string 'text' to the canvas
      private void OnGUI()
      {
       GUILayout.BeginArea(new Rect(10f, 10f, 1600f, 1600f));
       GUILayout.Label($"<color=white><size=24>{text}</size></color>");
       GUILayout.EndArea();
      }

      public void ExampleSharedMethod()
      {
        // this in an example method that can be shared by any state
      }

    

      public void MoveSprite(float xv, float yv)
      {
       rb.velocity = new Vector3(xv, yv, 0);

      }


    public void ReadButtons()
    {
        //print("right button down=" + rightButtonDown);
        //print("left button down=" + leftButtonDown);
        //print("jump button down=" + jumpButtonDown);
    }

    public void RightButtonPressed()
    {
        rightButtonDown = true;
    }

    public void RightButtonreleased()
    {
        rightButtonDown = false;
    }

    public void LeftButtonPressed()
    {
        leftButtonDown = true;
    }

    public void LeftButtonreleased()
    {
        leftButtonDown = false;
    }

    public void PlayerJumping()
    {
        Vector2 moveDirect = new Vector2(0, 1);
        rb.AddForce(moveDirect.normalized * 2 * 165, ForceMode2D.Force);
        print("Jumping");
    }

    public void InitDebugText()
    {
    string lastStateText;

    if (lastState != null)
       lastStateText = lastState.ToString();
    else
       lastStateText = "null";
       text = $"Current State = Idle\nLast state was {lastStateText}\nPress R to change to Run state\nPress I to change to Idle state";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene(2);
        }
    }
}