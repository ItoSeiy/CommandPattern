using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCommand : ICommand
{
    ICommand _moveCommand = default;

    ICommand _rotateCommand = default;

    public TransformCommand(ICommand moveCommand, ICommand rotateCommand)
    {
        _moveCommand = moveCommand;
        _rotateCommand = rotateCommand;
    }

    public void Execute()
    {
        _moveCommand.Execute();
        _rotateCommand.Execute();
    }

    public void Undo()
    {
        _moveCommand.Undo();
        _rotateCommand.Undo();
    }
}
