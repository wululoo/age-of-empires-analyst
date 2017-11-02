using System;
namespace AgeOfEmpiresLibrary
{
    public class Resources
    {
        public int wood = 0;
        public int food = 0;
        public int gold = 0;
        public int stone = 0;

        public Resources(int wood, int food, int gold, int stone)
        {
            this.wood = wood;
            this.food = food;
            this.gold = gold;
            this.stone = stone;
        }

        public static Resources GetResourceLevel(int level = 0)
        {
            switch(level)
            {
                case 0:
                    return new Resources(200, 200, 100, 200);

                case 1:
                    return new Resources(200, 150, 100, 200);

				case 2:
					return new Resources(500, 450, 300, 400);

				case 3:
                    return new Resources(1000, 950, 700, 800);

                // Death Match
                case 4:
                    return new Resources(20000, 19950, 10000, 5000);

                // Regicide
                case 5:
                    return new Resources(500, 450, 0, 150);

                default:
                    return new Resources(0, 0, 0, 0);
            }
        }

        public bool isValid()
        {
            return wood > 0 && food > 0 && gold > 0 && stone > 0 ? true : false;
        }

        public static Resources operator +(Resources a, Resources b)
        {
            a.wood += b.wood;
            a.food += b.food;
            a.gold += b.gold;
            a.stone += b.stone;

            return a;
        }

		public static Resources operator -(Resources a, Resources b)
		{
			a.wood -= b.wood;
			a.food -= b.food;
			a.gold -= b.gold;
			a.stone -= b.stone;

			return a;
		}
    }
}
