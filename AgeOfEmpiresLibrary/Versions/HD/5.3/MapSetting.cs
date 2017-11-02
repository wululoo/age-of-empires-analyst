using System;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfEmpiresLibrary
{

	public static class MapSetting
	{
		/* Map Size Constants */

		/// <summary>
		/// Map Size Constant for Tiny Map.
		/// Tiny Map is set for 2 Players
		/// Size = 120 x 120
		/// </summary>
		const int SIZE_TINY = 0;

		/// <summary>
		/// Map Size Constant for Small Map.
		/// Small Map is set for 3 Players
		/// Size = 144 x 144
		/// </summary>
		const int SIZE_SMALL = 1;

		/// <summary>
		/// Map Size Constant for Medium Map.
		/// Medium Map is set for 4 Players
		/// Size = 168 x 168
		/// </summary>
		const int SIZE_MEDIUM = 2;

		/// <summary>
		/// Map Size Constant for Normal Map.
		/// Normal Map is suitable for 6 Players
		/// Size = 200 x 200
		/// </summary>
		const int SIZE_NORMAL = 3;

		/// <summary>
		/// Map Size Constant for Large Map.
		/// Large Map is suitable for 8 Players
		/// Size = 220 x 220
		/// </summary>
		const int SIZE_LARGE = 4;

		/// <summary>
		/// Map Size Constant for Giant Map.
		/// Size = 240 x 240
		/// </summary>
		const int SIZE_GIANT = 5;

		/// <summary>
		/// Map Size Constant for LudiKRIS Map.
		/// Size = 480 x 480
		/// </summary>
		const int SIZE_LUDIKRIS = 6;
		public static Dictionary<int, string> SIZE_NAME = new Dictionary<int, string>()
		{
			{0, "Tiny"},
			{1, "Small"},
			{2, "Medium"},
            {3, "Normal"},
            {4, "Large"},
            {5, "Giant"},
            {6, "LudiKRIS"},
		};

		public static Dictionary<int, int> SIZE_WIDTH = new Dictionary<int, int>()
		{
			{0, 120},
			{1, 144},
			{2, 168},
			{3, 200},
			{4, 220},
			{5, 240},
			{6, 480},
		};

		/* Map Visibility Constants */

		/// <summary>
		/// Standard Map Visibility.
		/// </summary>
		const int VISIBILITY_STANDARD = 0;

		/// <summary>
		/// Map is revealed before game.
		/// </summary>
		const int VISIBILITY_REVEALED = 1;

		/// <summary>
		/// Map is visible before game.
		/// </summary>
		const int VISIBILITY_VISIBLE = 2;
        public static Dictionary<int, string> VISIBILITY_NAME = new Dictionary<int, string>()
        {
            {0, "Standard"},
            {1, "Revealed"},
            {2, "Visible"},
        };

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
        //const int MEGARANDOM = 59;
        const int CUSTOM_MAP = 59;
		const int HAMBURGER = 60;
		const int CTR_RANDOM = 61;
		const int CTR_MONSOON = 62;
		const int CTR_PYRAMIDDESCENT = 63;
		const int CTR_SPIRAL = 64;
		const int CANYONS = 96;

        static readonly Dictionary<int, string> MAP_NAME = new Dictionary<int, string>() {
			{ 9, "Arabia"} ,
			{ 10, "Archipelao"} ,
			{ 11, "Baltic"} ,
			{ 12, "Black Forest"} ,
			{ 13, "Coastal"} ,
			{ 14, "Continental"} ,
			{ 15, "Crater Lake"} ,
			{ 16, "Fortress"} ,
			{ 17, "Gold Rush"} ,
			{ 18, "Highland"} ,
			{ 19, "Islands"} ,
			{ 20, "Mediterranean"} ,
			{ 21, "Migration"} ,
			{ 22, "Rivers"} ,
			{ 23, "Team Islands"} ,
			{ 24, "Random"} ,
			{ 25, "Scandinavia"} ,
			{ 26, "Mongolia"} ,
			{ 27, "Yucatan"} ,
			{ 28, "Salt Marsh"} ,
			{ 29, "Arena"} ,
			{ 30, "King of the Hill"} ,
			{ 31, "Oasis"} ,
			{ 32, "Ghost Lake"} ,
			{ 33, "Nomad"} ,
			{ 34, "Iberia"} ,
			{ 35, "Britain"} ,
			{ 36, "Middle East"} ,
			{ 37, "Texas"} ,
			{ 38, "Italy"} ,
			{ 39, "Central America"} ,
			{ 40, "France"} ,
			{ 41, "Norselands"} ,
			{ 42, "Sea of Japan"} ,
			{ 43, "Byzantium"} ,
			{ 44, "Custom"} ,
			{ 54, "Serengeti"} ,
			{ 56, "Norse Lands"} ,
			{ 59, "Custom Script"} ,
			{ 66, "Blind Random"} ,
			{ 67, "Acropolis"} ,
			{ 68, "Budapest"} ,
			{ 69, "Cenotes"} ,
			{ 70, "City of Lakes"} ,
			{ 71, "Golden Pit"} ,
			{ 72, "Hideout"} ,
			{ 73, "Hill Fort"} ,
			{ 74, "Lomardia"} ,
			{ 75, "Steppe"} ,
			{ 76, "Valley"} ,
			{ 77, "Mega Random"} ,
			{ 78, "Hamburger"} ,
			{ 79, "CtR Random"} ,
			{ 80, "CtR Monsoon"} ,
			{ 81, "CtR Pyramid Descent"} ,
			{ 82, "CtR Spiral"} ,
			{ 83, "Kilimanjaro"} ,
			{ 84, "Mountain Pass"} ,
			{ 86, "Serengeti"} ,
			{ 87, "Socotra"} ,
			{ 88, "Amazon"} ,
			{ 89, "China"} ,
			{ 90, "Horn of Africa"} ,
			{ 91, "India"} ,
			{ 92, "Madagascar"} ,
			{ 93, "West Africa"} ,
			{ 94, "Bohemia"} ,
			{ 96, "Canyons"} ,
			{ 97, "Enemy Archipelago"} ,
			{ 98, "Enemy Islands"} ,
			{ 99, "Far Out"} ,
			{ 100, "Front Line"} ,
			{ 101, "Inner Circle"} ,
			{ 102, "Motherland"} ,
			{ 103, "Open Plains"} ,
			{ 104, "Ring of Water"} ,
			{ 105, "Snakepit"} ,
			{ 106, "The Eye"} ,
			{ 107, "Australia"} ,
			{ 108, "Indochina"} ,
			{ 109, "Indonesia"} ,
			{ 110, "Strait of Malacca"} ,
			{ 111, "Philippines"} ,
			{ 112, "Bog Islands"} ,
			{ 113, "Mangrove Jungle"} ,
			{ 114, "Pacific Islands"} ,
			{ 115, "Sandbank"} ,
			{ 116, "Water Nomad"} ,
			{ 118, "Holy Line"} ,
			{ 119, "Border Stones"} ,
			{ 120, "Yin Yang"} ,
			{ 121, "Jungle Lanes"} ,
		};

		public static bool isRealWorldMap(int id)
		{
			return new []
			{
				IBERIA, BRITAIN, MIDEAST, TEXAS, ITALY, CENTRALAMERICA, FRANCE, NORSELANDS,
				SEAOFJAPAN, BYZANTINUM,
			}.Contains(id);
		}

		public static bool isCustomMap(int id)
		{
			return id == CUSTOM_MAP;
		}

		public static bool isStandardMap(int id)
		{
			return new [] 
            {
				ARABIA, ARCHIPELAGO, BALTIC, BLACKFOREST,
                COASTAL, CONTINENTAL, CRATERLAKE,
                FORTRESS, GOLDRUSH, HIGHLAND, ISLANDS,
                MEDITERRANEAN, MIGRATION, RIVERS,
                TEAMISLANDS, SCANDINAVIA, MONGOLIA,
                YUCATAN, SALTMARSH, ARENA, KINGOFTHEHILL,
                OASIS, GHOSTLAKE, NOMAD, RANDOM,
            }.Contains(id);
		}

        public static bool isValidMap(int id)
        {
            return MAP_NAME.Keys.Contains(id);
        }

        public static bool isValidSize(int s)
        {
            return new [] 
            {
                SIZE_TINY, SIZE_SMALL, SIZE_NORMAL, SIZE_MEDIUM, SIZE_LARGE, SIZE_GIANT, SIZE_LUDIKRIS
            }.Contains(s);
        }

		public static string getSizeName(int id)
		{
			if (isValidSize(id))
				return SIZE_NAME[id];

			return "Invalid Map Size (id = " + id.ToString() + ")";
		}

		public static bool isValidVisibility(int v)
		{
			return new[]
			{
				VISIBILITY_STANDARD, VISIBILITY_REVEALED, VISIBILITY_VISIBLE
			}.Contains(v);
		}

		public static string getVisibilityName(int id)
		{
			if (isValidVisibility(id))
				return VISIBILITY_NAME[id];

			return "Invalid Map Size (id = " + id.ToString() + ")";
		}

        public static string getNameFromId(int id)
        {
            if (isValidMap(id))
                return MAP_NAME[id];

            return "Invalid Map ID (id = " + id.ToString() + ")";
        }

		//public static int getIdByName(string name)
		//{
		//	try
		//	{

		//		var typ = typeof(MapType);
		//		var f = typ.GetField(name);
		//		var val = f.GetValue(null);
		//		if (val is int)
		//			return Convert.ToInt32(val);
		//		else
		//			return -1;
		//	}
		//	catch
		//	{
		//		return -1;
		//	}
		//}
	}
}
