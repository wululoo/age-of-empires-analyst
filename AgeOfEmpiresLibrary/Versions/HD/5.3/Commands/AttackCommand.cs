using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // Attack Jaguar
    //-01-00-00-00-14-00-00-00-00-01-00-00-73-2E-00-00-FF-00-00-00-00-00-E4-41-00-80-4D-43-00-AE-02-00
    public class AttackCommand : Command
    {
        public int targetId;
        public int unitId;
        public AttackCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
