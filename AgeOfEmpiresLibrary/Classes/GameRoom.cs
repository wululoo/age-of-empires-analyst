using System;
using System.Collections.Generic;

namespace AgeOfEmpiresLibrary
{
	/// <summary>
	/// Game room object.
	/// stores admin metadata of a game, including game settings, player info, game status (e.g. desynced, saved, ended)
	/// </summary>
	public class GameRoom
	{
		private DateTime date;
		private int gameTime;
		private List<Player> players;
		private List<Player> spectators;
		private List<int> teams;

		private Map map;

		private int gameMode;
		private Tuple<int, int> victorySetting;
		private int difficulty;
		private int resourceLevel;
		private int treatyLength;
		private int startAge;
		private int endAge;
		private int speed;
		private int populationCap;

		private bool teamTogether;
		private bool allTech;
		private bool lockTeam;
		private bool allowCheat;

		public GameRoom()
		{
		}
	}
}
