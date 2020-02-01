using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GenericProvider
{
	public class URLReader
	{
		[DllImport("__Internal")]
		private static extern string GetURLFromPage();

		public string ReadURL()
		{
			try
			{
				return GetURLFromPage();
			}
			catch (Exception e)
			{
				Debug.Log("Could not detect url we are running on, probably a Unity play mode?");
				return "http://localhost:8080/";
			}
		}
	}

}