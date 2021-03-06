using Casanova.core.main.units;
using Godot;

namespace Casanova.core.net.types
{
	public class Player
	{
		public readonly int Id;
		public readonly string Username;
		public PlayerUnit PlayerUnit;
		public readonly bool IsLocal;

		public Player(int id, string username, PlayerUnit playerUnit, bool isLocal = false)
		{
			Id = id;
			Username = username;
			PlayerUnit = playerUnit;
			IsLocal = isLocal;
		}
	}
}
