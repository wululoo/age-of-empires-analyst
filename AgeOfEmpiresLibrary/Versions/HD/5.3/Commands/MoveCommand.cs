using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // move vill
    //-01-00-00-00-18-00-00-00
    //-03 // id
    //-01 // player id
    //-00-00-FF-FF-FF-FF
    //-01-00-00-00
    
    //-00-40-7A-42
    //-AB-2A-AC-41

    //-D1-14-00-00 // unit id
    //-C1-33-00-00 // time

    public class MoveCommand : Command
    {
        public float targetX;
        public float targetY;
        public int unitId;

        public MoveCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
