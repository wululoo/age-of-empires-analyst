using System;
namespace AgeOfEmpiresLibrary
{
    // Command 0x66
    // id 1 byte
    // id 2 byte
    // x 4 bytes
    // y 4 bytes
    // building id 4 bytes
    // FF FF FF FF
    // builder id 4 bytes
    // time

    public class BuildCommand : Command
    {

        public int buildingId;
        public Tuple<int, int> location;

        public BuildCommand(int id, int playerId, int time, int buildingId, Tuple<int, int> location) : base(id, playerId, time)
        {
            this.buildingId = buildingId;
            this.location = location;
            type = 0x66;

            operation = 1;
        }

        public int getBuildingId()
        {
            return buildingId;
        }

        public Tuple<int, int> getBuildingLocation()
        {
            return location;
        }
    }
}
