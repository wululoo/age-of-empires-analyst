using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // offensive stance
    //-01-00-00-00-07-00-00-00
    //-12
    //-01
    //-00 // offensive stance
    //-40-19-00-00
    //-2F-92-00-00

    public class StanceCommand : Command
    {
        public int stance;
        public int unitId;

        public StanceCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
