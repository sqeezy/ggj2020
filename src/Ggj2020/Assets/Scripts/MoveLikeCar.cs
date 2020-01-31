using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;
using static UnityEngine.KeyCode;

public class MoveLikeCar : MonoBehaviour
{
	private Car State = new Car();

	private Rigidbody2D _body;

	[Inject]
	public void Init(SignalBus bus)
	{
		bus.Subscribe<InputSignals.LeftArrowUpSignal>(() => State.StopStearLeft());
		bus.Subscribe<InputSignals.LeftArrowDownSignal>(() => State.StartStearLeft());
		bus.Subscribe<InputSignals.RightArrowUpSignal>(() => State.StopStearRight());
		bus.Subscribe<InputSignals.RightArrowDownSignal>(() => State.StartStearRight());
	}

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
		if (Input.GetKeyDown(UpArrow))
		{
			State.StartAccelerate();
		}
		if (Input.GetKeyUp(UpArrow))
		{
			State.StopAccelerate();
		}

		if (Input.GetKeyDown(DownArrow))
		{
			State.StartBreak();
		}
		if (Input.GetKeyUp(DownArrow))
		{
			State.StopBreak();
		}

		State.Tick();

		gameObject.transform.position = State.Position;
		gameObject.transform.rotation = Quaternion.Euler(State.Rotation);
	}
}