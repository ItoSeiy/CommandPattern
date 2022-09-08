using UnityEngine;

public class MoveCommand : ICommand
{
	private Transform _player;
	private float _v;
	private float _h;
	private float _speed;

	public MoveCommand(Transform player,float h, float v,float speed)
	{
		_player = player;
		_v = v;
		_h = h;
		_speed = speed;
	}

	public void Execute()
	{
		var setPos = _player.position;

		setPos.y += _v * Time.deltaTime * _speed;
		setPos.x += _h * Time.deltaTime * _speed;
		
		_player.position = setPos;
	}

	public void Undo()
	{
		var SetPos = _player.position;
		SetPos.y -= _v * Time.deltaTime * _speed;
		SetPos.x -= _h * Time.deltaTime * _speed;

		_player.position = SetPos;
	}
}
