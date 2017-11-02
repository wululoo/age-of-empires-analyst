using System;
namespace AgeOfEmpiresLibrary
{
    public class TrainCommand : Command
    {
        public int buildingId;
        public int unitId;
        public int amount;

        public TrainCommand(int id, int playerId, int time, int buildingId, int unitId, int amount) : base(id, playerId, time)
        {
            this.buildingId = buildingId;
            this.unitId = unitId;
            this.amount = amount;

            type = 0x64;
            operation = 1;
        }

        public int getBuildingId()
        {
            return buildingId;
        }

        public int getUnitId()
        {
            return unitId;
        }

        public int getAmount()
        {
            return amount;
        }
    }
}
