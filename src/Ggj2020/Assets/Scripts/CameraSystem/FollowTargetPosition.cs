using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPosition : MonoBehaviour
{
	public Transform Target;
	private Vector3 _positionOffset;
	private Vector3 _rotationOffset;

	void Start()
	{
		_positionOffset = transform.position - Target.position;
		_rotationOffset = transform.rotation.eulerAngles - Target.rotation.eulerAngles;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Target.position + _positionOffset;
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + _rotationOffset);
	}
}