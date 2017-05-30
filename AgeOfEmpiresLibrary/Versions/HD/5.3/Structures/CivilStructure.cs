using System;
namespace AgeOfEmpiresLibrary
{
    public class CivilStructure : Structure
    {
        public CivilStructure(int id, string name, int age, Resources cost, int duration, int los, int hp, Tuple<int, int> armor) : base(id, name, age, cost, duration, los, hp, armor)
        {
        }
    }
}
