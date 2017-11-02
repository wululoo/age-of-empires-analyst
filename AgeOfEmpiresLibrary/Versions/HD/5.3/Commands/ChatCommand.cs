using System;
namespace AgeOfEmpiresLibrary
{
    public class ChatCommand : Command
    {
        public int target;
        public string message;

        public ChatCommand(int id, int playerId, int time, int target, string message) : base(id, playerId, time)
        {
            this.target = target;
            this.message = message;

            this.type = -1;
        }

        public int getRecieverId()
        {
            return this.target;
        }

        public string getMessage()
        {
            return this.message;
        }
    }
}
