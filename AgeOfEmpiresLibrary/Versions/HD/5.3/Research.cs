namespace AgeOfEmpiresLibrary
{
    public class Research
    {
        public int id;
        public int duration;
        private string name;
        private int age;
        private Resources cost;

        public Research(int id, int duration, string name)
        {
            this.id = id;
            this.duration = duration;
            this.name = name;
        }

		public Research(int id, int duration, string name, Resources cost)
		{
			this.id = id;
			this.duration = duration;
			this.name = name;
            this.cost = cost;
		}

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public int getWoodCost()
        {
            return cost.wood;
        }

        public int getFoodCost()
        {
            return cost.food;
        }

        public int getGoldCost()
        {
            return cost.gold;
        }

        public int getStoneCost()
        {
            return cost.stone;
        }
    }
}
