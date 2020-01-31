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
		bus.Subscribe<InputSignals.LeftArrowUp>(() => State.StopStearLeft());
		bus.Subscribe<InputSignals.LeftArrowDown>(() => State.StartStearLeft());
		bus.Subscribe<InputSignals.RightArrowUp>(() => State.StopStearRight());
		bus.Subscribe<InputSignals.RightArrowDown>(() => State.StartStearRight());
		bus.Subscribe<InputSignals.ForwardArrowDown>(()=>State.StartAccelerate());
		bus.Subscribe<InputSignals.ForwardArrowUp>(()=>State.StopAccelerate());
		bus.Subscribe<InputSignals.DownArrowDown>(()=>State.StartBreak());
		bus.Subscribe<InputSignals.DownArrowUp>(()=>State.StopBreak());
	}

	// Start is called before the first frame update
	private void Start()
	{
		_body = gameObject.GetComponent<Rigidbody2D>();
		State.UpdatePosition(gameObject.transform.position);
		State.UpdateRotation(gameObject.transform.rotation);
	}

	// Update is called once per frame
	private void Update()
	{

		State.Tick();

		gameObject.transform.position = State.Position;
		gameObject.transform.rotation = Quaternion.Euler(State.Rotation);
	}
}