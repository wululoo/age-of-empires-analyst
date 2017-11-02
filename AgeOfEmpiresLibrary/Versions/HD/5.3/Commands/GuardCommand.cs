using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // guard scout
    //-01-00-00-00-0C-00-00-00
    //-13 // guard
    //-01 // player id
    //-00-00 // ??
    //-3D-19-00-00 // target id
    //-40-19-00-00 // unit id
    //-73-66-00-00 // time

    public class GuardCommand : Command
    {
        public int unitId;
        public int targetId;

        public GuardCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
