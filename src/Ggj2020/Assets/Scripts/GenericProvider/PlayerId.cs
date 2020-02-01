using System;

namespace GenericProvider
{
	public class PlayerId
	{
		private const string MASTER = "master";
		private string _playerUUID = Guid.NewGuid().ToString();

		public string Get()
		{
			return _playerUUID;
		}

		public void MakeMeMaster()
		{
			_playerUUID = MASTER;
		}
	}
}