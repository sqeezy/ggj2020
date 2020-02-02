using System;
using Environment;
using UnityEngine;
using Zenject;

namespace CarSystem
{
	public class ProjectileView : MonoBehaviour
	{
		private ITimeProvider _timeProvider;
		private float _traveledDistance = 0;

		[Inject]
		public void Inject(ITimeProvider timeProvider)
		{
			_timeProvider = timeProvider;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Obstacle>() != null)
			{
				Destroy(gameObject);
			}

			var carView = other.gameObject.GetComponent<CarView>();
			if (carView == null)
			{
				carView = other.GetComponentInParent<CarView>();
			}

			if (carView is CarView car)
			{
				car.ForwardHit();
				Destroy(gameObject);
			}
		}

		private void Update()
		{
			if (_traveledDistance > 50)
			{
				Destroy(this);
				gameObject.SetActive(false);
				return;
			}

			var go = gameObject;
			var position = go.transform.position;

			var translation = go.transform.up * (WeaponModel.MaxVelocity * _timeProvider.DeltaTime);
			position += translation;
			go.transform.position = position;
			_traveledDistance += translation.magnitude;
		}


		public void StartFly(Transform parentTransform)
		{
			var o = gameObject;
			o.transform.SetParent(parentTransform);
			o.transform.localPosition = Vector3.zero;
			o.transform.localRotation = Quaternion.identity;
			gameObject.transform.SetParent(null);
			o.transform.localPosition += o.transform.up * 4;
		}
	}
}