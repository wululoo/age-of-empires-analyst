using System;
using System.Linq;

namespace GameAnalyser
{
	public static class Civilisation
	{
		public const int NONE = 0;
		public const int BRITONS = 1;
		public const int FRANKS = 2;
		public const int GOTHS = 3;
		public const int TEUTONS = 4;
		public const int JAPANESE = 5;
		public const int CHINESE = 6;
		public const int BYZANTINES = 7;
		public const int PERSIANS = 8;
		public const int SARACENS = 9;
		public const int TURKS = 10;
		public const int VIKINGS = 11;
		public const int MONGOLS = 12;
		public const int CELTS = 13;
		public const int SPANISH = 14;
		public const int AZTECS = 15;
		public const int MAYANS = 16;
		public const int HUNS = 17;
		public const int KOREANS = 18;
		public const int ITALIANS = 19;
		public const int INDIANS = 20;
		public const int INCAS = 21;
		public const int MAGYARS = 22;
		public const int SLAVS = 23;
		public const int PORTUGUESE = 24;
		public const int ETHIOPIANS = 25;
		public const int MALIANS = 26;
		public const int BERBERS = 27;
		public const int KHMERS = 28;
		public const int MALAY = 29;
		public const int BURMESE = 30;
		public const int VIETNAMESE = 31;

		public static string[] CIV_NAMES = {
			"", "Britons", "Franks", "Goths", "Teutons", "Japanese", "Chinese", "Byzantines",
			"Persians", "Saracens", "Turks", "Vikings", "Mongols", "Celts", "Spanish",
			"Aztecs", "Mayans", "Huns", "Koreans", "Italians", "Indians", "Magyars", "Slavs"
		};

		internal static string getCivName(int id)
		{
			try
			{
				if (CIV_NAMES.Length - 1 > id)
				{
					return CIV_NAMES[id];
				}

				return CIV_NAMES[NONE];
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		public static bool isAoKCiv(int id)
		{
			int[] AoKCivs = {
				BRITONS, FRANKS, GOTHS, TEUTONS, JAPANESE, CHINESE,
				BYZANTINES, PERSIANS, SARACENS, TURKS, VIKINGS,
				MONGOLS, CELTS
			};

			return AoKCivs.Contains(id);
		}

		public static bool isAoCCiv(int id)
		{
			int[] AoCCivs = {
				SPANISH, AZTECS, MAYANS, HUNS, KOREANS,
			};

			return AoCCivs.Contains(id);
		}

		public static bool isForgottenCiv(int id)
		{
			int[] ForgottenCivs = {
				ITALIANS, INDIANS, INCAS, MAGYARS, SLAVS,
			};

			return ForgottenCivs.Contains(id);
		}
	}
}
