using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFuelCommand : Command
{

    public float oldFuel = 100.0f;

    public override void Execute()
    {
        oldFuel = FindObjectOfType<PlayerStateHandler>().fuel;
        FindObjectOfType<PlayerStateHandler>().fuel += 999999.0f;
    }

    public override void Revert()
    {
        FindObjectOfType<PlayerStateHandler>().fuel = oldFuel;
    }
}
