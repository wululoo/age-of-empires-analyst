using System;
namespace AgeOfEmpiresLibrary.Versions.HD.Commands
{
    //-6A-00-00-00 // delete command
    //-46-1A-00-00
    //-01-00-00-00
    //-4F-30-00-00

    public class DeleteCommand : Command
    {
		public int targetId;

        public DeleteCommand(int id, int playerId, int time) : base(id, playerId, time)
        {
        }
    }
}
