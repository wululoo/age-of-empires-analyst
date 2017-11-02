using System;
using System.Linq;

namespace AgeOfEmpiresLibrary
{
	public static class GameVersion
	{
		/**
         * Version ID for unknown game versions.
         *
         * @var int
         */
		public const int VERSION_UNKNOWN = 0;

		/**
         * Version ID for the Age of Kings base game.
         *
         * @var int
         */
		public const int VERSION_AOK = 1;

		/**
         * Version ID for the Age of Kings Trial version.
         *
         * @var int
         */
		public const int VERSION_AOKTRIAL = 2;

		/**
         * Version ID for the Age of Kings base game, patch version 2.0.
         *
         * @var int
         */
		public const int VERSION_AOK20 = 3;

		/**
         * Version ID for the Age Of Kings base game, patch version 2.0a.
         *
         * @var int
         */
		public const int VERSION_AOK20A = 4;

		/**
         * Version ID for the Age of Conquerors expansion.
         *
         * @var int
         */
		public const int VERSION_AOC = 5;

		/**
         * Version ID for the Age of Conquerors expansion (Trial version).
         *
         * @var int
         */
		public const int VERSION_AOCTRIAL = 6;

		/**
         * Version ID for the Age of Conquerors expansion.
         *
         * @var int
         */
		public const int VERSION_AOC10 = 7;

		/**
         * Version ID for the Age Of Conquerors expansion, patch version 1.0c.
         *
         * @var int
         */
		public const int VERSION_AOC10C = 8;

		/**
         * Version ID for UserPatch + Forgotten Empires v2.1.
         *
         * @var int
         */
		public const int VERSION_AOFE21 = 10;

		/**
         * Version ID for UserPatch v1.1.
         *
         * @var int
         */
		public const int VERSION_USERPATCH11 = 9;

		/**
         * Version ID for UserPatch v1.2.
         *
         * @var int
         */
		public const int VERSION_USERPATCH12 = 12;

		/**
         * Version ID for UserPatch v1.3.
         *
         * @var int
         */
		public const int VERSION_USERPATCH13 = 13;

		/**
         * Version ID for UserPatch v1.4.
         *
         * @var int
         */
		public const int VERSION_USERPATCH14 = 11;

		/**
         * Version ID for HD Edition.
         *
         * @var int
         */
		public const int VERSION_HD = 14;

		/**
         * Version ID for HD Edition patch 4.3.
         *
         * @var int
         */
		public const int VERSION_HD43 = 15;

		/**
         * Version ID for HD Edition patch 4.6.
         *
         * @var int
         */
		public const int VERSION_HD46 = 16;

		/**
         * Version ID for HD Edition patch 4.7.
         *
         * @var int
         */
		public const int VERSION_HD47 = 17;

		/**
         * Version ID for HD Edition patch 4.8.
         *
         * @var int
         */
		public const int VERSION_HD48 = 18;

        /**
         * Version ID for HD Edition patch 5.0.
         *
         * @var int
         */
        public const int VERSION_HD50 = 19;

		/**
		* Trial game version IDs.
		*
		* @var intnew int[] {}
		*/
		public static int[] trialVersions = new int[] {
			GameVersion.VERSION_AOKTRIAL,
			GameVersion.VERSION_AOCTRIAL,
		};

		/**
         * UserPatch game version IDs.
         *
         * @var intnew int[] {}
         */
		public static int[] userpatchVersions = new int[] {
			GameVersion.VERSION_USERPATCH11,
			GameVersion.VERSION_USERPATCH12,
			GameVersion.VERSION_USERPATCH13,
			GameVersion.VERSION_USERPATCH14,
			GameVersion.VERSION_AOFE21,
		};

		/**
         * Age of Kings game version IDs.
         *
         * @var intnew int[] {}
         */
		public static int[] aokVersions = new int[] {
			GameVersion.VERSION_AOK,
			GameVersion.VERSION_AOKTRIAL,
			GameVersion.VERSION_AOK20,
			GameVersion.VERSION_AOK20A,
		};

		/**
         * Age of Conquerors expansion game version IDs.
         *
         * @var intnew int[] {}
         */
		public static int[] aocVersions = new int[] {
			GameVersion.VERSION_AOC,
			GameVersion.VERSION_AOCTRIAL,
			GameVersion.VERSION_AOC10,
			GameVersion.VERSION_AOC10C,
		};

		/**
         * HD Edition game version IDs.
         *
         * @var intnew int[] {}
         */
		public static int[] hdVersions = new int[] {
			GameVersion.VERSION_HD,
			GameVersion.VERSION_HD43,
			GameVersion.VERSION_HD46,
            GameVersion.VERSION_HD47,
			GameVersion.VERSION_HD48,
            GameVersion.VERSION_HD50,
		};

		public static int getVersionConstant(string versionString, double subVersion)
		{
			switch (versionString)
			{
				case "TRL 9.3":
					//if (isAoC())
					return GameVersion.VERSION_AOCTRIAL;
				//else
				//return GameVersion.VERSION_AOKTRIAL;

				case "VER 9.3":
					return GameVersion.VERSION_AOK;

				case "VER 9.4":
					if (subVersion >= 12.49)
					{
						return GameVersion.VERSION_HD48;
					}
					else if (subVersion >= 12.36)
					{
						// Patch versions 4.6 and 4.7.
						return GameVersion.VERSION_HD46;
					}
					else if (subVersion >= 12.34)
					{
						// Probably versions 4.3 through 4.5?
						return GameVersion.VERSION_HD43;
					}
					else if (subVersion > 11.76)
					{
						return GameVersion.VERSION_HD;
					}
					else
						return GameVersion.VERSION_AOC;

				case "VER 9.5":
					return GameVersion.VERSION_AOFE21;

				case "VER 9.8":
					return GameVersion.VERSION_USERPATCH12;

				case "VER 9.9":
					return GameVersion.VERSION_USERPATCH13;

				// UserPatch 1.4 RC 1
				case "VER 9.A":
				// UserPatch 1.4 RC 2
				case "VER 9.B":
				case "VER 9.C":
				case "VER 9.D":
					return GameVersion.VERSION_USERPATCH14;

			}

			return -1;
		}

		public static bool isTrial(int version)
		{
			return trialVersions.Contains(version);
		}

		public static bool isAoK(int version)
		{
			return aokVersions.Contains(version);
		}

		public static bool isUserPatch(int version)
		{
			return userpatchVersions.Contains(version);
		}

		public static bool isHDEdition(int version)
		{
			return hdVersions.Contains(version);
		}

		public static bool isHDPatch4(int version, double subVersion)
		{
			return isHDEdition(version) && subVersion >= 12.00;
		}

		public static bool isAoC(int version)
		{
			return !isAoK(version);
		}

        public static bool isMgl(string fileFormat)
        {
            return fileFormat == ".mgl";
        }

        public static bool isMgx(string fileFormat)
        {
            return fileFormat == ".mgx";
        }

        public static bool isMgz(string fileFormat)
        {
            return fileFormat == ".mgz";
        }

        public static bool isMsx(string fileFormat)
        {
            return fileFormat == ".msx";
        }

        public static bool isAoe2Record(string fileFormat)
        {
            return fileFormat == ".aoe2record";
        }
	}
}
