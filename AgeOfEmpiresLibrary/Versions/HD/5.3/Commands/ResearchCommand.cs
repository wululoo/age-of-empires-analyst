using System;
namespace AgeOfEmpiresLibrary
{
    public class ResearchCommand : Command
    {
        public int researchId;

        public ResearchCommand(int id, int playerId, int time, int researchId) : base(id, playerId, time)
        {
            this.researchId = researchId;

            this.id = 0x65;
        }
    }
}
