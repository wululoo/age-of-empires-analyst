using System;
namespace GameAnalyser
{
	public class TrainCommand : Command
	{
		public int buildingId;
		public int unitType;
		public int amount;

		public TrainCommand()
		{
		}

		public TrainCommand(int playerIndex, int unitType, int amount, int currentTime)
		{
			this.playerId = playerIndex;
			this.unitType = unitType;
			this.amount = amount;
			this.time = currentTime;
		}
	}
}
