using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    // attack move
    //-01-00-00-00-58-00-00-00
    //-21
    //-01
    //-01-00
    //-55-D5-A6-41
    //-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
    //-00-60-C0-42
    //-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
    //-40-19-00-00
    //-F4-CB-00-00

    public class AttackMoveCommand : Command
    {
		public float targetX;
		public float targetY;
		public int unitId;

        public AttackMoveCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
