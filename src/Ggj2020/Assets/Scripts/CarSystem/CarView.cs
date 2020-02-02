using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarSystem
{
	public class CarView : MonoBehaviour
	{
		public Color MainColor;
		public Color WindowColor;

		public List<SpriteRenderer> MainColorSprites;
		public List<SpriteRenderer> WindowColorSprites;

		public List<GameObject> LeftLights;
		public List<GameObject> RightLights;

		[Range(0,7)]
		public int ArmorLevel;
		public List<CarLevel> AvailableLevels;

		private void Update()
		{
			foreach (SpriteRenderer mainSprite in MainColorSprites)
			{
				mainSprite.material.color = MainColor;
			}

			foreach (SpriteRenderer windowSprite in WindowColorSprites)
			{
				windowSprite.material.color = WindowColor;
			}
		}

		public void EnableLightsLeft()
		{
			foreach (var leftLight in LeftLights)
			{
				leftLight.SetActive(true);
			}

			foreach (var rightLight in RightLights)
			{
				rightLight.SetActive(false);
			}
		}

		public void EnableLightsRight()
		{
			foreach (var leftLight in LeftLights)
			{
				leftLight.SetActive(false);
			}

			foreach (var rightLight in RightLights)
			{
				rightLight.SetActive(true);
			}
		}

		public void DisableShadows()
		{
			foreach (var leftLight in LeftLights)
			{
				leftLight.SetActive(false);
			}

			foreach (var rightLight in RightLights)
			{
				rightLight.SetActive(false);
			}
		}


		public void SetArmorLevel(int armorLevel)
		{
			var oldLevel = AvailableLevels[ArmorLevel];
			var newLevel = AvailableLevels[armorLevel];
			oldLevel.DeActivateLevel();
			newLevel.ActivateLevel();
			ArmorLevel = armorLevel;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.GetComponent<SpriteLight>() is SpriteLight spriteLight)
			{
				var t = transform;
				var targetDir = t.position - spriteLight.transform.position;
				var dir = AngleDir(t.up, targetDir, t.forward);
				if (dir < 0)
				{
					EnableLightsRight();
				}
				else
				{
					EnableLightsLeft();
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			var light = other.gameObject.GetComponent<SpriteLight>();
			if (light != null)
			{
				DisableShadows();
			}
		}

		private float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
		{
			var perpendicular = Vector3.Cross(fwd, targetDir);
			var direction = Vector3.Dot(perpendicular, up);

			if (direction > 0f)
			{
				return 1f;
			}

			if (direction < 0f)
			{
				return -1f;
			}

			return 0f;
		}

		public event Action CarWasHit = () => { };
		public void ForwardHit()
		{
			CarWasHit();
		}
	}
}