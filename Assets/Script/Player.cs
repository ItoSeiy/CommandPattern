using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed;

	private void Update()
	{
		if (CommandManager.Instance.Locked) {
			return;
		}

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 eulers = default;

		if(Input.GetKey(KeyCode.X))
        {
			eulers = new Vector3(0f, 0f, -1f);
        }
		if (Input.GetKey(KeyCode.Z))
        {
			eulers = new Vector3(0f, 0f, 1f);
        }

		var move = new MoveCommand(this.transform,h,v,_speed);
		var rotate = new RotateCommand(this.transform, _speed, eulers);

		var transformCommand = new TransformCommand(move, rotate);
		transformCommand.Execute();
		CommandManager.Instance.AddCommand(transformCommand);
	}

}
