using System;
namespace GameAnalyser
{
	public class ResearchCommand : Command
	{
		public int researchId;

		public ResearchCommand()
		{
		}

		public ResearchCommand(int index, int researchId, int currentTime)
		{
			this.playerId = index;
			this.researchId = researchId;
			this.time = currentTime;
		}
	}
}
