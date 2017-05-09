using System;
namespace GameAnalyser
{
	public class InitialState
	{
		const int DARKAGE = 0;
		const int FEUDALAGE = 1;
		const int CASTLEAGE = 2;
		const int IMPERIALAGE = 3;
		const int POSTIMPERIALAGE = 4;

		/**
         * Initial food.
         *
         * @var int
         */
		public int food = 0;

		/**
         * Initial wood.
         *
         * @var int
         */
		public int wood = 0;

		/**
         * Initial stone.
         *
         * @var int
         */
		public int stone = 0;

		/**
         * Initial gold.
         *
         * @var int
         */
		public int gold = 0;

		/**
         * Starting age.
         *
         * @var int
         */
		public int startingAge = DARKAGE;

		/**
         * Initial house capacity.
         *
         * @var int
         */
		public int houseCapacity = 0;

		/**
         * Initial population.
         *
         * @var int
         */
		public int population = 0;

		/**
         * Initial civilian population.
         *
         * @var int
         */
		public int civilianPop = 0;

		/**
         * Initial military population.
         *
         * @var int
         */
		public int militaryPop = 0;

		/**
         * Initial extra population.
         *
         * @var int
         */
		public int headRoom = 0;

		/**
         * Initial position, `[x, y]`.
         *
         * @var float[]
         */
		public double[] position = { 0, 0 };

		public InitialState()
		{
			
		}

		public void setFood(int food)
		{
			this.food = food;
		}

		public void setWood(int wood)
		{
			this.wood = wood;
		}

		public void setGold(int gold)
		{
			this.gold = gold;
		}

		public void setStone(int stone)
		{
			this.stone = stone;
		}

		public void setHeadRoom(int headRoom)
		{
			this.headRoom = headRoom;
		}

		public void setAge(int startingAge)
		{
			this.startingAge = startingAge;
		}

		public void setPopulation(int population)
		{
			this.population = population;
		}

		public void setCivilianPopulation(int civilianPopulation)
		{
			this.civilianPop = civilianPopulation;
		}

		public void setMilitaryPopulation(int militaryPopulation)
		{
			this.militaryPop = militaryPopulation;
		}

		public void setCameraLocation(double x, double y)
		{
			this.position[0] = x;
			this.position[1] = y;
		}
	}
}
