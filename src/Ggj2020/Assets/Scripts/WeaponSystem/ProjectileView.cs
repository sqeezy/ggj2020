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
	}
}