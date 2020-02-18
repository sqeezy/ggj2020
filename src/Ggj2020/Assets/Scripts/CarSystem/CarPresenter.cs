using System.Linq.Expressions;
using CarSystem;
using UnityEngine;
using Zenject;

public class MagicSingleton
{
	public static Vector3 GetStartPosition()
	{
		return PlayerConfiguration.OffsetPosition(new Vector3(GameModel.CameraPosition.x,
			GameModel.CameraPosition.y - 10, 0));
	}
}

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
			ResetCar();
		}
		else
		{
			_observedData.SetArmorLevel(_observedData.ArmorLevel - 1);
		}
	}

	private void ResetCar()
	{
		Debug.LogError("Car dead is not implemented");
	}

	public void Update()
	{
		_observedData.SetPosition(_body.position);

		Vector2 cameraXY = GameModel.CameraPosition;
		Vector2 carXY = _observedData.Position;
		
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