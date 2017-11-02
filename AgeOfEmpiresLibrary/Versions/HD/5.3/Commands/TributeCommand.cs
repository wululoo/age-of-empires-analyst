using System;
namespace AgeOfEmpiresLibrary
{
    public class TributeCommand : Command
    {
        public int payee;
        public Resources resource;

        public TributeCommand(int id, int playerId, int time, int payee, Resources resource) : base(id, playerId, time)
        {
            this.payee = payee;
            this.resource = resource;

            this.type = 0x6c;
            this.operation = 1;
        }

        public int getRecieverId()
        {
            return payee;
        }

        public Resources getResources()
        {
            return resource;
        }
    }
}
