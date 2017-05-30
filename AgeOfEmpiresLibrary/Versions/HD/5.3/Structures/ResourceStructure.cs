using System;
namespace AgeOfEmpiresLibrary
{
    public class ResourceStructure : Structure
    {
        public Resources resources;

        public ResourceStructure(int id, string name, int age, Resources cost, int duration, int los, int hp, Tuple<int, int> armor) : base(id, name, age, cost, duration, los, hp, armor)
        {
        }
    }
}
