using System;
using System.Collections.Generic;

namespace GameAnalyser
{
	public class Team
	{
		public int index = -1;
		public Dictionary<int, bool> playersStatus;
		public bool defeated;

		public Team()
		{
			playersStatus = new Dictionary<int, bool>();
			defeated = false;
		}

		public void addPlayer(int player)
		{
			playersStatus[player] = true;
		}

		public void updatePlayer(int player, bool inGame)
		{
			if (playersStatus.ContainsKey(player) && playersStatus[player] != inGame)
			{
				playersStatus[player] = inGame;

				bool defeatedTest = true;
				foreach (var i in playersStatus)
				{
					if (playersStatus[player] == true)
					{
						defeatedTest = false;
						break;
					}
				}
				defeated = defeatedTest;
			}
		}

		internal int getIndex()
		{
			return index;
		}

		internal void setIndex(int id)
		{
			this.index = id;
		}
	}
}
