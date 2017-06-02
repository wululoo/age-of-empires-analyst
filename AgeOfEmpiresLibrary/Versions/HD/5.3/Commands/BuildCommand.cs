using System;
namespace AgeOfEmpiresLibrary
{
    public class BuildCommand : Command
    {

        public int buildingId;
        public Tuple<int, int> location;

        public BuildCommand()
        {
        }
    }
}
