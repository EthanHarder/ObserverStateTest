using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerState
{
    float speed = 10;
    public override void StateBehaviour(Vector3 movementInput, float stateDuration)
    {
        StateHandler.transform.position += movementInput * (speed / (stateDuration * stateDuration)) * Time.deltaTime;
    }


    override public void Transition(TransitionFlag flag)
    {
        switch (flag)
        {
            default:
                break;

        }
    }
}
