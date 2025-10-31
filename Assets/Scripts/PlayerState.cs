using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{

    public enum TransitionFlag
    {
        Hit,
        HitOver,
        NoFuel
    }

    public PlayerStateHandler StateHandler;

    abstract public void StateBehaviour(Vector3 movementInput, float stateDuration);

    abstract public void Transition(TransitionFlag flag);

    public virtual void SetStateHander(PlayerStateHandler handlerRef)
    {
        StateHandler = handlerRef;
    }
}
