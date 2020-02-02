using System;
using UnityEngine;
using Zenject;

namespace CarSystem
{
	public class ProjectileView : MonoBehaviour
	{
		private ITimeProvider _timeProvider;

		[Inject]
		public void Inject(ITimeProvider timeProvider)
		{
			_timeProvider = timeProvider;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<CarView>() is CarView car)
			{
				car.ForwardHit();
				Destroy(this);
			}
		}

		private void Update()
		{
			var go = gameObject;
			var position = go.transform.position;

			go.transform.position = position + position * (WeaponModel.MaxVelocity/2 * _timeProvider.DeltaTime);
		}

		public void StartFly(Vector3 start, Quaternion direction)
		{
			var go = gameObject;
			go.transform.position = start;
			go.transform.rotation = direction;
		}
	}
}