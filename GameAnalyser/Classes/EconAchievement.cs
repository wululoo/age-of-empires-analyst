using System;
using System.Collections.Generic;

namespace GameAnalyser
{
	public class EconAchievement : Achievement
	{
		public int foodCollected;
		public int woodCollected;
		public int stoneCollected;
		public int goldCollected;
		public int tradeProfit;
		public int relicGold;

		public int tributeReceived;
		public int tributeSent;

		public Dictionary<int, int> playerTributeSent;

		public EconAchievement()
		{
			playerTributeSent = new Dictionary<int, int>();
		}
	}
}
