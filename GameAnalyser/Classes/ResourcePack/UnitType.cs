using System;
namespace GameAnalyser
{
	public static class UnitType
	{
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
