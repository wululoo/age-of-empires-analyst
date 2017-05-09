using System;
namespace GameAnalyser
{
	public class VictorySetting
	{
		public int timeLimit = 0;

		public int scoreLimit = 0;

		public int mode = GameType.VICTORY_STANDARD;
		public int customRelic;
		public int customPercentExplored;
		public int customAll;
		public int customConquest;

		public VictorySetting()
		{
		}

		public override string ToString()
		{
			try
			{
				switch (mode)
				{
					case GameType.VICTORY_TIMELIMIT:
						if (timeLimit > 0)
						{
							return GameType.VICTORY_CONDITION[mode] + " (" + timeLimit.ToString() + ")";
						}
						else
							return "";

					case GameType.VICTORY_SCORELIMIT:
						if (scoreLimit > 0)
						{
							return GameType.VICTORY_CONDITION[mode] + " (" + scoreLimit.ToString() + ")";
						}
						else
							return "";

					default:
						return GameType.VICTORY_CONDITION[mode];
				}
			}
			catch
			{
				return "";
			}
		}

		public void setGameMode(int gameMode)
		{
			mode = gameMode;
		}

		public void setTimeLimit(int timeLimit)
		{
			this.timeLimit = timeLimit;

			if (timeLimit > 0)
				mode = GameType.VICTORY_TIMELIMIT;
		}

		public void setRelicVictory(int relicCount)
		{
			customRelic = relicCount;
		}

		public void setExplorationVictory(int percentExplore)
		{
			customPercentExplored = percentExplore;
		}

		public void setCustomVictory(int detail)
		{
			customAll = detail == 0 ? 0 : 1;
		}

		public void setConquestVictory()
		{
			//customConquest = conquest == 0 ? 0 : 1;
		}

		public void setScoreLimit(int score)
		{
			scoreLimit = score;
			if (score > 0)
				mode = GameType.VICTORY_SCORELIMIT;
		}
	}
}
