using System;
namespace AgeOfEmpiresLibrary
{
	public static class UnitType
	{
        public static Unit UNIT_ARCHER = new Unit(4, "Archer", 3, new Resources(25, 0, 45, 0), 35000, 2000, 0.35f, 0.96f, 6, 30, new Tuple<int, int>(4, 4), 4, new Tuple<int, int>(0, 0));
        public static Unit UNIT_HAND_CANNONEER = new Unit(5, "Hand Cannoneer", 5, new Resources(0, 45, 50, 0), 34000, 3450, 0.35f, 0.96f, 9, 35, new Tuple<int, int>(7, 7), 17, new Tuple<int, int>(1, 0));
        public static Unit UNIT_ELITE_SKIRMISHER = new Unit(6, "Elite Skirmisher", 4, new Resources(35, 25, 0, 0), 22000, 3000, 0.35f, 0.96f, 7, 35, new Tuple<int, int>(1, 5), 4, new Tuple<int, int>(0, 4));
        public static Unit UNIT_SKIRMISHER = new Unit(7, "Skirmisher", 3, new Resources(35, 25, 50, 0), 22000, 3000, 0.35f, 0.96f, 6, 30, new Tuple<int, int>(1, 4), 2, new Tuple<int, int>(0, 3));
        public static Unit UNIT_LONGBOWMAN = new Unit(8, "Longbowman", 4, new Resources(35, 0, 40, 0), 18000, 2000, 0.35f, 0.96f, 8, 35, new Tuple<int, int>(6, 6), 6, new Tuple<int, int>(0, 0));

		// Unit IDs that we might draw on maps
		// GAIA (needed for colours when drawing)
		public const int GOLDMINE = 66;
		public const int STONEMINE = 102;
		public const int CLIFF1 = 264;
		public const int CLIFF2 = 265;
		public const int CLIFF3 = 266;
		public const int CLIFF4 = 267;
		public const int CLIFF5 = 268;
		public const int CLIFF6 = 269;
		public const int CLIFF7 = 270;
		public const int CLIFF8 = 271;
		public const int CLIFF9 = 272;
		public const int CLIFF10 = 273;
		public const int RELIC = 285;
		public const int TURKEY = 833;
		public const int SHEEP = 594;
		public const int DEER = 65;
		public const int BOAR = 48;
		public const int JAVELINA = 822;
		public const int FORAGEBUSH = 59;
		// Gates (needed for directions when drawing)
		public const int GATE = 487;
		public const int GATE2 = 490;
		public const int GATE3 = 665;
		public const int GATE4 = 673;
		public const int PALISADE_GATE = 792;
		public const int PALISADE_GATE2 = 796;
		public const int PALISADE_GATE3 = 800;
		public const int PALISADE_GATE4 = 804;

		/**
        * Unit type ID.
        *
        * @var int
        */
		public const int UT_EYECANDY = 10;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_FLAG = 20;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_DEAD_OR_FISH = 30;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_BIRD = 40;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_UNKNOWN = 50;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_PROJECTILE = 60;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_CREATABLE = 70;

		/**
         * Unit type ID.
         *
         * @var int
         */
		public const int UT_BUILDING = 80;
	}
}
