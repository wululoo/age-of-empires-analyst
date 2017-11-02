//using System;
//namespace AgeOfEmpiresLibrary
//{
//	public static class AoEResourcePack
//	{
//		public const string NAME = "AoE HD UP5.3";

//		public static string getCivName(int id)
//		{
//			return Civilisation.getCivName(id);
//		}

//		public static bool isAoKCiv(int id)
//		{
//			return Civilisation.isAoKCiv(id);
//		}

//		public static bool isAoCCiv(int id)
//		{
//			return Civilisation.isAoCCiv(id);
//		}

//		public static bool isForgottenCiv(int id)
//		{
//			return Civilisation.isForgottenCiv(id);
//		}

//		public static bool isRealWorldMap(int id)
//		{
//			return MapType.isRealWorldMap(id);
//		}

//		public static bool isCustomMap(int id)
//		{
//			return MapType.isCustomMap(id);
//		}

//		public static bool isStandardMap(int id)
//		{
//			return MapType.isStandardMap(id);
//		}

//		public static bool isGateUnit(int id)
//		{
//			return id == UnitType.GATE
//				|| id == UnitType.GATE2
//				|| id == UnitType.GATE3
//				|| id == UnitType.GATE4;
//		}

//		public static bool isPalisadeGateUnit(int id)
//		{
//			return id == UnitType.PALISADE_GATE
//				|| id == UnitType.PALISADE_GATE2
//				|| id == UnitType.PALISADE_GATE3
//				|| id == UnitType.PALISADE_GATE4;
//		}

//		public static bool isCliffUnit(int id)
//		{
//			return id >= UnitType.CLIFF1 && id <= UnitType.CLIFF10;
//		}

//		public static bool isGaiaUnit(int id)
//		{
//			return id == UnitType.RELIC
//				|| id == UnitType.DEER
//				|| id == UnitType.BOAR
//				|| id == UnitType.JAVELINA
//				|| id == UnitType.TURKEY
//				|| id == UnitType.SHEEP;
//		}

//		public static int normaliseUnit(int id)
//		{
//			if (isGateUnit(id))
//			{
//				return UnitType.GATE;
//			}
//			if (isPalisadeGateUnit(id))
//			{
//				return UnitType.PALISADE_GATE;
//			}
//			return id;
//		}

//		//public static string getTerrainColor(int id, int variation = 1)
//		//{
//		//	return Colours.getTerrainColour(id, variation);
//		//}

//		//public static string getUnitTypeColour(int id)
//		//{
//		//	return Colours.getUnitTypeColour(id);
//		//}

//		//public static string getPlayerColour(int id)
//		//{
//		//	return Colours.getPlayerColour(id);
//		//}
//	}
//}
