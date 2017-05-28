using System;
namespace AgeOfEmpiresLibrary
{
    public class MonkUnit : Unit
    {
		public Resources cost;
		public int age;
		public int duration;
        public int healRange;
        public int rejuvenation;

        public MonkUnit(int id, string name, int age, Resources cost, int duration, int healRange, int rejuvenation, int reloadTime, float attackDelay, float movementRate, int los, int hp, Tuple<int, int> range, int category, Tuple<int, int> armor) : base(id, name, reloadTime, attackDelay, movementRate, los, hp, range, category, armor)
        {
            this.age = age;
            this.cost = cost;
            this.duration = duration;
            this.healRange = healRange;
            this.rejuvenation = rejuvenation;
        }
    }
}
