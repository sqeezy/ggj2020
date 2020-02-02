using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GenericProvider
{
	public class URLReader
	{
		[DllImport("__Internal")]
		private static extern string GetURLFromPage();

		[DllImport("__Internal")]
		private static extern string GetQueryParam(string paramId);

		//Change this to true, to run in master mode in the Unity editor
		private const bool DEFAULT_MASTER = false;

		public string ReadQueryParam(string paramId)
		{
			try
			{
				return GetQueryParam(paramId);
			}
			catch (Exception e)
			{
				Debug.Log("Could not detect url we are running on, probably a Unity play mode?");
				return null;
			}
		}

		public bool AmIMaster()
		{
			var readQueryParam = ReadQueryParam("master");
			if (readQueryParam == null)
			{
				return DEFAULT_MASTER;
			}

			return readQueryParam == "true";
		}

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