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
		// _observedData.DataChanged += Update;
	}

	public void Update()
	{
		_observedData.Position = _body.position;
		_observedData.Rotation = _body.rotation.eulerAngles;
	}

	public void LateUpdate()
	{
		var timeWeightedRotationDelta = _observedData.RotDelta * _timeProvider.DeltaTime;
		var timeWeightedRotationDeltaVector = _observedData.RotationDelta* _timeProvider.DeltaTime;
		var rotationDeltaEuler = Quaternion.Euler(timeWeightedRotationDeltaVector);

		gameObject.transform.RotateAround(_body.position, Vector3.forward, timeWeightedRotationDelta);

		var forwardWithoutRotation = _observedData.Velocity * _timeProvider.DeltaTime * CarModel.Forward;
		var forwardWithRotation = rotationDeltaEuler * forwardWithoutRotation ;
		_body.velocity = forwardWithRotation;
	}
}