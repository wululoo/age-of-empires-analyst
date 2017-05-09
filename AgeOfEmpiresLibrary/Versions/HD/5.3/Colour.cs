using System;
using System.Collections.Generic;

namespace AgeOfEmpiresLibrary
{
	public static class Colour
	{
		public static Dictionary<int, string> GAIA_COLOURS = new Dictionary<int, string>
		{
			{ UnitType.GOLDMINE   , "#ffc700" },
			{ UnitType.STONEMINE  , "#919191" },
			{ UnitType.CLIFF1     , "#714b33" },
			{ UnitType.CLIFF2     , "#714b33" },
			{ UnitType.CLIFF3     , "#714b33" },
			{ UnitType.CLIFF4     , "#714b33" },
			{ UnitType.CLIFF5     , "#714b33" },
			{ UnitType.CLIFF6     , "#714b33" },
			{ UnitType.CLIFF7     , "#714b33" },
			{ UnitType.CLIFF8     , "#714b33" },
			{ UnitType.CLIFF9     , "#714b33" },
			{ UnitType.CLIFF10    , "#714b33" },
			{ UnitType.RELIC      , "#ffffff" },
			{ UnitType.TURKEY     , "#a5c46c" },
			{ UnitType.SHEEP      , "#a5c46c" },
			{ UnitType.DEER       , "#a5c46c" },
			{ UnitType.BOAR       , "#a5c46c" },
			{ UnitType.JAVELINA   , "#a5c46c" },
			{ UnitType.FORAGEBUSH , "#a5c46c" },
		};

		//private static string getColours(string category)
		//{
		//	var colours = resources.data.ageofempires.Colours.colours;
		//	if (colours != null)
		//	{
		//		return colours[category];
		//	}

		//	return null;
		//}

		//public static string getTerrainColour(int id, int variation = 1)
		//{
		//	return getColours("terrain")[id, variation];
		//}

		//public static string getPlayerColour(int id)
		//{
		//	return getColours("players")[0, id];
		//}

		public static string getUnitColour(int id)
		{
			return GAIA_COLOURS[id];
		}
	}
}
