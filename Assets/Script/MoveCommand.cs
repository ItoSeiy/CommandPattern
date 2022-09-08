using UnityEngine;

public class MoveCommand : ICommand
{
	private Transform _player;
	private float _v;
	private float _h;
	private float _speed;
	private Vector3 _eulers;

	public MoveCommand(Transform player,float h, float v,float speed, Vector3 eulers)
	{
		_player = player;
		_v = v;
		_h = h;
		_speed = speed;
		_eulers = eulers;
	}

	public void Execute()
	{
		var setPos = _player.position;

		setPos.y += _v * Time.deltaTime * _speed;
		setPos.x += _h * Time.deltaTime * _speed;
		
		_player.Rotate(_eulers);

		_player.position = setPos;
	}

	public void Undo()
	{
		var SetPos = _player.position;
		SetPos.y -= _v * Time.deltaTime * _speed;
		SetPos.x -= _h * Time.deltaTime * _speed;

		_player.Rotate(-_eulers);

		_player.position = SetPos;
	}
}
