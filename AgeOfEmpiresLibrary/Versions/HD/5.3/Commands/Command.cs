using System;
namespace AgeOfEmpiresLibrary
{
    public class Command
    {

        public int id;
        public int operation;
        public int type;
        public int playerId;
        public int time;

        public Command(int id, int playerId, int time)
        {
            this.id = id;
            this.playerId = playerId;
            this.time = time;
        }

        public int getPlayerId()
        {
            return this.playerId;
        }

        public int getTime()
        {
            return this.time;
        }

        public int getType()
        {
            return this.type;
        }

        public int getOperation()
        {
            return this.operation;
        }
    }
}
