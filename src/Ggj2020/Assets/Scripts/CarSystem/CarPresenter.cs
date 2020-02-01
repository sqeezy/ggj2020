using System;
using UnityEngine;
using Zenject;

public class CarPresenter : MonoBehaviour
{
	private Rigidbody _body;
	private CarData _observedData;
	private ITimeProvider _timeProvider;

	[Inject]
	public void Inject(ITimeProvider timeProvider)
	{
		_timeProvider = timeProvider;
	}

	public void Init(CarData observedData)
	{
		_body = gameObject.GetComponent<Rigidbody>();

		_observedData = observedData;
	}

	public void Update()
	{
		_observedData.SetPosition(_body.position);
	}

	public void LateUpdate()
	{
		var go = gameObject;

		var rotateDelta = _observedData.RotationVelocity * _timeProvider.DeltaTime;
		go.transform.RotateAround(_body.position, Vector3.forward, rotateDelta);

		var moveDelta = go.transform.rotation * (_observedData.Velocity * _timeProvider.DeltaTime * CarModel.Forward);
		_body.velocity = moveDelta;
	}
}