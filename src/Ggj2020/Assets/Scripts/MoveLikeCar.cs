using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;
using static UnityEngine.KeyCode;

public class MoveLikeCar : MonoBehaviour
{

	private Rigidbody2D _body;
	private CarData _observedData;

	public void Init(CarData observeredData)
	{
		_body = gameObject.GetComponent<Rigidbody2D>();

		_observedData = observeredData;
		_observedData.DataChanged += UpdateState;
	}

	private void UpdateState()
	{
		gameObject.transform.position = _observedData.Position;
		gameObject.transform.rotation = Quaternion.Euler(_observedData.Rotation);
	}
}