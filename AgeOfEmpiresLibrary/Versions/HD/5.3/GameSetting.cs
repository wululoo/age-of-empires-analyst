using System;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfEmpiresLibrary
{
	public static class GameSetting
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
        public static readonly Dictionary<int, string> TYPE_NAME = new Dictionary<int, string>()
        {
            {0, "Random Map"},
            {1, "Regicide"},
            {2, "Death Match"},
            {3, "Scenario"},
            {4, "Campaign"},
            {6, "King of the Hill"},
            {7, "Wonder Race"},
            {8, "Defense of the Wonder"},
            {9, "Turbo Random"},
            {10, "Capture the Relic"},
            {11, "Sudden Death"}
        };

		public const int MODE_SINGLEPLAYER = 0;
		public const int MODE_MULTIPLAYER = 1;
		public static readonly Dictionary<int, string> MODE_NAME = new Dictionary<int, string>()
		{
			{0, "Single Player"},
			{1, "Multiplayer"},
		};

		public const int SPEED_SLOW = 100;
		public const int SPEED_NORMAL = 150;
		public const int SPEED_FAST = 200;
		public static readonly Dictionary<int, string> SPEED_NAME = new Dictionary<int, string>()
		{
			{100, "Slow"},
			{150, "Normal"},
			{200, "Fast"},
		};

		public const int LEVEL_HARDEST = 0;
		public const int LEVEL_HARD = 1;
		public const int LEVEL_MODERATE = 2;
		public const int LEVEL_STANDARD = 3;
		public const int LEVEL_EASIEST = 4;
		public static readonly Dictionary<int, string> LEVEL_NAME = new Dictionary<int, string>()
		{
			{0, "Hardest"},
			{1, "Hard"},
			{2, "Moderate"},
			{3, "Standard"},
			{4, "Easiest"}
		};

		public const int AGE_STANDARD = 0;
		public const int AGE_DARK = 2;
		public const int AGE_FEUDAL = 3;
		public const int AGE_CASTLE = 4;
		public const int AGE_IMPERIAL = 5;
		public const int AGE_POSTIMPERIAL = 6;
		public static readonly Dictionary<int, string> AGE_NAME = new Dictionary<int, string>()
		{
			{0, "Standard"},
			{2, "Dark Age"},
			{3, "Feudal Age"},
			{4, "Castle Age"},
			{5, "Imperial Age"},
			{6, "Post Imperial Age"},
		};

		public const int RESOURCES_STANDARD = 0;
		public const int RESOURCES_LOW = 1;
		public const int RESOURCES_MEDIUM = 2;
		public const int RESOURCES_HIGH = 3;
		public static readonly Dictionary<int, string> RESOURCES_NAME = new Dictionary<int, string>()
		{
			{0, "Standard"},
			{1, "Low"},
			{2, "Medium"},
			{3, "High"},
		};

		public const int VICTORY_STANDARD = 9;
		public const int VICTORY_CONQUEST = 1;
		public const int VICTORY_TIMELIMIT = 7;
		public const int VICTORY_SCORELIMIT = 8;
		public const int VICTORY_LASTMANSTANDING = 11;
		public const int VICTORY_CUSTOM = 5;
        public static readonly Dictionary<int, string> VICTORY_NAME = new Dictionary<int, string>()
		{
			{1, "Conquest"},
            {5, "Custom"},
            {7, "Time Limit"},
            {8, "Score Limit"},
            {9, "Standard"},
            {11, "Last Man Standing"},
		};

        public static bool isValidMode(int m)
        {
            return new[] { MODE_SINGLEPLAYER, MODE_MULTIPLAYER }.Contains(m);
        }

		public static string getGameModeName(int mode)
		{
			if (isValidMode(mode))
			{
				return MODE_NAME[mode];
			}

			else
				return "Invalid Game Mode (id = " + mode.ToString() + ")";
		}

        public static bool isValidType(int t)
        {
			return new[] {
				TYPE_RANDOMMAP,
				TYPE_REGICIDE,
				TYPE_DEATHMATCH,
				TYPE_SCENARIO,
				TYPE_CAMPAIGN,
				TYPE_KINGOFTHEHILL,
                TYPE_WONDERRACE,
                TYPE_DEFENSEOFTHEWONDER,
                TYPE_TURBORANDOM,
                TYPE_CAPTURETHERELIC,
                TYPE_SUDDENDEATH
			}.Contains(t);
        }

		public static string getGameTypeName(int type)
		{
			if (isValidType(type))
			{
				return TYPE_NAME[type];
			}

			else
                return "Invalid Game Type (id = " + type.ToString() + ")";
		}

		public static bool isValidVictory(int v)
		{
			return new[] { 
                VICTORY_STANDARD, 
                VICTORY_CONQUEST, 
                VICTORY_TIMELIMIT, 
                VICTORY_SCORELIMIT, 
                VICTORY_LASTMANSTANDING,
                VICTORY_CUSTOM
            }.Contains(v);
		}

        public static string getVictoryName(int v)
        {
            if (isValidVictory(v))
            {
                return VICTORY_NAME[v];
            }

            else
                return "Invalid Victory Condition (id = " + v.ToString() + ")";
        }

        public static bool isValidSpeed(int s)
        {
			return new[] {
				SPEED_SLOW,
				SPEED_NORMAL,
				SPEED_FAST
			}.Contains(s);
        }

		public static string getSpeedName(int s)
		{
			if (isValidSpeed(s))
			{
				return SPEED_NAME[s];
			}

			else
				return "Invalid Game Speed (id = " + s.ToString() + ")";
		}

		public static bool isValidDifficulty(int d)
        {
			return new[] {
				LEVEL_HARDEST,
				LEVEL_HARD,
				LEVEL_MODERATE,
                LEVEL_STANDARD,
                LEVEL_EASIEST
			}.Contains(d);
        }

		public static string getDifficultyName(int d)
		{
			if (isValidDifficulty(d))
			{
				return LEVEL_NAME[d];
			}

			else
				return "Invalid Difficulty Level (id = " + d.ToString() + ")";
		}

		public static bool isValidResourceLevel(int r)
		{
			return new[] {
				RESOURCES_STANDARD,
				RESOURCES_LOW,
				RESOURCES_MEDIUM,
				RESOURCES_HIGH
			}.Contains(r);
		}

		public static string getResourceLevelName(int d)
		{
			if (isValidResourceLevel(d))
			{
				return RESOURCES_NAME[d];
			}

			else
				return "Invalid Resources Level (id = " + d.ToString() + ")";
		}

        public static bool isValidAge(int a)
        {
            return new[] {
                AGE_STANDARD,
                AGE_DARK,
                AGE_FEUDAL,
                AGE_CASTLE,
                AGE_IMPERIAL
            }.Contains(a);
        }

		public static string getAgeName(int d)
		{
			if (isValidAge(d))
			{
				return AGE_NAME[d];
			}

			else
				return "Invalid Age (id = " + d.ToString() + ")";
		}
	}
}
