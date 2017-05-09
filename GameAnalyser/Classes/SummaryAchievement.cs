using System;
namespace GameAnalyser
{
	public class SummaryAchievement : Achievement
	{
		public int socialScore;
		public int militaryScore;
		public int economicScore;
		public int technologyScore;
		public bool isVictory;
		public bool isMVP;
		public int civId;
		public int colourId;
		public int teamIndex;
		public int alliesCount;
		public int result;

		public SummaryAchievement()
		{
		}
	}
}
