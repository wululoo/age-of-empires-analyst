using System;
namespace AgeOfEmpiresLibrary
{
    public class Unit
    {
        public int id;
        public string name;
        public int hp;
        public int reloadTime;
        public float attackDelay;
        public float movementRate;
        public int los;
        public Tuple<int, int> range;
        public int category;
        public Tuple<int, int> armor;

        public Unit(int id, string name, int reloadTime, float attackDelay, float movementRate, int los, int hp, Tuple<int, int> range, int category, Tuple<int, int> armor)
        {
            this.id = id;
            this.name = name;
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
