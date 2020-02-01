
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

	public void LateUpdate()
	{
		_body.velocity = Vector3.zero;
		_body.angularVelocity = Vector3.zero;
	}

	public void Update()
	{
		_body.AddRelativeForce(0, _observedData.Velocity * 500 * _timeProvider.DeltaTime, 0);
		gameObject.transform.rotation = Quaternion.Euler(_observedData.Rotation * _timeProvider.DeltaTime);
	}
}