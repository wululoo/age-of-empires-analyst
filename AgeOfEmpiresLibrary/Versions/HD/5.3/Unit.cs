using System;
namespace AgeOfEmpiresLibrary
{
    public class Unit
    {
        public int id;
        public string name;
        public Resources cost;
        public int age;
        public int duration;
        public int hp;
        public int reloadTime;
        public float attackDelay;
        public float movementRate;
        public int los;
        public Tuple<int, int> range;
        public int category;
        public Tuple<int, int> armor;

        public Unit(int id, string name, int age, Resources cost, int duration, int reloadTime, float attackDelay, float movementRate, int los, int hp, Tuple<int, int> range, int category, Tuple<int, int> armor)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.cost = cost;
            this.duration = duration;
            this.hp = hp;
            this.reloadTime = reloadTime;
            this.attackDelay = attackDelay;
            this.movementRate = movementRate;
            this.los = los;
            this.range = range;
            this.category = category;
            this.armor = armor;
        }
    }
}
