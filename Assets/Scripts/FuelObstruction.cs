using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelObstruction : Obstruction
{
    protected override void ObstructionHit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Hit car");
            other.GetComponent<PlayerStateHandler>().fuel = other.GetComponent<PlayerStateHandler>().maxFuel;
        }
    }
}
