using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler : MonoBehaviour
{

    public Stack<Command> commands;

    public void Start()
    {
        commands = new Stack<Command>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Command com = new InfiniteFuelCommand();
            ReceiveCommand(com);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Command com = new NoHurtCommand();
            ReceiveCommand(com);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoCommand();
        }

    }


    public void ReceiveCommand(Command com)
    {
        commands.Push(com);
        com.Execute();
    }


    public void UndoCommand()
    {
        if (commands.Count <= 0) return;
        Command com = commands.Pop();
        com.Revert();

    }
}
