using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : PlayerState
{
    float speed = 10;
    public override void StateBehaviour(Vector3 movementInput, float stateDuration)
    {
        StateHandler.transform.position += movementInput * speed / (1 +stateDuration)  * Time.deltaTime;

        if (stateDuration > 3.0f)
        {
            Transition(TransitionFlag.HitOver);
        }
    }

    override public void Transition(TransitionFlag flag)
    {
        switch (flag)
        {
            case (TransitionFlag.Hit):
                break;
            case (TransitionFlag.HitOver):
                DriveState drive = new DriveState();
                drive.StateHandler = StateHandler;
                StateHandler.currentState = drive;
                StateHandler.currentStateTime = 0.0f;
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
