using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
	public Text PressedLabel;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("XAxis") > 0.02 || Input.GetAxis("XAxis") < -0.02)
		{
			PressedLabel.text = string.Format("XAxis: {0}", Input.GetAxis("XAxis"));
		}

		if (Input.GetAxis("YAxis") > 0.02 || Input.GetAxis("YAxis") < -0.02)
		{
			PressedLabel.text = string.Format("YAxis: {0}", Input.GetAxis("YAxis"));
		}

		if (Input.GetAxis("3rdAxis") > 0.02 || Input.GetAxis("3rdAxis") < -0.02)
		{
			PressedLabel.text = string.Format("3rdAxis: {0}", Input.GetAxis("3rdAxis"));
		}

		if (Input.GetAxis("4thAxis") > 0.02 || Input.GetAxis("4thAxis") < -0.02)
		{
			PressedLabel.text = string.Format("4thAxis: {0}", Input.GetAxis("4thAxis"));
		}

		if (Input.GetAxis("5thAxis") > 0.02 || Input.GetAxis("5thAxis") < -0.02)
		{
			PressedLabel.text = string.Format("5thAxis: {0}", Input.GetAxis("5thAxis"));
		}

		if (Input.GetAxis("6thAxis") > 0.02 || Input.GetAxis("6thAxis") < -0.02)
		{
			PressedLabel.text = string.Format("6thAxis: {0}", Input.GetAxis("6thAxis"));
		}


		if (Input.GetAxis("7thAxis") > 0.02 || Input.GetAxis("7thAxis") < -0.02)
		{
			PressedLabel.text = string.Format("7thAxis: {0}", Input.GetAxis("7thAxis"));
		}


		if (Input.GetAxis("8thAxis") > 0.02 || Input.GetAxis("8thAxis") < -0.02)
		{
			PressedLabel.text = string.Format("8thAxis: {0}", Input.GetAxis("8thAxis"));
		}


		if (Input.GetButtonDown("Button0"))
		{
			PressedLabel.text = string.Format("Button0:");
		}


		if (Input.GetButtonDown("Button1"))
		{
			PressedLabel.text = string.Format("Button1:");
		}


		if (Input.GetButtonDown("Button2"))
		{
			PressedLabel.text = string.Format("Button2:");
		}


		if (Input.GetButtonDown("Button3"))
		{
			PressedLabel.text = string.Format("Button3:");
		}
		
		if (Input.GetButtonDown("Button4"))
		{
			PressedLabel.text = string.Format("Button4:");
		}
		
		if (Input.GetButtonDown("Button5"))
		{
			PressedLabel.text = string.Format("Button5");
		}
		
		if (Input.GetButtonDown("Button6"))
		{
			PressedLabel.text = string.Format("Button6");
		}
		
		if (Input.GetButtonDown("Button7"))
		{
			PressedLabel.text = string.Format("Button7");
		}
	}
}