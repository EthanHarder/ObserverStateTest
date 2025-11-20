using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHurtCommand : Command
{


    public override void Execute()
    {
        FindObjectOfType<PlayerStateHandler>().GetComponent<Collider>().enabled = false;
    }

    public override void Revert()
    {
        FindObjectOfType<PlayerStateHandler>().GetComponent<Collider>().enabled = true;
    }
}
