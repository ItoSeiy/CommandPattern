using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : ICommand
{
    private Transform _player;
    private float _speed;
    private Vector3 _eulers;

    public RotateCommand(Transform player, float speed, Vector3 eulers)
    {
        _player = player;
        _speed = speed;
        _eulers = eulers;
    }

    public void Execute()
    {
        _player.Rotate(_eulers * _speed);
    }

    public void Undo()
    {
        _player.Rotate(-_eulers * _speed);
    }
}
