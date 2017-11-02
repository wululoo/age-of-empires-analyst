using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    //-15 // patrol
    //-01 // player id
    //-01-00 // patrol trigger??
    //-AB-EA-A0-41
    //-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
    //-55-A5-C6-42
    //-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
    //-40-19-00-00 // unit id
    //-49-48-00-00 // time

    public class PatrolCommand : Command
    {
        int unitId;
        float startX;
        float startY;
        float endX;
        float endY;

        public PatrolCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
