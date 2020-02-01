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
		var go = gameObject;

		var rotateDelta = _observedData.RotVelo * _timeProvider.DeltaTime;
		go.transform.RotateAround(_body.position, Vector3.forward, rotateDelta);

		var moveDelta = go.transform.rotation * (_observedData.Velocity * _timeProvider.DeltaTime * CarModel.Forward);
		_body.velocity = moveDelta;
	}

	private void OnCollisionEnter(Collision other)
	{
		foreach (ContactPoint contact in other.contacts)
		{
			Debug.Log(string.Format("Hit object: {0}", contact.thisCollider.gameObject.name));
		}
	}
}