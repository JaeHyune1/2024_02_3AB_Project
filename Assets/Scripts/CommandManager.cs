using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface lCommand
{
    void Excute();

    void Undo();
}

public class MoveCommand : lCommand
{
    private Transform objectToMove;
    private Vector3 displacement;

    public MoveCommand(Transform obj, Vector3 displacement)
    {
        this.objectToMove = obj;
        this.displacement = displacement;
    }

    public void Execute() { objectToMove.position += displacement; }

    public void Undo() { objectToMove.position -= displacement; }
}
public class CommandManager : MonoBehaviour
{
    private Stack<lCommand> commandHistory = new Stack<lCommand>();
    
    public void ExecuteCommand(lCommand command)
    {
        command.Excute();
        commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            lCommand lastcommand = commandHistory.Pop();
            lastcommand.Undo();
        }
    }
}
