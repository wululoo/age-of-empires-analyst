using System;
namespace AgeOfEmpiresLibrary
{
    public class GaiaUnit : Unit
    {
        public Resources resource = null;
        public float decay;

        public GaiaUnit(int id, string name, Resources resources, float decay, int reloadTime, float attackDelay, float movementRate, int los, int hp, Tuple<int, int> range, int category, Tuple<int, int> armor) : base(id, name, reloadTime, attackDelay, movementRate, los, hp, range, category, armor)
        {
            this.resource = resources;
            this.decay = decay;
        }
    }
}
