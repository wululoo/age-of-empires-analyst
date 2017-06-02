using System;
namespace AgeOfEmpiresLibrary
{
    public class TrainCommand : Command
    {
        public int buildingId;
        public int unitId;
        public int amount;

        public TrainCommand()
        {
        }
    }
}
