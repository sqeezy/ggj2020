using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CarSystem
{
	public class WeaponView : MonoBehaviour
	{
		public GameObject WorldGun1Out;
		public GameObject WorldGun2Out1;
		public GameObject WorldGun2Out2;

		public List<GameObject> Stage1Weapons;
		public List<GameObject> Stage2Weapons;

		private IEnumerable<GameObject> AllWeapons => Stage1Weapons.Concat(Stage2Weapons);

		public void SetWeaponType(WeaponType type)
		{
			foreach (var weapon in AllWeapons)
			{
				weapon.SetActive(false);
			}

			if (type == WeaponType.Single)
			{
				foreach (var stage1Weapon in Stage1Weapons)
				{
					stage1Weapon.SetActive(true);
				}
			}
			else if (type == WeaponType.Triple)
			{
				foreach (var w in Stage1Weapons)
				{
					w.SetActive(true);
				}

				foreach (var w in Stage2Weapons)
				{
					w.SetActive(true);
				}
			}
		}
	}
}