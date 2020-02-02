using CarSystem;
using UnityEngine;

public class WeaponPresenter : MonoBehaviour
{
	private WeaponData _observedData;
	public WeaponView View;

	public void Init(WeaponData observedData)
	{
		_observedData = observedData;

		View.SetWeaponType(_observedData.Type);
	}
}