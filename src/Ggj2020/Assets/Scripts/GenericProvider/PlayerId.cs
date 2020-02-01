using System;

namespace GenericProvider
{
	public class PlayerId
	{
		private readonly string _playerUUID = "totally_random"; //TODO generate

		public string get()
		{
			return _playerUUID;
		}
	}
}