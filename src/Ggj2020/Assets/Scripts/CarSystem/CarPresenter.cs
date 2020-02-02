using CarSystem;
using UnityEngine;
using Zenject;

public class CarPresenter : MonoBehaviour
{
	public CarView View;

	private Rigidbody _body;
	private CarData _observedData;
	private ITimeProvider _timeProvider;

	[Inject]
	public void Inject(ITimeProvider timeProvider)
	{
		_timeProvider = timeProvider;
	}

	private void CheckUpgrades()
	{
		View.SetArmorLevel(_observedData.ArmorLevel);
	}

	public void Init(CarData observedData)
	{
		_body = gameObject.GetComponent<Rigidbody>();

		_observedData = observedData;
		_observedData.DataChanged += CheckUpgrades;

		View.LooseArmorRequested += ResolveHit;
	}

	private void ResolveHit()
	{
		if (_observedData.ArmorLevel == 0)
		{
			//reset
		}
		else
		{
			_observedData.SetArmorLevel(_observedData.ArmorLevel - 1);
		}
	}

	public void Update()
	{
		_observedData.SetPosition(_body.position);
	}

	public void LateUpdate()
	{
		UpdateMovement();
	}

	private void UpdateMovement()
	{
		var go = gameObject;

		var rotateDelta = _observedData.RotationVelocity * _timeProvider.DeltaTime;
		go.transform.RotateAround(_body.position, Vector3.forward, rotateDelta);

		var moveDelta = go.transform.rotation * (_observedData.Velocity * CarModel.Forward);
		_body.velocity = moveDelta;
		_body.angularVelocity = Vector3.zero;
	}
}