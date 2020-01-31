using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.KeyCode;

public class MoveLikeCar : MonoBehaviour
{
	private Car State = new Car();

	private Rigidbody2D _body;

	// Start is called before the first frame update
	private void Start()
	{
		_body = gameObject.GetComponent<Rigidbody2D>();
		State.UpdatePosition(gameObject.transform.position);
		State.UpdateRotation(gameObject.transform.rotation);
	}

	private bool Down(KeyCode k) => Input.GetKeyDown(k);
	private bool Up(KeyCode k) => Input.GetKeyUp(k);

	// Update is called once per frame
	private void Update()
	{
		if (Down(RightArrow))
		{
			State.StartStearRight();
		}

		if (Up(RightArrow))
		{
			State.StopStearRight();
		}

		if (Down(LeftArrow))
		{
			State.StartStearLeft();
		}

		if (Up(LeftArrow))
		{
			State.StopStearLeft();
		}

		State.Tick();

		gameObject.transform.position = State.Position;
		gameObject.transform.rotation = Quaternion.Euler(State.Rotation);
	}
}