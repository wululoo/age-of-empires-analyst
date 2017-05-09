using System;
using System.Linq;

namespace GameAnalyser
{

	public static class MapType
	{
		/* Map Size Constants */

		/// <summary>
		/// Map Size Constant for Tiny Map.
		/// Tiny Map is set for 2 Players
		/// Size = 120 x 120
		/// </summary>
		const int TINY = 0;

		/// <summary>
		/// Map Size Constant for Small Map.
		/// Small Map is set for 3 Players
		/// Size = 144 x 144
		/// </summary>
		const int SMALL = 1;

		/// <summary>
		/// Map Size Constant for Medium Map.
		/// Medium Map is set for 4 Players
		/// Size = 168 x 168
		/// </summary>
		const int MEDIUM = 2;

		/// <summary>
		/// Map Size Constant for Normal Map.
		/// Normal Map is suitable for 6 Players
		/// Size = 200 x 200
		/// </summary>
		const int NORMAL = 3;

		/// <summary>
		/// Map Size Constant for Large Map.
		/// Large Map is suitable for 8 Players
		/// Size = 220 x 220
		/// </summary>
		const int LARGE = 4;

		/// <summary>
		/// Map Size Constant for Giant Map.
		/// Size = 240 x 240
		/// </summary>
		const int GIANT = 5;

		/// <summary>
		/// Map Size Constant for LudiKRIS Map.
		/// Size = 480 x 480
		/// </summary>
		const int LUDIKRIS = 6;

		/* Map Visibility Constants */

		/// <summary>
		/// Standard Map Visibility.
		/// </summary>
		const int STANDARD = 0;

		/// <summary>
		/// Map is revealed before game.
		/// </summary>
		const int REVEALED = 1;

		/// <summary>
		/// Map is visible before game.
		/// </summary>
		const int VISIBLE = 2;

		/* Map Type Constants */
		const int ARABIA = 9;
		const int ARCHIPELAGO = 10;
		const int BALTIC = 11;
		const int BLACKFOREST = 12;
		const int COASTAL = 13;
		const int CONTINENTAL = 14;
		const int CRATERLAKE = 15;
		const int FORTRESS = 16;
		const int GOLDRUSH = 17;
		const int HIGHLAND = 18;
		const int ISLANDS = 19;
		const int MEDITERRANEAN = 20;
		const int MIGRATION = 21;
		const int RIVERS = 22;
		const int TEAMISLANDS = 23;
		const int RANDOM = 24;
		const int SCANDINAVIA = 25;
		const int MONGOLIA = 26;
		const int YUCATAN = 27;
		const int SALTMARSH = 28;
		const int ARENA = 29;
		const int KINGOFTHEHILL = 30;
		const int OASIS = 31;
		const int GHOSTLAKE = 32;
		const int NOMAD = 33;
		const int IBERIA = 34;
		const int BRITAIN = 35;
		const int MIDEAST = 36;
		const int TEXAS = 37;
		const int ITALY = 38;
		const int CENTRALAMERICA = 39;
		const int FRANCE = 40;
		const int NORSELANDS = 41;
		const int SEAOFJAPAN = 42;
		const int BYZANTINUM = 43;
		const int CUSTOM = 44;
		const int BLINDRANDOM = 48;
		const int ACROPOLIS = 49;
		const int BUDAPEST = 50;
		const int CENOTES = 51;
		const int CITYOFLAKES = 52;
		const int GOLDENPIT = 53;
		const int HIDEOUT = 54;
		const int HILLFORT = 55;
		const int LOMBARDIA = 56;
		const int STEPPE = 57;
		const int VALLEY = 58;
		const int MEGARANDOM = 59;
		const int HAMBURGER = 60;
		const int CTR_RANDOM = 61;
		const int CTR_MONSOON = 62;
		const int CTR_PYRAMIDDESCENT = 63;
		const int CTR_SPIRAL = 64;
		const int CANYONS = 96;

		public static bool isRealWorldMap(int id)
		{
			int[] realWorldMaps =
			{
				IBERIA, BRITAIN, MIDEAST, TEXAS, ITALY, CENTRALAMERICA, FRANCE, NORSELANDS,
				SEAOFJAPAN, BYZANTINUM,
			};

			return realWorldMaps.Contains(id);
		}

		public static bool isCustomMap(int id)
		{
			return id == CUSTOM;
		}

		public static bool isStandardMap(int id)
		{
			int[] standardMaps =
			{
				ARABIA, ARCHIPELAGO, BALTIC, BLACKFOREST,
				COASTAL, CONTINENTAL, CRATERLAKE,
				FORTRESS, GOLDRUSH, HIGHLAND, ISLANDS,
				MEDITERRANEAN, MIGRATION, RIVERS,
				TEAMISLANDS, SCANDINAVIA, MONGOLIA,
				YUCATAN, SALTMARSH, ARENA, KINGOFTHEHILL,
				OASIS, GHOSTLAKE, NOMAD, RANDOM,
			};

			return standardMaps.Contains(id);
		}

		public static int getIdByName(string name)
		{
			try
			{

				var typ = typeof(MapType);
				var f = typ.GetField(name);
				var val = f.GetValue(null);
				if (val is int)
					return Convert.ToInt32(val);
				else
					return -1;
			}
			catch
			{
				return -1;
			}
		}
	}
}
