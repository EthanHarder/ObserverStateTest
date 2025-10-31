using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveState : PlayerState
{
    float speed = 10;
    public override void StateBehaviour(Vector3 movementInput, float stateDuration)
    {
        StateHandler.transform.position += movementInput * speed * Time.deltaTime;

        StateHandler.progress += (movementInput * speed * Time.deltaTime).magnitude;
    }

    override public void Transition(TransitionFlag flag)
    {
        switch (flag)
        {
            case (TransitionFlag.Hit):
                HitState hit = new HitState();
                hit.StateHandler = StateHandler;
                StateHandler.currentState = hit;
                StateHandler.currentStateTime = 0.0f;
                break;
            case (TransitionFlag.HitOver):
                break;
            case (TransitionFlag.NoFuel):
                DeadState dead = new DeadState();
                dead.StateHandler = StateHandler;
                StateHandler.currentState = dead;
                StateHandler.currentStateTime = 0.0f;
                break;



        }
    }

}
