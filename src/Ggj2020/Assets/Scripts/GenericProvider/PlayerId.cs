using System;

namespace GenericProvider
{
	/// <summary>
	/// This class generates a player id for use over the network.
	/// Master client is the ones running the full game, everyone else is a player input device.
	/// </summary>
	public class PlayerId
	{
		private const string MASTER = "master"; //this is a magic string on the server. doughnut change
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