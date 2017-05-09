using System;
namespace GameAnalyser
{
	public class TributeCommand : Command
	{
		public int payeeId;
		public int resourceId;
		public int amount;
		public int tax;

		public TributeCommand()
		{
		}

		public TributeCommand(int playerIndex, int payeeId, int resourceId, int amount, int tax, int currentTime)
		{
			this.playerId = playerIndex;
			this.payeeId = payeeId;
			this.resourceId = resourceId;
			this.amount = amount;
			this.tax = tax;
			this.time = currentTime;
		}
	}
}
