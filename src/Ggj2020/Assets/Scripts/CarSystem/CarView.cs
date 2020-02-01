using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CarView : MonoBehaviour
{
	public Color MainColor;
	public Color WindowColor;

	public List<SpriteRenderer> MainColorSprites;
	public List<SpriteRenderer> WindowColorSprites;

	public GameObject LightLeft;
	public GameObject LightRight;
	
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
		LightLeft.SetActive(true);
		LightRight.SetActive(false);
	}
	
	public void EnableLightsRight()
	{
		LightLeft.SetActive(false);
		LightRight.SetActive(true);
	}
	
	public void DisableShadows()
	{
		LightLeft.SetActive(false);
		LightRight.SetActive(false);
	}



	private void OnTriggerEnter(Collider other)
	{
		var light = other.gameObject.GetComponent<SpriteLight>();
		if (light != null)
		{
			var targteDir = transform.position - light.transform.position;
			var dir = AngleDir(transform.up, targteDir, transform.forward);
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

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}
}