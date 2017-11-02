using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    //-01-00-00-00-1C-00-00-00
    //-75
    //-01
    //-00-00-FF-FF-FF-FF
    //-04-00-00-00-00-00-00-00-00-00-00-00-FF-FF-FF-FF
    //-CB-14-00-00
    //-28-BF-00-00

    public class CancelTrainCommand : Command
    {
        public int buildingId;

        public CancelTrainCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
