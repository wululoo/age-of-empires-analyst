using System;
namespace AgeOfEmpiresLibrary
{
    public class MilitaryUnit : Unit
    {

        public Resources cost;
        public int age;
        public int duration;

        public MilitaryUnit(int id, string name, int age, Resources cost, int duration, int reloadTime, float attackDelay, float movementRate, int los, int hp, Tuple<int, int> range, int category, Tuple<int, int> armor) : base(id, name, reloadTime, attackDelay, movementRate, los, hp, range, category, armor)
        {
            this.cost = cost;
            this.age = age;
            this.duration = duration;
        }
    }
}
