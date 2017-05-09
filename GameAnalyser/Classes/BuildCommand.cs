using System;
namespace GameAnalyser
{
	public class BuildCommand : Command
	{
		public int buildingId;
		public BuildCommand()
		{
		}

		public BuildCommand(int playerIndex, int buildingId, int currentTime)
		{
			this.playerId = playerIndex;
			this.buildingId = buildingId;
			this.time = currentTime;
		}
	}
}
