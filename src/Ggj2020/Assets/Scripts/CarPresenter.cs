using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;
using static UnityEngine.KeyCode;

public class CarPresenter : MonoBehaviour
{
	private Rigidbody _body;
	private CarData _observedData;

	public void Init(CarData observeredData)
	{
		_body = gameObject.GetComponent<Rigidbody>();

		_observedData = observeredData;
		_observedData.DataChanged += UpdateState;
	}

	private void LateUpdate()
	{
		_body.velocity = Vector3.zero;
		_body.angularVelocity = Vector3.zero;
	}

	private void UpdateState()
	{
		var moveVector = _observedData.Position - gameObject.transform.position;
		// _body.velocity = new Vector2(moveVector.x, moveVector.y);
		// _body.AddForce(new Vector2(moveVector.x, moveVector.y));
		// gameObject.transform.position = _observedData.Position;
		_body.AddRelativeForce(0, _observedData.Velocity * 500, 0);
		gameObject.transform.rotation = Quaternion.Euler(_observedData.Rotation);
	}
}