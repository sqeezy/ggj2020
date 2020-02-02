using System;
using UnityEngine;

namespace CarSystem
{
	public class ProjectileView : MonoBehaviour
	{
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

			go.transform.position = position + position * WeaponModel.MaxVelocity;
		}

		public void StartFly(Vector3 start, Quaternion direction)
		{
			var go = gameObject;
			go.transform.position = start;
			go.transform.rotation = direction;
		}
	}
}