using System;
using System.Collections.Generic;

namespace GameAnalyser
{
	public class MilitaryAchievement : Achievement
	{
		public int unitsKilled;
		public int unitsLost;
		public int hitPointsKilled;
		public int hitPointsRazed;
		public int buildingsRazed;
		public int buildingsLost;
		public int unitsConverted;
		public int largestArmy;

		public Dictionary<int, int> playerUnitsKilled;
		public Dictionary<int, int> playerBuildingsRazed;

		public MilitaryAchievement()
		{
			playerUnitsKilled = new Dictionary<int, int>();
			playerBuildingsRazed = new Dictionary<int, int>();
		}
	}
}
