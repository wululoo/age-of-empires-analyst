using System;
namespace AgeOfEmpiresLibrary
{
	public static class GameType
	{
		public const int TYPE_RANDOMMAP = 0;
		public const int TYPE_REGICIDE = 1;
		public const int TYPE_DEATHMATCH = 2;
		public const int TYPE_SCENARIO = 3;
		public const int TYPE_CAMPAIGN = 4;
		public const int TYPE_KINGOFTHEHILL = 6;
		public const int TYPE_WONDERRACE = 7;
		public const int TYPE_DEFENSEOFTHEWONDER = 8;
		public const int TYPE_TURBORANDOM = 9;
		public const int TYPE_CAPTURETHERELIC = 10;
		public const int TYPE_SUDDENDEATH = 11;

		public const int MODE_SINGLEPLAYER = 0;
		public const int MODE_MULTIPLAYER = 1;

		public const int SPEED_SLOW = 100;
		public const int SPEED_NORMAL = 150;
		public const int SPEED_FAST = 200;

		public const int LEVEL_HARDEST = 0;
		public const int LEVEL_HARD = 1;
		public const int LEVEL_MODERATE = 2;
		public const int LEVEL_STANDARD = 3;
		public const int LEVEL_EASIEST = 4;

		public const int AGE_STANDARD = 0;
		public const int AGE_DARK = 2;
		public const int AGE_FEUDAL = 3;
		public const int AGE_CASTLE = 4;
		public const int AGE_IMPERIAL = 5;
		public const int AGE_POSTIMPERIAL = 6;

		public const int RESOURCES_STANDARD = 0;
		public const int RESOURCES_LOW = 1;
		public const int RESOURCES_MEDIUM = 2;
		public const int RESOURCES_HIGH = 3;

		public const int VICTORY_STANDARD = 9;
		public const int VICTORY_CONQUEST = 1;
		public const int VICTORY_TIMELIMIT = 7;
		public const int VICTORY_SCORELIMIT = 8;
		public const int VICTORY_LASTMANSTANDING = 11;
		public const int VICTORY_CUSTOM = 5;

		public static string[] VICTORY_CONDITION = { "Standard", "Conquest", "Time Limit", "Score Limit", "Custom", };

	}
}
