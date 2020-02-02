using System.Collections;
using System.Collections.Generic;
using GenericProvider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GyroInput : MonoBehaviour
{
	public Text GyroValue;

	private SignalBus _signalBus;
	private PlayerId _playerId;

	// Start is called before the first frame update
	[Inject]
	public void Init(SignalBus signalBus, PlayerId playerId)
	{
		_signalBus = signalBus;
		_playerId = playerId;
	}

	// Update is called once per frame
	void Update()
	{
		var qRot =  GyroToUnity(Input.gyro.attitude);
		var rotation = qRot.eulerAngles;
		GyroValue.text = string.Format("X: {0}, Y: {1}, Z: {2}", rotation.x, rotation.y, rotation.z);
		if (rotation.z > 15)
		{
			_signalBus.Fire(new InputSignal.LeftArrowDown(_playerId.Get()).ToNetwork());
		}
		else
		{
			_signalBus.Fire(new InputSignal.LeftArrowUp(_playerId.Get()).ToNetwork());
		}

		if (rotation.z < -15)
		{
			_signalBus.Fire(new InputSignal.RightArrowUp(_playerId.Get()).ToNetwork());
		}
		else
		{
			_signalBus.Fire(new InputSignal.RightArrowDown(_playerId.Get()).ToNetwork());
		}

	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
}