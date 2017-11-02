using System;
namespace AgeOfEmpiresLibrary
{
    public class Structure : Createable
    {
        public Resources cost;
        public int age;
        public int duration;
		public int hp;
		public int los;
        public Tuple<int, int> armor;

        public Structure(int id, string name, int age, Resources cost, int duration, int los, int hp, Tuple<int, int> armor)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.cost = cost;
            this.duration = duration;
            this.los = los;
            this.armor = armor;
        }
    }
}
