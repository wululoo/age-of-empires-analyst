using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // cancel research
    //-01-00-00-00-06-00-00-00
    //-01
    //-01
    //-CB-14-00-00
    //-52-E5-00-00

    public class CancelResearch : Command
    {
        public int buildingId;

        public CancelResearch(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
