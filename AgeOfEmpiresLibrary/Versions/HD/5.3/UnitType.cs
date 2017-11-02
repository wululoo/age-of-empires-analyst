using System;
using System.Collections.Generic;
using System.Linq;

namespace AgeOfEmpiresLibrary
{
    public static class UnitType
    {
        public static MilitaryUnit UNIT_ARCHER = new MilitaryUnit(4, "Archer", Age.FEUDAL_AGE, new Resources(25, 0, 45, 0), 35000, 2000, 0.35f, 0.96f, 6, 30, new Tuple<int, int>(0, 4), 4, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_HAND_CANNONEER = new MilitaryUnit(5, "Hand Cannoneer", Age.IMPERIAL_AGE, new Resources(0, 45, 50, 0), 34000, 3450, 0.35f, 0.96f, 9, 35, new Tuple<int, int>(0, 7), 17, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_ELITE_SKIRMISHER = new MilitaryUnit(6, "Elite Skirmisher", Age.CASTLE_AGE, new Resources(35, 25, 0, 0), 22000, 3000, 0.35f, 0.96f, 7, 35, new Tuple<int, int>(1, 5), 4, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_SKIRMISHER = new MilitaryUnit(7, "Skirmisher", Age.FEUDAL_AGE, new Resources(35, 25, 50, 0), 22000, 3000, 0.35f, 0.96f, 6, 30, new Tuple<int, int>(1, 4), 2, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_LONGBOWMAN = new MilitaryUnit(8, "Longbowman", Age.CASTLE_AGE, new Resources(35, 0, 40, 0), 18000, 2000, 0.35f, 0.96f, 8, 35, new Tuple<int, int>(0, 6), 6, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_MANGUDAI = new MilitaryUnit(11, "Mangudai", Age.CASTLE_AGE, new Resources(55, 0, 65, 0), 26000, 1680, 0.35f, 1.45f, 6, 40, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_FISHING_SHIP = new CivilUnit(13, "Fishing Ship", Age.DARK_AGE, new Resources(75, 0, 0, 0), 40000, 999, 0, 0, 1.26f, 5, 60, null, 0, new Tuple<int, int>(0, 4));
        public static CivilUnit UNIT_TRADE_COG = new CivilUnit(17, "Trade Cog", Age.FEUDAL_AGE, new Resources(100, 0, 50, 0), 36000, 999, 0, 0, 1.32f, 6, 80, null, 0, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_WAR_GALLEY = new MilitaryUnit(21, "War Galley", Age.CASTLE_AGE, new Resources(90, 0, 30, 0), 36000, 3000, 0, 1.43f, 8, 135, new Tuple<int, int>(0, 6), 7, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_CROSSBOWMAN = new MilitaryUnit(24, "Crossbowman", Age.CASTLE_AGE, new Resources(25, 0, 45, 0), 27000, 2000, 0.35f, 0.96f, 7, 35, new Tuple<int, int>(0, 5), 5, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_TEUTONIC_KNIGHT = new MilitaryUnit(25, "Teutonic Knight", Age.CASTLE_AGE, new Resources(0, 85, 40, 0), 12000, 2000, 0, 0.7f, 3, 80, null, 12, new Tuple<int, int>(5, 2));
        public static MilitaryUnit UNIT_BATTERING_RAM = new MilitaryUnit(35, "Battering Ram", Age.CASTLE_AGE, new Resources(160, 0, 75, 0), 36000, 5000, 0, 0.5f, 3, 175, null, 2, new Tuple<int, int>(0, 180));
        public static MilitaryUnit UNIT_BOMBARD_CANNON = new MilitaryUnit(36, "Bombard Cannon", Age.IMPERIAL_AGE, new Resources(225, 0, 225, 0), 56000, 6500, 0.49f, 0.7f, 14, 80, new Tuple<int, int>(2, 12), 40, new Tuple<int, int>(2, 5));
        //public static MilitaryUnit UNIT_LIGHT_CALVARY = new MilitaryUnit(37, "Light Calvary", 4, new Resources(0, 80, 0, 0), 30000, 2040, 0, 1.55f, 6, 45, null, 5, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_KNIGHT = new MilitaryUnit(38, "Knight", Age.CASTLE_AGE, new Resources(0, 60, 75, 0), 30000, 1800, 0, 1.35f, 4, 100, null, 10, new Tuple<int, int>(2, 2));
        public static MilitaryUnit UNIT_CAVALRY_ARCHER = new MilitaryUnit(39, "Cavalry Archer", Age.CASTLE_AGE, new Resources(45, 0, 60, 0), 34000, 2000, 0.7f, 1.4f, 5, 50, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CATAPHRACT = new MilitaryUnit(40, "Cataphract", Age.CASTLE_AGE, new Resources(0, 70, 75, 0), 20000, 1800, 0, 1.35f, 4, 110, null, 9, new Tuple<int, int>(2, 1));
        public static MilitaryUnit UNIT_HUSKARL = new MilitaryUnit(41, "Huskarl", Age.CASTLE_AGE, new Resources(0, 52, 26, 0), 16000, 2000, 0, 1.05f, 3, 60, null, 10, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_TREBUCHET_UNPACKED = new MilitaryUnit(331, "Trebuchet", Age.IMPERIAL_AGE, new Resources(200, 0, 200, 0), 50000, 10000, 0.42f, 0, 18, 150, new Tuple<int, int>(4, 16), 200, new Tuple<int, int>(1, 150));
        public static MilitaryUnit UNIT_JANISSARY = new MilitaryUnit(46, "Janissary", Age.CASTLE_AGE, new Resources(0, 60, 55, 0), 17000, 3450, 0.28f, 0.96f, 10, 44, new Tuple<int, int>(0, 8), 17, new Tuple<int, int>(1, 0));
        public static GaiaUnit UNIT_WILD_BOAR = new GaiaUnit(48, "Wild Boar", new Resources(0, 340, 0, 0), 0, 2000, 0, 0.96f, 4, 75, null, 7, new Tuple<int, int>(0, 0));
        //public static Unit UNIT_ROYAL_JANISSARY = new Unit(52, "Royal Janissary");
        public static CivilUnit UNIT_FISHERMAN_M = new CivilUnit(56, "Fisherman", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_FISHERMAN_F = new CivilUnit(57, "Fisherman", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CHU_KO_NU = new MilitaryUnit(73, "Chu Ko Nu", Age.CASTLE_AGE, new Resources(40, 0, 35, 0), 16000, 3600, 0.21f, 0.96f, 6, 45, new Tuple<int, int>(0, 4), 8, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_MILITIA = new MilitaryUnit(74, "Militia", Age.DARK_AGE, new Resources(0, 60, 20, 0), 21000, 2000, 0, 0.9f, 4, 40, null, 4, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_MAN_AT_ARMS = new MilitaryUnit(75, "Man-at-Arms", Age.FEUDAL_AGE, new Resources(0, 60, 20, 0), 21000, 2000, 0, 0.9f, 4, 45, null, 6, new Tuple<int, int>(0, 1));
        //public static Unit UNIT_HEAVY_SWORDSMAN = new MilitaryUnit(76, "Heavy Swordsman");
        public static MilitaryUnit UNIT_LONG_SWORDSMAN = new MilitaryUnit(77, "Long Swordsman", Age.CASTLE_AGE, new Resources(0, 60, 20, 0), 21000, 2000, 0, 0.9f, 4, 45, null, 9, new Tuple<int, int>(0, 1));
        public static CivilUnit UNIT_VILLAGER_M = new CivilUnit(83, "Villager", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_SPEARMAN = new MilitaryUnit(93, "Spearman", Age.FEUDAL_AGE, new Resources(35, 25, 0, 0), 22000, 3000, 0, 1, 4, 45, null, 3, new Tuple<int, int>(0, 0));
        //public static MilitaryUnit UNIT_BERSERK = new MilitaryUnit(94, "Berserk");
        public static CivilUnit UNIT_BUILDER_M = new CivilUnit(118, "Builder", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_FORAGER_M = new CivilUnit(120, "Forager", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_HUNTER_M = new CivilUnit(122, "Hunter", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_LUMBERJACK_M = new CivilUnit(123, "Lumberjack", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_STONE_MINER_M = new CivilUnit(124, "Stone Miner", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MonkUnit UNIT_MONK = new MonkUnit(125, "Monk", Age.CASTLE_AGE, new Resources(0, 0, 100, 0), 51000, 4, 62000, 5500, 0, 0.7f, 11, 30, new Tuple<int, int>(0, 9), 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_WOLF = new GaiaUnit(126, "Wolf", new Resources(0, 0, 0, 0), 0, 2000, 0, 1.05f, 12, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_TRADE_CART_EMPTY = new CivilUnit(128, "Trade Cart", Age.FEUDAL_AGE, new Resources(100, 0, 50, 0), 50000, 999, 0, 0, 1, 7, 70, null, 0, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_REPAIRER_M = new CivilUnit(156, "Repairer", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CONDOTTIERO = new MilitaryUnit(183, "Condottiero", Age.IMPERIAL_AGE, new Resources(0, 50, 35, 0), 18000, 1900, 0, 1.2f, 6, 80, null, 10, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_SLINGER = new MilitaryUnit(185, "Slinger", Age.CASTLE_AGE, new Resources(0, 30, 40, 0), 25000, 2000, 0.35f, 0.96f, 7, 60, new Tuple<int, int>(1, 5), 5, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_TRADE_CART_FULL = new CivilUnit(204, "Trade Cart", Age.FEUDAL_AGE, new Resources(100, 0, 50, 0), 50000, 999, 0, 0, 1, 7, 70, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_IMPERIAL_CAMEL = new MilitaryUnit(207, "Imperial Camel", Age.IMPERIAL_AGE, new Resources(0, 55, 60, 0), 20000, 2000, 0, 1.45f, 5, 140, null, 9, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_BUILDER_F = new CivilUnit(212, "Builder", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_FARMER_F = new CivilUnit(214, "Farmer", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_HUNTER_F = new CivilUnit(216, "Hunter", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_LUMBERJACK_F = new CivilUnit(218, "Lumberjack", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_STONE_MINER_F = new CivilUnit(220, "Stone Miner", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_REPAIRER_F = new CivilUnit(222, "Repairer", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
		public static MilitaryUnit UNIT_WOAD_RAIDER = new MilitaryUnit(232, "Woad Raider", Age.CASTLE_AGE, new Resources(0, 65, 25, 0), 10000, 2000, 0, 1.38f, 3, 65, null, 8, new Tuple<int, int>(0, 1));
		public static MilitaryUnit UNIT_LONGBOAT = new MilitaryUnit(233, "Longboat", Age.CASTLE_AGE, new Resources(85, 0, 43, 0), 25000, 3000, 0, 1.54f, 8, 130, new Tuple<int, int>(0, 6), 7, new Tuple<int, int>(0, 6));
		public static MilitaryUnit UNIT_WAR_ELEPHANT = new MilitaryUnit(239, "War Elephant", Age.CASTLE_AGE, new Resources(0, 200, 75, 0), 31000, 2000, 0, 0.6f, 4, 450, null, 15, new Tuple<int, int>(1, 2));
        public static CivilUnit UNIT_FARMER_M = new CivilUnit(259, "Farmer", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_SCORPION = new MilitaryUnit(279, "Scorpion", Age.CASTLE_AGE, new Resources(75, 0, 75, 0), 30000, 3600, 0.49f, 0.65f, 9, 40, new Tuple<int, int>(2, 7), 12, new Tuple<int, int>(0, 7));
        public static MilitaryUnit UNIT_MANGONEL = new MilitaryUnit(280, "Mangonel", Age.CASTLE_AGE, new Resources(160, 0, 135, 0), 46000, 6000, 0, 0.6f, 9, 50, new Tuple<int, int>(3, 7), 40, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_THROWING_AXEMAN = new MilitaryUnit(281, "Throwing Axeman", Age.CASTLE_AGE, new Resources(0, 55, 25, 0), 17000, 2000, 0.7f, 1, 5, 60, new Tuple<int, int>(0, 3), 7, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_MAMELUKE = new MilitaryUnit(282, "Mameluke", Age.CASTLE_AGE, new Resources(0, 55, 85, 0), 23000, 2000, 0.42f, 1.4f, 5, 65, new Tuple<int, int>(0, 3), 8, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CAVALIER = new MilitaryUnit(283, "Cavalier", Age.IMPERIAL_AGE, new Resources(0, 60, 75, 0), 30000, 1800, 0, 1.35f, 4, 120, null, 12, new Tuple<int, int>(2, 2));
        public static MonkUnit UNIT_MONK_WITH_RELIC = new MonkUnit(286, "Monk with Relic", Age.CASTLE_AGE, new Resources(0, 0, 100, 0), 51000, 4, 62000, 5500, 0, 0.7f, 11, 30, new Tuple<int, int>(0, 9), 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_SAMURAI = new MilitaryUnit(291, "Samurai", Age.CASTLE_AGE, new Resources(0, 60, 30, 0), 9000, 1425, 0, 1, 4, 60, null, 8, new Tuple<int, int>(1, 1));
        public static CivilUnit UNIT_VILLAGER_F = new CivilUnit(293, "Villager", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_LLAMA = new GaiaUnit(305, "Llama", new Resources(0, 100, 0, 0), 0.25f, 0, 0, 0.7f, 3, 7, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CAMEL = new MilitaryUnit(329, "Camel", Age.CASTLE_AGE, new Resources(0, 55, 60, 0), 22000, 2000, 0, 1.45f, 4, 100, null, 6, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_HEAVY_CAMEL = new MilitaryUnit(330, "Heavy Camel", Age.IMPERIAL_AGE, new Resources(0, 55, 60, 0), 22000, 2000, 0, 1.45f, 5, 120, null, 7, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_TREBUCHET_PACKED = new MilitaryUnit(331, "Trebuchet(Packed)", 5, new Resources(200, 0, 200, 0), 50000, 0, 0, 0.8f, 18, 150, null, 0, new Tuple<int, int>(2, 8));
        public static GaiaUnit UNIT_DEER = new GaiaUnit(333, "Deer", new Resources(0, 140, 0, 0), 0.25f, 0, 0, 0.737f, 2, 5, null, 0, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_FORAGER_F = new CivilUnit(354, "Forager", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_PIKEMAN = new MilitaryUnit(358, "Pikeman", Age.CASTLE_AGE, new Resources(25, 35, 0, 0), 22000, 3000, 0, 1, 4, 55, null, 4, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_HALBERDIER = new MilitaryUnit(359, "Halberdier", Age.IMPERIAL_AGE, new Resources(25, 35, 0, 0), 22000, 3000, 0, 1, 4, 60, null, 6, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_CANNON_GALLEON = new MilitaryUnit(420, "Cannon Galleon", Age.IMPERIAL_AGE, new Resources(200, 0, 150, 0), 46000, 10000, 0, 1.1f, 15, 120, new Tuple<int, int>(3, 13), 35, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_CAPPED_RAM = new MilitaryUnit(422, "Capped Ram", Age.IMPERIAL_AGE, new Resources(160, 0, 75, 0), 36000, 5000, 0, 0.5f, 3, 200, null, 4, new Tuple<int, int>(0, 190));
        public static CivilUnit UNIT_KING = new CivilUnit(434, "King", Age.DARK_AGE, new Resources(0, 0, 0, 0), 0, 0, 0, 0, 1.32f, 6, 75, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_PETARD = new MilitaryUnit(440, "Petard", Age.CASTLE_AGE, new Resources(0, 65, 20, 0), 25000, 0, 0, 0.8f, 4, 50, null, 25, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_HUSSAR = new MilitaryUnit(441, "Hussar", Age.IMPERIAL_AGE, new Resources(0, 80, 0, 0), 30000, 1900, 0, 1.5f, 10, 75, null, 7, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_GALLEON = new MilitaryUnit(442, "Galleon", Age.IMPERIAL_AGE, new Resources(90, 0, 30, 0), 36000, 3000, 0, 1.43f, 9, 165, new Tuple<int, int>(0, 7), 8, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_SCOUT_CAVALRY = new MilitaryUnit(448, "Scout Cavalry", Age.FEUDAL_AGE, new Resources(0, 80, 0, 0), 30000, 2040, 0, 1.55f, 6, 45, null, 5, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_TWO_HANDED_SWORDSMAN = new MilitaryUnit(473, "Two-Handed Swordsman", Age.IMPERIAL_AGE, new Resources(0, 60, 20, 0), 21000, 2000, 0, 0.9f, 5, 60, null, 12, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_HEAVY_CAVALRY_ARCHER = new MilitaryUnit(474, "Heavy Cavalry Archer", Age.IMPERIAL_AGE, new Resources(40, 0, 60, 0), 27000, 2000, 0.7f, 1.4f, 6, 60, new Tuple<int, int>(0, 4), 7, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_ARBALEST = new MilitaryUnit(492, "Arbalest", Age.IMPERIAL_AGE, new Resources(25, 0, 45, 0), 27000, 2000, 0.35f, 0.96f, 7, 40, new Tuple<int, int>(0, 5), 6, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_DEMOLITION_SHIP = new MilitaryUnit(527, "Demolition Ship", Age.CASTLE_AGE, new Resources(70, 0, 50, 0), 31000, 0, 0, 1.6f, 6, 60, null, 110, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_HEAVY_DEMOLITION_SHIP = new MilitaryUnit(528, "Heavy Demolition Ship", Age.IMPERIAL_AGE, new Resources(70, 0, 50, 0), 31000, 0, 0, 1.6f, 6, 70, null, 140, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_FIRE_SHIP = new MilitaryUnit(529, "Fire Ship", Age.CASTLE_AGE, new Resources(75, 0, 45, 0), 36000, 250, 0, 1.35f, 5, 120, new Tuple<int, int>(0, 3), 2, new Tuple<int, int>(0, 7));
        public static MilitaryUnit UNIT_ELITE_LONGBOWMAN = new MilitaryUnit(530, "Elite Longbowman", Age.IMPERIAL_AGE, new Resources(35, 0, 40, 0), 18000, 2000, 0.35f, 0.96f, 10, 40, new Tuple<int, int>(0, 8), 7, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_THROWING_AXEMAN = new MilitaryUnit(531, "Elite Throwing Axeman", Age.IMPERIAL_AGE, new Resources(0, 55, 25, 0), 17000, 2000, 0.56f, 1, 6, 70, new Tuple<int, int>(0, 4), 8, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_FAST_FIRE_SHIP = new MilitaryUnit(532, "Fast Fire Ship", Age.IMPERIAL_AGE, new Resources(75, 0, 45, 0), 36000, 250, 0, 1.43f, 6, 140, new Tuple<int, int>(0, 3), 3, new Tuple<int, int>(0, 9));
        public static MilitaryUnit UNIT_ELITE_LONGBOAT = new MilitaryUnit(533, "Elite Longboat", Age.IMPERIAL_AGE, new Resources(80, 0, 40, 0), 25000, 3000, 0, 1.54f, 9, 160, new Tuple<int, int>(0, 7), 8, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_ELITE_WOAD_RAIDER = new MilitaryUnit(534, "Elite Woad Raider", Age.IMPERIAL_AGE, new Resources(0, 65, 25, 0), 10000, 2000, 0, 1.38f, 3, 80, null, 13, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_GALLEY = new MilitaryUnit(539, "Galley", Age.FEUDAL_AGE, new Resources(90, 0, 30, 0), 60000, 3000, 0, 1.43f, 7, 120, new Tuple<int, int>(0, 5), 6, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_HEAVY_SCORPION = new MilitaryUnit(542, "Heavy Scorpion", Age.IMPERIAL_AGE, new Resources(75, 0, 75, 0), 30000, 3600, 0.49f, 0.65f, 9, 50, new Tuple<int, int>(2, 7), 16, new Tuple<int, int>(0, 7));
        public static CivilUnit UNIT_TRANSPORT_SHIP = new CivilUnit(545, "Transport Ship", Age.DARK_AGE, new Resources(125, 0, 0, 0), 45000, 5, 0, 0, 1.45f, 5, 100, null, 0, new Tuple<int, int>(4, 8));
        public static MilitaryUnit UNIT_LIGHT_CAVALRY = new MilitaryUnit(546, "Light Calvary", Age.CASTLE_AGE, new Resources(0, 80, 0, 0), 30000, 2040, 0, 1.55f, 6, 45, null, 5, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_SIEGE_RAM = new MilitaryUnit(548, "Siege Ram", Age.IMPERIAL_AGE, new Resources(160, 0, 75, 0), 36000, 5000, 0, 0.6f, 3, 270, null, 4, new Tuple<int, int>(0, 195));
        public static MilitaryUnit UNIT_ONAGER = new MilitaryUnit(550, "Onager", Age.IMPERIAL_AGE, new Resources(160, 0, 135, 0), 46000, 6000, 0, 0.6f, 10, 60, new Tuple<int, int>(3, 8), 50, new Tuple<int, int>(0, 7));
        public static MilitaryUnit UNIT_ELITE_CATAPHRACT = new MilitaryUnit(553, "Elite Cataphract", Age.IMPERIAL_AGE, new Resources(0, 70, 75, 0), 20000, 1700, 0, 1.35f, 5, 150, null, 12, new Tuple<int, int>(2, 1));
        public static MilitaryUnit UNIT_ELITE_TEUTONIC_KNIGHT = new MilitaryUnit(554, "Elite Teutonic Knight", Age.IMPERIAL_AGE, new Resources(0, 55, 25, 0), 17000, 2000, 0.7f, 1, 5, 60, new Tuple<int, int>(0, 3), 7, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_HUSKARL = new MilitaryUnit(555, "Elite Huskarl", Age.IMPERIAL_AGE, new Resources(0, 52, 26, 0), 16000, 2000, 0, 1.05f, 5, 70, null, 12, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_ELITE_MAMELUKE = new MilitaryUnit(556, "Elite Mameluke", Age.IMPERIAL_AGE, new Resources(0, 55, 85, 0), 23000, 2000, 0.35f, 1.4f, 5, 80, new Tuple<int, int>(0, 3), 10, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_ELITE_JANISSARY = new MilitaryUnit(567, "Elite Janissary", Age.IMPERIAL_AGE, new Resources(0, 60, 55, 0), 17000, 3450, 0, 0.96f, 10, 50, new Tuple<int, int>(0, 8), 22, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_ELITE_WAR_ELEPHANT = new MilitaryUnit(568, "Elite War Elephant", Age.IMPERIAL_AGE, new Resources(0, 200, 75, 0), 31000, 2000, 0, 0.6f, 5, 600, null, 20, new Tuple<int, int>(1, 3));
        public static MilitaryUnit UNIT_ELITE_CHU_KO_NU = new MilitaryUnit(559, "Elite Chu Ko Nu", Age.IMPERIAL_AGE, new Resources(40, 0, 35, 0), 13000, 3750, 0.21f, 0.96f, 6, 50, new Tuple<int, int>(0, 6), 8, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_SAMURAI = new MilitaryUnit(560, "Elite Samurai", Age.IMPERIAL_AGE, new Resources(0, 60, 30, 0), 9000, 1425, 0, 1, 5, 80, null, 12, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_ELITE_MANGUDAI = new MilitaryUnit(561, "Elite Mangudai", Age.IMPERIAL_AGE, new Resources(55, 0, 65, 0), 26000, 1680, 0.35f, 1.45f, 6, 60, new Tuple<int, int>(0, 4), 8, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_CHAMPION = new MilitaryUnit(567, "Champion", Age.IMPERIAL_AGE, new Resources(0, 60, 20, 0), 21000, 2000, 0, 0.9f, 5, 70, null, 13, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_PALADIN = new MilitaryUnit(569, "Paladin", Age.IMPERIAL_AGE, new Resources(0, 60, 75, 0), 30000, 1900, 0, 1.35f, 5, 160, null, 14, new Tuple<int, int>(2, 3));
        public static CivilUnit UNIT_GOLD_MINER_M = new CivilUnit(579, "Gold Miner", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_GOLD_MINER_F = new CivilUnit(581, "Gold Miner", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_GENITOUR = new MilitaryUnit(583, "Genitour", Age.CASTLE_AGE, new Resources(35, 50, 0, 0), 25000, 3000, 0.21f, 1.35f, 5, 50, new Tuple<int, int>(1, 4), 3, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_SIEGE_ONAGER = new MilitaryUnit(588, "Siege Onager", Age.IMPERIAL_AGE, new Resources(160, 0, 135, 0), 46000, 6000, 0, 0.6f, 10, 70, new Tuple<int, int>(3, 8), 75, new Tuple<int, int>(0, 8));
        public static CivilUnit UNIT_SHEPHERD_F = new CivilUnit(590, "Shepherd", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static CivilUnit UNIT_SHEPHERD_M = new CivilUnit(592, "Shepherd", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_SHEEP = new GaiaUnit(594, "Sheep", new Resources(0, 100, 0, 0), 0.25f, 0, 0, 0.7f, 3, 7, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_GENITOUR = new MilitaryUnit(596, "Elite Genitour", Age.IMPERIAL_AGE, new Resources(35, 50, 0, 0), 23000, 3000, 0.21f, 1.35f, 6, 55, new Tuple<int, int>(1, 4), 4, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_ELITE_CANNON_GALLEON = new MilitaryUnit(691, "Elite Cannon Galleon", Age.IMPERIAL_AGE, new Resources(200, 0, 150, 0), 46000, 10000, 0, 1.1f, 17, 150, new Tuple<int, int>(3, 15), 45, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_BERSERK = new MilitaryUnit(692, "Berserk", Age.CASTLE_AGE, new Resources(0, 65, 25, 0), 14000, 2000, 0, 1.05f, 3, 61, null, 9, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_BERSERK = new MilitaryUnit(694, "Elite Berserk", Age.IMPERIAL_AGE, new Resources(0, 65, 25, 0), 14000, 2000, 0, 1.05f, 5, 75, null, 14, new Tuple<int, int>(2, 1));
        public static MilitaryUnit UNIT_JAGUAR_WARRIOR = new MilitaryUnit(725, "Jaguar Warrior", Age.CASTLE_AGE, new Resources(0, 60, 30, 0), 17000, 2000, 0, 1, 3, 50, null, 10, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_ELITE_JAGUAR_WARRIOR = new MilitaryUnit(726, "Elite Jaguar Warrior", Age.IMPERIAL_AGE, new Resources(0, 60, 30, 0), 17000, 2000, 0, 1, 5, 75, null, 12, new Tuple<int, int>(2, 1));
        public static MilitaryUnit UNIT_EAGLE_SCOUT = new MilitaryUnit(751, "Eagel Scout", Age.FEUDAL_AGE, new Resources(0, 20, 50, 0), 60000, 2000, 0, 1.1f, 6, 50, null, 4, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_ELITE_EAGLE_WARRIOR = new MilitaryUnit(752, "Elite Eagle Warrior", Age.IMPERIAL_AGE, new Resources(0, 20, 50, 0), 20000, 2000, 0, 1.3f, 6, 60, null, 9, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_EAGLE_WARRIOR = new MilitaryUnit(753, "Eagle Warrior", Age.CASTLE_AGE, new Resources(0, 20, 50, 0), 32000, 2000, 0, 1.2f, 6, 55, null, 7, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_TARKAN = new MilitaryUnit(755, "Tarkan", Age.CASTLE_AGE, new Resources(0, 60, 60, 0), 14000, 2100, 0, 1.35f, 5, 100, null, 8, new Tuple<int, int>(1, 3));
        public static MilitaryUnit UNIT_ELITE_TARKAN = new MilitaryUnit(757, "Elite Tarkan", Age.IMPERIAL_AGE, new Resources(0, 60, 60, 0), 14000, 2100, 0, 1.35f, 7, 150, null, 11, new Tuple<int, int>(1, 4));
        public static MilitaryUnit UNIT_HUSKARL_2 = new MilitaryUnit(759, "Huskarl", Age.CASTLE_AGE, new Resources(0, 52, 26, 0), 16000, 2000, 0, 1.05f, 3, 60, null, 10, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_ELITE_HUSKARL_2 = new MilitaryUnit(761, "Elite Huskarl", Age.IMPERIAL_AGE, new Resources(0, 52, 26, 0), 16000, 2000, 0, 1.05f, 5, 70, null, 12, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_PLUMED_ARCHER = new MilitaryUnit(763, "Plumed Archer", Age.CASTLE_AGE, new Resources(40, 0, 40, 0), 16000, 1900, 0.35f, 1.2f, 6, 50, new Tuple<int, int>(0, 4), 5, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_PLUMED_ARCHER = new MilitaryUnit(765, "Elite Plumed Archer", Age.IMPERIAL_AGE, new Resources(35, 0, 35, 0), 16000, 1900, 0.35f, 1.2f, 7, 65, new Tuple<int, int>(0, 5), 5, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_CONQUISTADOR = new MilitaryUnit(771, "Conquistador", Age.CASTLE_AGE, new Resources(0, 60, 70, 0), 24000, 2900, 0.28f, 1.3f, 8, 55, new Tuple<int, int>(0, 6), 16, new Tuple<int, int>(2, 2));
        public static MilitaryUnit UNIT_ELITE_CONQUISTADOR = new MilitaryUnit(773, "Elite Conquistador", Age.IMPERIAL_AGE, new Resources(0, 60, 70, 0), 24000, 2900, 0.28f, 1.3f, 8, 70, new Tuple<int, int>(0, 6), 18, new Tuple<int, int>(2, 2));
        public static MonkUnit UNIT_MISSIONARY = new MonkUnit(775, "Missionary", Age.CASTLE_AGE, new Resources(0, 0, 100, 0), 51000, 4, 62000, 5500, 0, 0.7f, 11, 30, new Tuple<int, int>(0, 9), 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_JAGUAR = new GaiaUnit(812, "Jaguar", new Resources(0, 0, 0, 0), 0, 2000, 0, 1.05f, 12, 25, null, 3, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_WAR_WAGON = new MilitaryUnit(827, "War Wagon", Age.CASTLE_AGE, new Resources(110, 0, 60, 0), 21000, 2500, 0.7f, 1.2f, 6, 150, new Tuple<int, int>(0, 4), 9, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_ELITE_WAR_WAGON = new MilitaryUnit(829, "Elite War Wagon", Age.IMPERIAL_AGE, new Resources(110, 0, 60, 0), 2100, 2500, 0, 1.2f, 8, 200, new Tuple<int, int>(0, 5), 9, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_TURTLE_SHIP = new MilitaryUnit(831, "Turtle Ship", Age.CASTLE_AGE, new Resources(180, 0, 180, 0), 50000, 6000, 0, 0.9f, 8, 200, new Tuple<int, int>(0, 6), 50, new Tuple<int, int>(6, 5));
        public static MilitaryUnit UNIT_ELITE_TURTLE_SHIP = new MilitaryUnit(832, "Elite Turtle Ship", Age.IMPERIAL_AGE, new Resources(180, 0, 180, 0), 50000, 6000, 0, 0.9f, 8, 300, new Tuple<int, int>(0, 6), 50, new Tuple<int, int>(8, 6));
        public static GaiaUnit UNIT_TURKEY = new GaiaUnit(833, "Turkey", new Resources(0, 100, 0, 0), 0.25f, 0, 0, 0.7f, 3, 7, null, 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_WILD_HORSE = new GaiaUnit(835, "Wild Horse", new Resources(0, 0, 0, 0), 0, 0, 0, 1.2f, 2, 50, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_GENOESE_CROSSBOWMAN = new MilitaryUnit(866, "Genoese Crossbowman", Age.CASTLE_AGE, new Resources(0, 45, 45, 0), 22000, 3000, 0.35f, 0.96f, 8, 45, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_ELITE_GENOESE_CROSSBOWMAN = new MilitaryUnit(868, "Elite Genoese Crossbowman", Age.IMPERIAL_AGE, new Resources(0, 45, 45, 0), 19000, 2000, 0.35f, 0.96f, 8, 50, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_MAGYAR_HUSZAR = new MilitaryUnit(869, "Magyar Huszar", Age.CASTLE_AGE, new Resources(0, 80, 10, 0), 16000, 1800, 0, 1.5f, 5, 70, null, 9, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_ELITE_MAGYAR_HUSZAR = new MilitaryUnit(871, "Elite Magyar, Huszar", Age.IMPERIAL_AGE, new Resources(0, 80, 10, 0), 16000, 1800, 0, 1.5f, 6, 85, null, 10, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_ELEPHANT_ARCHER = new MilitaryUnit(873, "Elephant Archer", Age.CASTLE_AGE, new Resources(0, 100, 80, 0), 25000, 2500, 0.7f, 0.8f, 7, 280, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_ELITE_ELEPHANT_ARCHER = new MilitaryUnit(875, "Elite Elephant Archer", Age.IMPERIAL_AGE, new Resources(0, 100, 80, 0), 25000, 2500, 0.7f, 0.8f, 7, 330, new Tuple<int, int>(0, 4), 7, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_BOYAR = new MilitaryUnit(876, "Boyar", Age.CASTLE_AGE, new Resources(0, 50, 80, 0), 23000, 1900, 0, 1.4f, 5, 100, null, 12, new Tuple<int, int>(4, 1));
        public static MilitaryUnit UNIT_ELITE_BOYAR = new MilitaryUnit(878, "Elite Boyar", Age.IMPERIAL_AGE, new Resources(0, 50, 80, 0), 20000, 1900, 0, 1.4f, 5, 130, null, 14, new Tuple<int, int>(6, 2));
        public static MilitaryUnit UNIT_KAMAYUK = new MilitaryUnit(879, "Kamayuk", Age.CASTLE_AGE, new Resources(0, 60, 30, 0), 10000, 2000, 0, 1, 4, 60, new Tuple<int, int>(0, 1), 7, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_KAMAYUK = new MilitaryUnit(881, "Elite Kamayuk", Age.IMPERIAL_AGE, new Resources(0, 60, 30, 0), 10000, 2000, 0, 1, 5, 80, new Tuple<int, int>(0, 1), 8, new Tuple<int, int>(1, 0));
        public static MilitaryUnit UNIT_CONDOTTIERO_2 = new MilitaryUnit(882, "Condottiero", Age.IMPERIAL_AGE, new Resources(0, 50, 35, 0), 18000, 1900, 0, 1.2f, 6, 80, null, 10, new Tuple<int, int>(1, 1));
        public static GaiaUnit UNIT_WILD_CAMEL = new GaiaUnit(884, "Wild Camel", new Resources(0, 0, 0, 0), 0, 0, 0, 1.2f, 2, 50, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_SIEGE_TOWER = new MilitaryUnit(885, "Siege Tower", Age.CASTLE_AGE, new Resources(200, 0, 160, 0), 36000, 0, 0, 0.8f, 8, 220, null, 0, new Tuple<int, int>(-2, 100));
        public static MilitaryUnit UNIT_TARKAN_2 = new MilitaryUnit(886, "Tarkan", Age.CASTLE_AGE, new Resources(0, 60, 60, 0), 14000, 2100, 0, 1.35f, 5, 100, null, 8, new Tuple<int, int>(1, 3));
        public static MilitaryUnit UNIT_ELITE_TARKAN_2 = new MilitaryUnit(887, "Elite Tarkan", Age.IMPERIAL_AGE, new Resources(0, 60, 60, 0), 14000, 2100, 0, 1.35f, 7, 150, null, 11, new Tuple<int, int>(1, 4));
        public static GaiaUnit UNIT_CAMEL_GAIA = new GaiaUnit(897, "Camel (Gaia)", new Resources(0, 0, 0, 0), 0, 0, 0, 1.2f, 2, 50, null, 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_ELEPHANT = new GaiaUnit(936, "Elephant", new Resources(0, 400, 0, 0), 0.4f, 2000, 0, 0.96f, 4, 75, null, 7, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ORGAN_GUN = new MilitaryUnit(1001, "Organ Gun", Age.CASTLE_AGE, new Resources(80, 0, 60, 0), 21000, 3450, 0.42f, 0.85f, 9, 60, new Tuple<int, int>(1, 7), 16, new Tuple<int, int>(2, 4));
        public static MilitaryUnit UNIT_ELITE_ORGAN_GUN = new MilitaryUnit(1003, "Elite Organ Gun", Age.IMPERIAL_AGE, new Resources(80, 0, 60, 0), 21000, 3450, 0.42f, 0.85f, 9, 70, new Tuple<int, int>(1, 7), 20, new Tuple<int, int>(2, 6));
        public static MilitaryUnit UNIT_CARAVEL = new MilitaryUnit(1004, "Caravel", Age.CASTLE_AGE, new Resources(90, 0, 40, 0), 36000, 3000, 0, 1.43f, 9, 143, new Tuple<int, int>(0, 6), 6, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_ELITE_CARAVEL = new MilitaryUnit(1006, "Elite Caravel", Age.IMPERIAL_AGE, new Resources(90, 0, 40, 0), 36000, 3000, 0, 1.43f, 9, 165, new Tuple<int, int>(0, 7), 8, new Tuple<int, int>(0, 8));
        public static MilitaryUnit UNIT_CAMEL_ARCHER = new MilitaryUnit(1007, "Camel Archer", Age.CASTLE_AGE, new Resources(50, 0, 60, 0), 21000, 2000, 0.35f, 1.4f, 5, 60, new Tuple<int, int>(0, 4), 7, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_CAMEL_ARCHER = new MilitaryUnit(1009, "Elite Camel Archer", Age.IMPERIAL_AGE, new Resources(50, 0, 60, 0), 21000, 2000, 0.35f, 1.4f, 5, 65, new Tuple<int, int>(0, 4), 8, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_GENITOUR_2 = new MilitaryUnit(1010, "Genitour", Age.CASTLE_AGE, new Resources(35, 50, 0, 0), 25000, 3000, 0.21f, 1.35f, 5, 50, new Tuple<int, int>(1, 4), 3, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_ELITE_GENITOUR_2 = new MilitaryUnit(1012, "Elite Genitour", Age.IMPERIAL_AGE, new Resources(35, 50, 0, 0), 23000, 3000, 0.21f, 1.35f, 6, 55, new Tuple<int, int>(1, 4), 4, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_GBETO = new MilitaryUnit(1013, "Gbeto", Age.CASTLE_AGE, new Resources(0, 50, 40, 0), 17000, 2000, 0.7f, 1.25f, 6, 30, new Tuple<int, int>(0, 5), 10, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_GBETO = new MilitaryUnit(1015, "Elite Gbeto", Age.IMPERIAL_AGE, new Resources(0, 50, 40, 0), 17000, 2000, 0.7f, 1.25f, 6, 45, new Tuple<int, int>(0, 6), 13, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_SHOTEL_WARRIOR = new MilitaryUnit(1016, "Shotel Warrior", Age.CASTLE_AGE, new Resources(0, 50, 35, 0), 8000, 2000, 0, 1.2f, 3, 40, null, 16, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_ELITE_SHOTEL_WARRIOR = new MilitaryUnit(1018, "Elite Shotel Warrior", Age.IMPERIAL_AGE, new Resources(0, 50, 35, 0), 8000, 2000, 0, 1.2f, 3, 50, null, 18, new Tuple<int, int>(0, 1));
        public static GaiaUnit UNIT_ZEBRA = new GaiaUnit(1019, "Zebra", new Resources(0, 140, 0, 0), 0.25f, 0, 0, 0.737f, 2, 5, null, 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_OSTRICH = new GaiaUnit(1026, "Ostrich", new Resources(0, 140, 0, 0), 0.25f, 0, 0, 0.737f, 2, 5, null, 0, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_LION = new GaiaUnit(1029, "Lion", new Resources(0, 0, 0, 0), 0, 2000, 0, 1.05f, 12, 25, null, 3, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_CROCODILE = new GaiaUnit(1031, "Crocodile", new Resources(0, 0, 0, 0), 0, 2000, 0, 1.05f, 12, 25, null, 3, new Tuple<int, int>(0, 0));
        public static GaiaUnit UNIT_GOAT = new GaiaUnit(1060, "Goat", new Resources(0, 100, 0, 0), 0.25f, 0, 0, 0.7f, 3, 7, null, 0, new Tuple<int, int>(0, 0));
        public static MilitaryUnit UNIT_FIRE_GALLEY = new MilitaryUnit(1103, "Fire Galley", Age.FEUDAL_AGE, new Resources(75, 0, 45, 0), 60000, 250, 0, 1.3f, 5, 100, new Tuple<int, int>(0, 3), 1, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_DEMOLITION_RAFT = new MilitaryUnit(1104, "Demolition Raft", Age.FEUDAL_AGE, new Resources(70, 0, 50, 0), 45000, 0, 0, 1.5f, 6, 45, null, 90, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_SIEGE_TOWER_2 = new MilitaryUnit(1105, "Siege Tower", Age.CASTLE_AGE, new Resources(200, 0, 160, 0), 36000, 0, 0, 0.8f, 8, 220, null, 0, new Tuple<int, int>(-2, 100));
        public static MilitaryUnit UNIT_BALLISTA_ELEPHANT = new MilitaryUnit(1120, "Ballista Elephant", Age.CASTLE_AGE, new Resources(0, 100, 80, 0), 25000, 2500, 0.28f, 0.8f, 7, 250, new Tuple<int, int>(0, 5), 8, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_ELITE_BALLISTA_ELEPHANT = new MilitaryUnit(1122, "Elite Ballista Elephant", Age.IMPERIAL_AGE, new Resources(0, 100, 80, 0), 25000, 2500, 0.28f, 0.8f, 7, 290, new Tuple<int, int>(0, 5), 9, new Tuple<int, int>(0, 3));
        public static MilitaryUnit UNIT_KARAMBIT_WARRIOR = new MilitaryUnit(1123, "Karambit Warrior", Age.CASTLE_AGE, new Resources(0, 25, 10, 0), 6000, 2000, 0, 1.2f, 3, 30, null, 5, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_KARAMBIT_WARRIOR = new MilitaryUnit(1125, "Elite Karambit Warrior", Age.IMPERIAL_AGE, new Resources(0, 25, 10, 0), 6000, 2000, 0, 1.2f, 3, 40, null, 8, new Tuple<int, int>(1, 1));
        public static MilitaryUnit UNIT_ARAMBAI = new MilitaryUnit(1126, "Arambai", Age.CASTLE_AGE, new Resources(50, 0, 60, 0), 21000, 2000, 0.7f, 1.35f, 7, 60, new Tuple<int, int>(0, 5), 18, new Tuple<int, int>(0, 1));
        public static MilitaryUnit UNIT_ELITE_ARAMBAI = new MilitaryUnit(1128, "Elite Arambai", Age.IMPERIAL_AGE, new Resources(50, 0, 60, 0), 21000, 2000, 0.7f, 1.35f, 7, 65, new Tuple<int, int>(0, 5), 20, new Tuple<int, int>(0, 2));
        public static MilitaryUnit UNIT_RATTAN_ARCHER = new MilitaryUnit(1129, "Rattan Archer", Age.CASTLE_AGE, new Resources(50, 0, 45, 0), 16000, 2000, 0.35f, 1.1f, 6, 35, new Tuple<int, int>(0, 4), 6, new Tuple<int, int>(0, 4));
        public static MilitaryUnit UNIT_ELITE_RATTAN_ARCHER = new MilitaryUnit(1131, "Elite Rattan Archer", Age.IMPERIAL_AGE, new Resources(50, 0, 45, 0), 16000, 2000, 0.35f, 1.1f, 6, 35, new Tuple<int, int>(0, 5), 7, new Tuple<int, int>(0, 6));
        public static MilitaryUnit UNIT_BATTLE_ELEPHANT = new MilitaryUnit(1132, "Battle Elephant", Age.CASTLE_AGE, new Resources(0, 120, 70, 0), 28000, 2000, 0, 0.85f, 4, 250, null, 12, new Tuple<int, int>(1, 2));
        public static MilitaryUnit UNIT_ELITE_BATTLE_ELEPHANT = new MilitaryUnit(1134, "Elite Battle Elephant", Age.IMPERIAL_AGE, new Resources(0, 120, 70, 0), 28000, 2000, 0, 0.85f, 5, 300, null, 16, new Tuple<int, int>(1, 3));
        public static GaiaUnit UNIT_TIGER = new GaiaUnit(1137, "Tiger", new Resources(0, 0, 0, 0), 0, 2000, 0, 1.05f, 12, 25, null, 3, new Tuple<int, int>(0, 0));
        //public static GaiaUnit UNIT_RHINOCEROS = new GaiaUnit(1139, "Rhinoceros");
        //public static GaiaUnit UNIT_WATER_BUFFALO = new GaiaUnit(1142, "Water Buffalo");
        public static MilitaryUnit UNIT_IMPERIAL_SKIRMISHER = new MilitaryUnit(1155, "Imperial Skirmisher", Age.IMPERIAL_AGE, new Resources(35, 25, 0, 0), 22000, 3000, 0.1f, 0.96f, 7, 35, new Tuple<int, int>(1, 5), 4, new Tuple<int, int>(0, 4));
        public static CivilUnit UNIT_FARMER_M_2 = new CivilUnit(1192, "Farmer", Age.DARK_AGE, new Resources(0, 50, 0, 0), 25000, 10, 2000, 0, 0.8f, 4, 25, null, 3, new Tuple<int, int>(0, 0));


        // BUILDINGS AND STRUCTURES //
        public static MilitaryStructure STRUCTURE_ARCHERY_RANGE_1 = new MilitaryStructure(10, "Archery Range", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_BARRACK_1 = new MilitaryStructure(12, "Barracks", Age.DARK_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_ARCHERY_RANGE_2 = new MilitaryStructure(14, "Archery Range", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_BLACKSMITH_1 = new MilitaryStructure(18, "Blacksmith", Age.FEUDAL_AGE, new Resources(150, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_BLACKSMITH_2 = new MilitaryStructure(19, "Blacksmith", Age.FEUDAL_AGE, new Resources(150, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_BARRACK_2 = new MilitaryStructure(20, "Barracks", Age.DARK_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_MONASTERY_1 = new MilitaryStructure(30, "Monastery", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_MONASTERY_2 = new MilitaryStructure(31, "Monastery", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_MONASTERY_3 = new MilitaryStructure(32, "Monastery", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_DOCK_1 = new MilitaryStructure(45, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_DOCK_2 = new MilitaryStructure(47, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_SIEGE_WORKSHOP_1 = new MilitaryStructure(49, "Siege Workshop", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 4, 2100, new Tuple<int, int>(2, 9));
        public static ResourceStructure STRUCTURE_FARM = new ResourceStructure(50, "Farm", Age.DARK_AGE, new Resources(60, 0, 0, 0), 15000, 0, 480, new Tuple<int, int>(0, 0));
        public static MilitaryStructure STRUCTURE_DOCK_3 = new MilitaryStructure(51, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static DefenseStructure STRUCTURE_GATE_1 = new DefenseStructure(63, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_2 = new DefenseStructure(64, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_3 = new DefenseStructure(67, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static CivilStructure STRUCTURE_MILL_1 = new CivilStructure(68, "Mill", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_HOUSE_1 = new CivilStructure(70, "House", Age.DARK_AGE, new Resources(30, 0, 0, 0), 25000, 1, 900, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_TOWN_CENTER_1 = new CivilStructure(71, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static DefenseStructure STRUCTURE_PALISADE_WALL = new DefenseStructure(72, "Palisade Wall", Age.DARK_AGE, new Resources(2, 0, 0, 0), 6000, 2, 250, new Tuple<int, int>(2, 5));
        public static DefenseStructure STRUCTURE_GATE_4 = new DefenseStructure(78, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_WATCH_TOWER_1 = new DefenseStructure(79, "Watch Tower", Age.FEUDAL_AGE, new Resources(25, 0, 0, 125), 140000, 10, 1020, new Tuple<int, int>(1, 7));
        public static DefenseStructure STRUCTURE_GATE_5 = new DefenseStructure(80, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_6 = new DefenseStructure(81, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static MilitaryStructure STRUCTURE_CASTLE = new MilitaryStructure(82, "Castle", Age.CASTLE_AGE, new Resources(0, 0, 0, 650), 260000, 11, 4800, new Tuple<int, int>(8, 11));
        public static CivilStructure STRUCTURE_MARKET_1 = new CivilStructure(84, "Market", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 60000, 4, 2100, new Tuple<int, int>(2, 9));
        public static DefenseStructure STRUCTURE_GATE_7 = new DefenseStructure(85, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static MilitaryStructure STRUCTURE_STABLE_1 = new MilitaryStructure(86, "Stable", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_ARCHERY_RANGE_3 = new MilitaryStructure(87, "Archery Range", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static DefenseStructure STRUCTURE_GATE_8 = new DefenseStructure(88, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_9 = new DefenseStructure(90, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_10 = new DefenseStructure(91, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_11 = new DefenseStructure(92, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_12 = new DefenseStructure(95, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static MilitaryStructure STRUCTURE_BLACKSMITH_3 = new MilitaryStructure(103, "Blacksmith", Age.FEUDAL_AGE, new Resources(150, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_MONASTERY_4 = new MilitaryStructure(104, "Monastery", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_BLACKSMITH_4 = new MilitaryStructure(105, "Blacksmith", Age.FEUDAL_AGE, new Resources(150, 0, 0, 0), 40000, 5, 2100, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_TOWN_CENTER_2 = new CivilStructure(109, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_MARKET_2 = new CivilStructure(116, "Market", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 60000, 4, 2100, new Tuple<int, int>(2, 9));
        public static DefenseStructure STRUCTURE_STONE_WALL = new DefenseStructure(117, "Stone Wall", Age.FEUDAL_AGE, new Resources(0, 0, 0, 5), 10000, 2, 900, new Tuple<int, int>(8, 10));
        public static CivilStructure STRUCTURE_MILL_2 = new CivilStructure(129, "Mill", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MILL_3 = new CivilStructure(130, "Mill", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MILL_4 = new CivilStructure(131, "Mill", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_BARRACK_3 = new MilitaryStructure(132, "Barracks", Age.DARK_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static MilitaryStructure STRUCTURE_DOCK_4 = new MilitaryStructure(133, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MARKET_3 = new CivilStructure(137, "Market", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 60000, 4, 2100, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_TOWN_CENTER_3 = new CivilStructure(141, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_4 = new CivilStructure(142, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static MilitaryStructure STRUCTURE_SIEGE_WORKSHOP_2 = new MilitaryStructure(150, "Siege Workshop", Age.CASTLE_AGE, new Resources(175, 0, 0, 0), 40000, 4, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_STABLE_2 = new MilitaryStructure(153, "Stable", Age.FEUDAL_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static DefenseStructure STRUCTURE_FORTIFIED_WALL = new DefenseStructure(155, "Fortified Wall", Age.CASTLE_AGE, new Resources(0, 0, 0, 5), 10000, 2, 3000, new Tuple<int, int>(12, 12));
        public static ResourceStructure STRUCTURE_FISH_TRAP = new ResourceStructure(199, "Fish Trap", Age.DARK_AGE, new Resources(100, 0, 0, 0), 40000, 1, 50, new Tuple<int, int>(0, 0));
        public static MilitaryStructure STRUCTURE_UNIVERSITY_1 = new MilitaryStructure(209, "University", Age.CASTLE_AGE, new Resources(200, 0, 0, 0), 60000, 4, 2100, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_UNIVERSITY_2 = new MilitaryStructure(210, "University", Age.CASTLE_AGE, new Resources(200, 0, 0, 0), 60000, 4, 2100, new Tuple<int, int>(2, 9));
        public static DefenseStructure STRUCTURE_GUARD_TOWER = new DefenseStructure(234, "Guard Tower", Age.CASTLE_AGE, new Resources(25, 0, 0, 125), 140000, 10, 1500, new Tuple<int, int>(2, 8));
        public static DefenseStructure STRUCTURE_KEEP = new DefenseStructure(235, "Keep", Age.IMPERIAL_AGE, new Resources(25, 0, 0, 125), 140000, 10, 2250, new Tuple<int, int>(3, 9));
        public static CivilStructure STRUCTURE_HOUSE_2 = new CivilStructure(463, "House", Age.DARK_AGE, new Resources(30, 0, 0, 0), 25000, 1, 900, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_HOUSE_3 = new CivilStructure(464, "House", Age.DARK_AGE, new Resources(30, 0, 0, 0), 25000, 1, 900, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_HOUSE_4 = new CivilStructure(465, "House", Age.DARK_AGE, new Resources(30, 0, 0, 0), 25000, 1, 900, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_TOWN_CENTER_5 = new CivilStructure(481, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_6 = new CivilStructure(482, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_7 = new CivilStructure(483, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_8 = new CivilStructure(484, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static DefenseStructure STRUCTURE_GATE_13 = new DefenseStructure(487, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_14 = new DefenseStructure(488, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_15 = new DefenseStructure(490, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_16 = new DefenseStructure(491, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static MilitaryStructure STRUCTURE_BARRACK_4 = new MilitaryStructure(498, "Barracks", Age.DARK_AGE, new Resources(175, 0, 0, 0), 50000, 5, 2100, new Tuple<int, int>(3, 10));
        public static CivilStructure STRUCTURE_LUMBER_CAMP_1 = new CivilStructure(562, "Lumber Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_LUMBER_CAMP_2 = new CivilStructure(563, "Lumber Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_LUMBER_CAMP_3 = new CivilStructure(564, "Lumber Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_LUMBER_CAMP_4 = new CivilStructure(565, "Lumber Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static DefenseStructure STRUCTURE_WATCH_TOWER_2 = new DefenseStructure(566, "Watch Tower", Age.FEUDAL_AGE, new Resources(25, 0, 0, 125), 140000, 10, 1020, new Tuple<int, int>(1, 7));
        public static CivilStructure STRUCTURE_MINING_CAMP_1 = new CivilStructure(584, "Mining Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MINING_CAMP_2 = new CivilStructure(585, "Mining Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MINING_CAMP_3 = new CivilStructure(586, "Mining Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_MINING_CAMP_4 = new CivilStructure(587, "Mining Camp", Age.DARK_AGE, new Resources(100, 0, 0, 0), 35000, 5, 1000, new Tuple<int, int>(2, 9));
        public static CivilStructure STRUCTURE_TOWN_CENTER_9 = new CivilStructure(597, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static DefenseStructure STRUCTURE_OUTPOST = new DefenseStructure(598, "Outpost", Age.DARK_AGE, new Resources(25, 0, 0, 5), 15000, 6, 500, new Tuple<int, int>(0, 0));
        public static CivilStructure STRUCTURE_TOWN_CENTER_10 = new CivilStructure(611, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_11 = new CivilStructure(612, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_12 = new CivilStructure(613, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_13 = new CivilStructure(614, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_14 = new CivilStructure(615, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_15 = new CivilStructure(616, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_16 = new CivilStructure(617, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_17 = new CivilStructure(618, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_18 = new CivilStructure(619, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_19 = new CivilStructure(620, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static CivilStructure STRUCTURE_TOWN_CENTER_20 = new CivilStructure(621, "Town Center", Age.CASTLE_AGE, new Resources(275, 0, 0, 100), 150000, 7, 2400, new Tuple<int, int>(5, 7));
        public static DefenseStructure STRUCTURE_GATE_17 = new DefenseStructure(659, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_18 = new DefenseStructure(660, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_19 = new DefenseStructure(661, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_20 = new DefenseStructure(662, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_21 = new DefenseStructure(663, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_22 = new DefenseStructure(664, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_23 = new DefenseStructure(665, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_24 = new DefenseStructure(666, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_25 = new DefenseStructure(667, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_26 = new DefenseStructure(668, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_27 = new DefenseStructure(669, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_28 = new DefenseStructure(670, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_29 = new DefenseStructure(671, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_30 = new DefenseStructure(672, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_31 = new DefenseStructure(673, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_GATE_32 = new DefenseStructure(674, "Gate", Age.FEUDAL_AGE, new Resources(0, 0, 0, 30), 70000, 6, 1375, new Tuple<int, int>(6, 6));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_1 = new DefenseStructure(789, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_2 = new DefenseStructure(790, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_3 = new DefenseStructure(791, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_4 = new DefenseStructure(792, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_5 = new DefenseStructure(793, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_6 = new DefenseStructure(794, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_7 = new DefenseStructure(795, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_8 = new DefenseStructure(796, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_9 = new DefenseStructure(797, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_10 = new DefenseStructure(798, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_11 = new DefenseStructure(799, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_12 = new DefenseStructure(800, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_13 = new DefenseStructure(801, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_14 = new DefenseStructure(802, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_15 = new DefenseStructure(803, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static DefenseStructure STRUCTURE_PALISADE_GATE_16 = new DefenseStructure(804, "Palisade Gate", Age.DARK_AGE, new Resources(20, 0, 0, 0), 30000, 6, 400, new Tuple<int, int>(2, 2));
        public static MilitaryStructure STRUCTURE_DOCK_5 = new MilitaryStructure(805, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_DOCK_6 = new MilitaryStructure(806, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_DOCK_7 = new MilitaryStructure(807, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_DOCK_8 = new MilitaryStructure(808, "Dock", Age.DARK_AGE, new Resources(150, 0, 0, 0), 35000, 5, 1800, new Tuple<int, int>(2, 9));
        public static MilitaryStructure STRUCTURE_HARBOR = new MilitaryStructure(1189, "Harbor", Age.IMPERIAL_AGE, new Resources(150, 0, 0, 0), 35000, 20, 2000, new Tuple<int, int>(3, 10));

        public static readonly Dictionary<int, CivilStructure> CIVIL_STRUCTURES = new Dictionary<int, CivilStructure>()
        {
		    { 68, STRUCTURE_MILL_1 },
		    { 70, STRUCTURE_HOUSE_1 },
		    { 71, STRUCTURE_TOWN_CENTER_1 },
		    { 84, STRUCTURE_MARKET_1 },
		    { 109, STRUCTURE_TOWN_CENTER_2 },
		    { 116, STRUCTURE_MARKET_2 },
		    { 129, STRUCTURE_MILL_2 },
		    { 130, STRUCTURE_MILL_3 },
		    { 131, STRUCTURE_MILL_4 },
		    { 137, STRUCTURE_MARKET_3 },
		    { 141, STRUCTURE_TOWN_CENTER_3 },
		    { 142, STRUCTURE_TOWN_CENTER_4 },
		    { 463, STRUCTURE_HOUSE_2 },
		    { 464, STRUCTURE_HOUSE_3 },
		    { 465, STRUCTURE_HOUSE_4 },
		    { 481, STRUCTURE_TOWN_CENTER_5 },
		    { 482, STRUCTURE_TOWN_CENTER_6 },
		    { 483, STRUCTURE_TOWN_CENTER_7 },
		    { 484, STRUCTURE_TOWN_CENTER_8 },
		    { 562, STRUCTURE_LUMBER_CAMP_1 },
		    { 563, STRUCTURE_LUMBER_CAMP_2 },
		    { 564, STRUCTURE_LUMBER_CAMP_3 },
		    { 565, STRUCTURE_LUMBER_CAMP_4 },
		    { 584, STRUCTURE_MINING_CAMP_1 },
		    { 585, STRUCTURE_MINING_CAMP_2 },
		    { 586, STRUCTURE_MINING_CAMP_3 },
		    { 587, STRUCTURE_MINING_CAMP_4 },
		    { 597, STRUCTURE_TOWN_CENTER_9 },
		    { 611, STRUCTURE_TOWN_CENTER_10 },
		    { 612, STRUCTURE_TOWN_CENTER_11 },
		    { 613, STRUCTURE_TOWN_CENTER_12 },
		    { 614, STRUCTURE_TOWN_CENTER_13 },
		    { 615, STRUCTURE_TOWN_CENTER_14 },
		    { 616, STRUCTURE_TOWN_CENTER_15 },
		    { 617, STRUCTURE_TOWN_CENTER_16 },
		    { 618, STRUCTURE_TOWN_CENTER_17 },
		    { 619, STRUCTURE_TOWN_CENTER_18 },
		    { 620, STRUCTURE_TOWN_CENTER_19 },
		    { 621, STRUCTURE_TOWN_CENTER_20 },
        };

        public static readonly Dictionary<int, CivilUnit> CIVIL_UNITS = new Dictionary<int, CivilUnit>()
		{
			{ 13, UNIT_FISHING_SHIP },
			{ 17, UNIT_TRADE_COG },
			{ 56, UNIT_FISHERMAN_M },
			{ 57, UNIT_FISHERMAN_F },
			{ 83, UNIT_VILLAGER_M },
			{ 118, UNIT_BUILDER_M },
			{ 120, UNIT_FORAGER_M },
			{ 122, UNIT_HUNTER_M },
			{ 123, UNIT_LUMBERJACK_M },
			{ 124, UNIT_STONE_MINER_M },
			{ 128, UNIT_TRADE_CART_EMPTY },
			{ 156, UNIT_REPAIRER_M },
			{ 204, UNIT_TRADE_CART_FULL },
			{ 212, UNIT_BUILDER_F },
			{ 214, UNIT_FARMER_F },
			{ 216, UNIT_HUNTER_F },
			{ 218, UNIT_LUMBERJACK_F },
			{ 220, UNIT_STONE_MINER_F },
			{ 222, UNIT_REPAIRER_F },
			{ 259, UNIT_FARMER_M },
			{ 293, UNIT_VILLAGER_F },
			{ 354, UNIT_FORAGER_F },
			{ 434, UNIT_KING },
			{ 545, UNIT_TRANSPORT_SHIP },
			{ 579, UNIT_GOLD_MINER_M },
			{ 581, UNIT_GOLD_MINER_F },
			{ 590, UNIT_SHEPHERD_F },
			{ 592, UNIT_SHEPHERD_M },
			{ 1192, UNIT_FARMER_M_2 },
		};

        public static readonly Dictionary<int, DefenseStructure> DEFENSE_STRUCTURES = new Dictionary<int, DefenseStructure>()
		{
			{ 63, STRUCTURE_GATE_1 },
			{ 64, STRUCTURE_GATE_2 },
			{ 67, STRUCTURE_GATE_3 },
			{ 72, STRUCTURE_PALISADE_WALL },
			{ 78, STRUCTURE_GATE_4 },
			{ 79, STRUCTURE_WATCH_TOWER_1 },
			{ 80, STRUCTURE_GATE_5 },
			{ 81, STRUCTURE_GATE_6 },
			{ 85, STRUCTURE_GATE_7 },
			{ 88, STRUCTURE_GATE_8 },
			{ 90, STRUCTURE_GATE_9 },
			{ 91, STRUCTURE_GATE_10 },
			{ 92, STRUCTURE_GATE_11 },
			{ 95, STRUCTURE_GATE_12 },
			{ 117, STRUCTURE_STONE_WALL },
			{ 155, STRUCTURE_FORTIFIED_WALL },
			{ 234, STRUCTURE_GUARD_TOWER },
			{ 235, STRUCTURE_KEEP },
			{ 487, STRUCTURE_GATE_13 },
			{ 488, STRUCTURE_GATE_14 },
			{ 490, STRUCTURE_GATE_15 },
			{ 491, STRUCTURE_GATE_16 },
			{ 566, STRUCTURE_WATCH_TOWER_2 },
			{ 598, STRUCTURE_OUTPOST },
			{ 659, STRUCTURE_GATE_17 },
			{ 660, STRUCTURE_GATE_18 },
			{ 661, STRUCTURE_GATE_19 },
			{ 662, STRUCTURE_GATE_20 },
			{ 663, STRUCTURE_GATE_21 },
			{ 664, STRUCTURE_GATE_22 },
			{ 665, STRUCTURE_GATE_23 },
			{ 666, STRUCTURE_GATE_24 },
			{ 667, STRUCTURE_GATE_25 },
			{ 668, STRUCTURE_GATE_26 },
			{ 669, STRUCTURE_GATE_27 },
			{ 670, STRUCTURE_GATE_28 },
			{ 671, STRUCTURE_GATE_29 },
			{ 672, STRUCTURE_GATE_30 },
			{ 673, STRUCTURE_GATE_31 },
			{ 674, STRUCTURE_GATE_32 },
			{ 789, STRUCTURE_PALISADE_GATE_1 },
			{ 790, STRUCTURE_PALISADE_GATE_2 },
			{ 791, STRUCTURE_PALISADE_GATE_3 },
			{ 792, STRUCTURE_PALISADE_GATE_4 },
			{ 793, STRUCTURE_PALISADE_GATE_5 },
			{ 794, STRUCTURE_PALISADE_GATE_6 },
			{ 795, STRUCTURE_PALISADE_GATE_7 },
			{ 796, STRUCTURE_PALISADE_GATE_8 },
			{ 797, STRUCTURE_PALISADE_GATE_9 },
			{ 798, STRUCTURE_PALISADE_GATE_10 },
			{ 799, STRUCTURE_PALISADE_GATE_11 },
			{ 800, STRUCTURE_PALISADE_GATE_12 },
			{ 801, STRUCTURE_PALISADE_GATE_13 },
			{ 802, STRUCTURE_PALISADE_GATE_14 },
			{ 803, STRUCTURE_PALISADE_GATE_15 },
			{ 804, STRUCTURE_PALISADE_GATE_16 },
		};

        public static readonly Dictionary<int, GaiaUnit> GAIA_UNITS = new Dictionary<int, GaiaUnit>()
        {
			{ 48, UNIT_WILD_BOAR },
			{ 126, UNIT_WOLF },
			{ 305, UNIT_LLAMA },
			{ 333, UNIT_DEER },
			{ 594, UNIT_SHEEP },
			{ 812, UNIT_JAGUAR },
			{ 833, UNIT_TURKEY },
			{ 835, UNIT_WILD_HORSE },
			{ 884, UNIT_WILD_CAMEL },
			{ 897, UNIT_CAMEL_GAIA },
			{ 936, UNIT_ELEPHANT },
			{ 1019, UNIT_ZEBRA },
			{ 1026, UNIT_OSTRICH },
			{ 1029, UNIT_LION },
			{ 1031, UNIT_CROCODILE },
			{ 1060, UNIT_GOAT },
			{ 1137, UNIT_TIGER },
		};

        public static readonly Dictionary<int, MilitaryStructure> MILITARY_STRUCTURE = new Dictionary<int, MilitaryStructure>()
        {
			{ 10, STRUCTURE_ARCHERY_RANGE_1 },
			{ 12, STRUCTURE_BARRACK_1 },
			{ 14, STRUCTURE_ARCHERY_RANGE_2 },
			{ 18, STRUCTURE_BLACKSMITH_1 },
			{ 19, STRUCTURE_BLACKSMITH_2 },
			{ 20, STRUCTURE_BARRACK_2 },
			{ 30, STRUCTURE_MONASTERY_1 },
			{ 31, STRUCTURE_MONASTERY_2 },
			{ 32, STRUCTURE_MONASTERY_3 },
			{ 45, STRUCTURE_DOCK_1 },
			{ 47, STRUCTURE_DOCK_2 },
			{ 49, STRUCTURE_SIEGE_WORKSHOP_1 },
			{ 51, STRUCTURE_DOCK_3 },
			{ 82, STRUCTURE_CASTLE },
			{ 86, STRUCTURE_STABLE_1 },
			{ 87, STRUCTURE_ARCHERY_RANGE_3 },
			{ 103, STRUCTURE_BLACKSMITH_3 },
			{ 104, STRUCTURE_MONASTERY_4 },
			{ 105, STRUCTURE_BLACKSMITH_4 },
			{ 132, STRUCTURE_BARRACK_3 },
			{ 133, STRUCTURE_DOCK_4 },
			{ 150, STRUCTURE_SIEGE_WORKSHOP_2 },
			{ 153, STRUCTURE_STABLE_2 },
			{ 209, STRUCTURE_UNIVERSITY_1 },
			{ 210, STRUCTURE_UNIVERSITY_2 },
			{ 498, STRUCTURE_BARRACK_4 },
			{ 805, STRUCTURE_DOCK_5 },
			{ 806, STRUCTURE_DOCK_6 },
			{ 807, STRUCTURE_DOCK_7 },
			{ 808, STRUCTURE_DOCK_8 },
			{ 1189, STRUCTURE_HARBOR },
		};

        public static readonly Dictionary<int, MilitaryUnit> MILITARY_UNIT = new Dictionary<int, MilitaryUnit>()
        {
			{ 4, UNIT_ARCHER },
			{ 5, UNIT_HAND_CANNONEER },
			{ 6, UNIT_ELITE_SKIRMISHER },
			{ 7, UNIT_SKIRMISHER },
			{ 8, UNIT_LONGBOWMAN },
			{ 11, UNIT_MANGUDAI },
			{ 21, UNIT_WAR_GALLEY },
			{ 24, UNIT_CROSSBOWMAN },
			{ 25, UNIT_TEUTONIC_KNIGHT },
			{ 35, UNIT_BATTERING_RAM },
			{ 36, UNIT_BOMBARD_CANNON },
			{ 38, UNIT_KNIGHT },
			{ 39, UNIT_CAVALRY_ARCHER },
			{ 40, UNIT_CATAPHRACT },
			{ 41, UNIT_HUSKARL },
			{ 331, UNIT_TREBUCHET_UNPACKED },
			{ 46, UNIT_JANISSARY },
			{ 73, UNIT_CHU_KO_NU },
			{ 74, UNIT_MILITIA },
			{ 75, UNIT_MAN_AT_ARMS },
			{ 77, UNIT_LONG_SWORDSMAN },
			{ 93, UNIT_SPEARMAN },
			{ 183, UNIT_CONDOTTIERO },
			{ 185, UNIT_SLINGER },
			{ 207, UNIT_IMPERIAL_CAMEL },
			{ 232, UNIT_WOAD_RAIDER },
			{ 233, UNIT_LONGBOAT },
			{ 239, UNIT_WAR_ELEPHANT },
			{ 279, UNIT_SCORPION },
			{ 280, UNIT_MANGONEL },
			{ 281, UNIT_THROWING_AXEMAN },
			{ 282, UNIT_MAMELUKE },
			{ 283, UNIT_CAVALIER },
			{ 291, UNIT_SAMURAI },
			{ 329, UNIT_CAMEL },
			{ 330, UNIT_HEAVY_CAMEL },
			{ 331, UNIT_TREBUCHET_PACKED },
			{ 358, UNIT_PIKEMAN },
			{ 359, UNIT_HALBERDIER },
			{ 420, UNIT_CANNON_GALLEON },
			{ 422, UNIT_CAPPED_RAM },
			{ 440, UNIT_PETARD },
			{ 441, UNIT_HUSSAR },
			{ 442, UNIT_GALLEON },
			{ 448, UNIT_SCOUT_CAVALRY },
			{ 473, UNIT_TWO_HANDED_SWORDSMAN },
			{ 474, UNIT_HEAVY_CAVALRY_ARCHER },
			{ 492, UNIT_ARBALEST },
			{ 527, UNIT_DEMOLITION_SHIP },
			{ 528, UNIT_HEAVY_DEMOLITION_SHIP },
			{ 529, UNIT_FIRE_SHIP },
			{ 530, UNIT_ELITE_LONGBOWMAN },
			{ 531, UNIT_ELITE_THROWING_AXEMAN },
			{ 532, UNIT_FAST_FIRE_SHIP },
			{ 533, UNIT_ELITE_LONGBOAT },
			{ 534, UNIT_ELITE_WOAD_RAIDER },
			{ 539, UNIT_GALLEY },
			{ 542, UNIT_HEAVY_SCORPION },
			{ 546, UNIT_LIGHT_CAVALRY },
			{ 548, UNIT_SIEGE_RAM },
			{ 550, UNIT_ONAGER },
			{ 553, UNIT_ELITE_CATAPHRACT },
			{ 554, UNIT_ELITE_TEUTONIC_KNIGHT },
			{ 555, UNIT_ELITE_HUSKARL },
			{ 556, UNIT_ELITE_MAMELUKE },
			{ 567, UNIT_ELITE_JANISSARY },
			{ 568, UNIT_ELITE_WAR_ELEPHANT },
			{ 559, UNIT_ELITE_CHU_KO_NU },
			{ 560, UNIT_ELITE_SAMURAI },
			{ 561, UNIT_ELITE_MANGUDAI },
			{ 567, UNIT_CHAMPION },
			{ 569, UNIT_PALADIN },
			{ 583, UNIT_GENITOUR },
			{ 588, UNIT_SIEGE_ONAGER },
			{ 596, UNIT_ELITE_GENITOUR },
			{ 691, UNIT_ELITE_CANNON_GALLEON },
			{ 692, UNIT_BERSERK },
			{ 694, UNIT_ELITE_BERSERK },
			{ 725, UNIT_JAGUAR_WARRIOR },
			{ 726, UNIT_ELITE_JAGUAR_WARRIOR },
			{ 751, UNIT_EAGLE_SCOUT },
			{ 752, UNIT_ELITE_EAGLE_WARRIOR },
			{ 753, UNIT_EAGLE_WARRIOR },
			{ 755, UNIT_TARKAN },
			{ 757, UNIT_ELITE_TARKAN },
			{ 759, UNIT_HUSKARL_2 },
			{ 761, UNIT_ELITE_HUSKARL_2 },
			{ 763, UNIT_PLUMED_ARCHER },
			{ 765, UNIT_ELITE_PLUMED_ARCHER },
			{ 771, UNIT_CONQUISTADOR },
			{ 773, UNIT_ELITE_CONQUISTADOR },
			{ 827, UNIT_WAR_WAGON },
			{ 829, UNIT_ELITE_WAR_WAGON },
			{ 831, UNIT_TURTLE_SHIP },
			{ 832, UNIT_ELITE_TURTLE_SHIP },
			{ 866, UNIT_GENOESE_CROSSBOWMAN },
			{ 868, UNIT_ELITE_GENOESE_CROSSBOWMAN },
			{ 869, UNIT_MAGYAR_HUSZAR },
			{ 871, UNIT_ELITE_MAGYAR_HUSZAR },
			{ 873, UNIT_ELEPHANT_ARCHER },
			{ 875, UNIT_ELITE_ELEPHANT_ARCHER },
			{ 876, UNIT_BOYAR },
			{ 878, UNIT_ELITE_BOYAR },
			{ 879, UNIT_KAMAYUK },
			{ 881, UNIT_ELITE_KAMAYUK },
			{ 882, UNIT_CONDOTTIERO_2 },
			{ 885, UNIT_SIEGE_TOWER },
			{ 886, UNIT_TARKAN_2 },
			{ 887, UNIT_ELITE_TARKAN_2 },
			{ 1001, UNIT_ORGAN_GUN },
			{ 1003, UNIT_ELITE_ORGAN_GUN },
			{ 1004, UNIT_CARAVEL },
			{ 1006, UNIT_ELITE_CARAVEL },
			{ 1007, UNIT_CAMEL_ARCHER },
			{ 1009, UNIT_ELITE_CAMEL_ARCHER },
			{ 1010, UNIT_GENITOUR_2 },
			{ 1012, UNIT_ELITE_GENITOUR_2 },
			{ 1013, UNIT_GBETO },
			{ 1015, UNIT_ELITE_GBETO },
			{ 1016, UNIT_SHOTEL_WARRIOR },
			{ 1018, UNIT_ELITE_SHOTEL_WARRIOR },
			{ 1103, UNIT_FIRE_GALLEY },
			{ 1104, UNIT_DEMOLITION_RAFT },
			{ 1105, UNIT_SIEGE_TOWER_2 },
			{ 1120, UNIT_BALLISTA_ELEPHANT },
			{ 1122, UNIT_ELITE_BALLISTA_ELEPHANT },
			{ 1123, UNIT_KARAMBIT_WARRIOR },
			{ 1125, UNIT_ELITE_KARAMBIT_WARRIOR },
			{ 1126, UNIT_ARAMBAI },
			{ 1128, UNIT_ELITE_ARAMBAI },
			{ 1129, UNIT_RATTAN_ARCHER },
			{ 1131, UNIT_ELITE_RATTAN_ARCHER },
			{ 1132, UNIT_BATTLE_ELEPHANT },
			{ 1134, UNIT_ELITE_BATTLE_ELEPHANT },
			{ 1155, UNIT_IMPERIAL_SKIRMISHER },
		};

        public static readonly Dictionary<int, MonkUnit> MONK_UNITS = new Dictionary<int, MonkUnit>()
        {
			{ 125, UNIT_MONK },
			{ 286, UNIT_MONK_WITH_RELIC },
			{ 775, UNIT_MISSIONARY },
		};

        public static readonly Dictionary<int, ResourceStructure> RESOURCE_STRUCTURE = new Dictionary<int, ResourceStructure>()
        {
            { 50, STRUCTURE_FARM },
            { 199, STRUCTURE_FISH_TRAP },
        };

        public static readonly List<CivilUnit> VILLAGER = new List<CivilUnit>(){

            UNIT_VILLAGER_M, UNIT_VILLAGER_F, UNIT_FARMER_M, UNIT_FARMER_M_2, UNIT_FARMER_F,
            UNIT_HUNTER_M, UNIT_HUNTER_F, UNIT_FORAGER_M, UNIT_FORAGER_F, UNIT_LUMBERJACK_M,
            UNIT_LUMBERJACK_F, UNIT_GOLD_MINER_M, UNIT_GOLD_MINER_F, UNIT_STONE_MINER_M, UNIT_STONE_MINER_F,
            UNIT_FISHERMAN_M, UNIT_FISHERMAN_F,UNIT_SHEPHERD_M, UNIT_SHEPHERD_F

        };

        public static readonly List<MilitaryUnit> SWORDSMAN = new List<MilitaryUnit>(){

            UNIT_MILITIA, UNIT_MAN_AT_ARMS, UNIT_LONG_SWORDSMAN, UNIT_TWO_HANDED_SWORDSMAN, UNIT_CHAMPION

        };

        public static readonly List<MilitaryUnit> SPEARMAN = new List<MilitaryUnit>(){

            UNIT_SPEARMAN, UNIT_PIKEMAN, UNIT_HALBERDIER

        };

        public static readonly List<MilitaryUnit> EAGLE = new List<MilitaryUnit>(){

            UNIT_EAGLE_SCOUT, UNIT_EAGLE_WARRIOR, UNIT_ELITE_EAGLE_WARRIOR

        };

        public static readonly List<MilitaryUnit> ARCHERS = new List<MilitaryUnit>(){

            UNIT_ARCHER, UNIT_CROSSBOWMAN, UNIT_ARBALEST

        };

        public static readonly List<MilitaryUnit> SKIRMISHER = new List<MilitaryUnit>(){

            UNIT_SKIRMISHER, UNIT_ELITE_SKIRMISHER, UNIT_IMPERIAL_SKIRMISHER

        };

        public static readonly List<MilitaryUnit> CAVALRY_ARCHER = new List<MilitaryUnit>(){

            UNIT_CAVALRY_ARCHER, UNIT_HEAVY_CAVALRY_ARCHER

        };

        public static readonly List<MilitaryUnit> GENITOUR = new List<MilitaryUnit>(){

            UNIT_GENITOUR, UNIT_GENITOUR, UNIT_ELITE_GENITOUR, UNIT_ELITE_GENITOUR_2

        };

        public static readonly List<MilitaryUnit> LIGHT_CAVALRY = new List<MilitaryUnit>(){

            UNIT_SCOUT_CAVALRY, UNIT_LIGHT_CAVALRY, UNIT_HUSSAR

        };

        public static readonly List<MilitaryUnit> HEAVY_CAVALRY = new List<MilitaryUnit>(){

            UNIT_KNIGHT, UNIT_CAVALIER, UNIT_PALADIN

        };

        public static readonly List<MilitaryUnit> CAMEL = new List<MilitaryUnit>(){

            UNIT_CAMEL, UNIT_HEAVY_CAMEL, UNIT_IMPERIAL_CAMEL

        };

        public static readonly List<MilitaryUnit> BATTLE_ELEPHANT = new List<MilitaryUnit>(){

            UNIT_BATTLE_ELEPHANT, UNIT_ELITE_BATTLE_ELEPHANT

        };

        public static readonly List<MilitaryUnit> RAM = new List<MilitaryUnit>(){

            UNIT_BATTERING_RAM, UNIT_CAPPED_RAM, UNIT_SIEGE_RAM

        };

        public static readonly List<MilitaryUnit> MANGONEL = new List<MilitaryUnit>(){

            UNIT_MANGONEL, UNIT_ONAGER, UNIT_SIEGE_ONAGER

        };

        public static readonly List<MilitaryUnit> SCORPION = new List<MilitaryUnit>(){

            UNIT_SCORPION, UNIT_HEAVY_SCORPION

        };

        public static readonly List<MilitaryUnit> GALLEY = new List<MilitaryUnit>(){

            UNIT_GALLEY, UNIT_WAR_GALLEY, UNIT_GALLEON

        };

        public static readonly List<MilitaryUnit> FIRE_GALLEY = new List<MilitaryUnit>(){

            UNIT_FIRE_GALLEY, UNIT_FIRE_SHIP, UNIT_FAST_FIRE_SHIP

        };

        public static readonly List<MilitaryUnit> DEMOLITION_SHIP = new List<MilitaryUnit>(){

            UNIT_DEMOLITION_RAFT, UNIT_DEMOLITION_SHIP, UNIT_HEAVY_DEMOLITION_SHIP

        };

        public static readonly List<MilitaryUnit> CANNON_GALLEON = new List<MilitaryUnit>(){

            UNIT_CANNON_GALLEON, UNIT_ELITE_CANNON_GALLEON

        };

        public static readonly List<MilitaryUnit> UNIQUE_UNIT = new List<MilitaryUnit>(){

            UNIT_JAGUAR_WARRIOR, UNIT_CAMEL_ARCHER, UNIT_LONGBOWMAN, UNIT_ARAMBAI, UNIT_CATAPHRACT,
            UNIT_WOAD_RAIDER, UNIT_ELITE_CHU_KO_NU, UNIT_SHOTEL_WARRIOR, UNIT_THROWING_AXEMAN, UNIT_HUSKARL,
            UNIT_HUSKARL_2, UNIT_TARKAN, UNIT_TARKAN_2, UNIT_KAMAYUK, UNIT_ELEPHANT_ARCHER,
            UNIT_GENOESE_CROSSBOWMAN, UNIT_SAMURAI, UNIT_BALLISTA_ELEPHANT, UNIT_WAR_WAGON, UNIT_MAGYAR_HUSZAR,
            UNIT_KARAMBIT_WARRIOR, UNIT_GBETO, UNIT_PLUMED_ARCHER, UNIT_MANGUDAI, UNIT_WAR_ELEPHANT,
            UNIT_ORGAN_GUN, UNIT_MAMELUKE, UNIT_BOYAR, UNIT_CONQUISTADOR, UNIT_TEUTONIC_KNIGHT,
            UNIT_JANISSARY, UNIT_RATTAN_ARCHER, UNIT_BERSERK

        };

		public static readonly List<MilitaryUnit> ELITE_UNIQUE_UNIT = new List<MilitaryUnit>(){

			UNIT_ELITE_JAGUAR_WARRIOR, UNIT_ELITE_CAMEL_ARCHER, UNIT_ELITE_LONGBOWMAN, UNIT_ELITE_ARAMBAI, UNIT_ELITE_CATAPHRACT,
			UNIT_ELITE_WOAD_RAIDER, UNIT_ELITE_CHU_KO_NU, UNIT_ELITE_SHOTEL_WARRIOR, UNIT_ELITE_THROWING_AXEMAN, UNIT_ELITE_HUSKARL,
			UNIT_ELITE_HUSKARL_2, UNIT_ELITE_TARKAN, UNIT_ELITE_TARKAN_2, UNIT_ELITE_KAMAYUK, UNIT_ELITE_ELEPHANT_ARCHER,
			UNIT_ELITE_GENOESE_CROSSBOWMAN, UNIT_ELITE_SAMURAI, UNIT_ELITE_BALLISTA_ELEPHANT, UNIT_ELITE_WAR_WAGON, UNIT_ELITE_MAGYAR_HUSZAR,
			UNIT_ELITE_KARAMBIT_WARRIOR, UNIT_ELITE_GBETO, UNIT_ELITE_PLUMED_ARCHER, UNIT_ELITE_MANGUDAI, UNIT_ELITE_WAR_ELEPHANT,
			UNIT_ELITE_ORGAN_GUN, UNIT_ELITE_MAMELUKE, UNIT_ELITE_BOYAR, UNIT_ELITE_CONQUISTADOR, UNIT_ELITE_TEUTONIC_KNIGHT,
			UNIT_ELITE_JANISSARY, UNIT_ELITE_RATTAN_ARCHER, UNIT_ELITE_BERSERK

		};

        public static readonly List<MilitaryUnit> TREBUCHET = new List<MilitaryUnit>(){

            UNIT_TREBUCHET_PACKED, UNIT_TREBUCHET_UNPACKED

        };

        public static readonly List<DefenseStructure> WALL = new List<DefenseStructure>(){

			STRUCTURE_GATE_1, STRUCTURE_GATE_2, STRUCTURE_GATE_3, STRUCTURE_GATE_4, STRUCTURE_GATE_5,
			STRUCTURE_GATE_7, STRUCTURE_GATE_8, STRUCTURE_GATE_9, STRUCTURE_GATE_10, STRUCTURE_GATE_11,
			STRUCTURE_GATE_12, STRUCTURE_GATE_13, STRUCTURE_GATE_14, STRUCTURE_GATE_15, STRUCTURE_GATE_16,
			STRUCTURE_GATE_17, STRUCTURE_GATE_18, STRUCTURE_GATE_19, STRUCTURE_GATE_20, STRUCTURE_GATE_21,
			STRUCTURE_GATE_22, STRUCTURE_GATE_23, STRUCTURE_GATE_24, STRUCTURE_GATE_25, STRUCTURE_GATE_26,
			STRUCTURE_GATE_27, STRUCTURE_GATE_28, STRUCTURE_GATE_29, STRUCTURE_GATE_30, STRUCTURE_GATE_31,
			STRUCTURE_GATE_32, STRUCTURE_STONE_WALL, STRUCTURE_PALISADE_WALL, STRUCTURE_PALISADE_GATE_1, STRUCTURE_PALISADE_GATE_2,
			STRUCTURE_PALISADE_GATE_3, STRUCTURE_PALISADE_GATE_4, STRUCTURE_PALISADE_GATE_5, STRUCTURE_PALISADE_GATE_6, STRUCTURE_PALISADE_GATE_7,
			STRUCTURE_PALISADE_GATE_8, STRUCTURE_PALISADE_GATE_9, STRUCTURE_PALISADE_GATE_10, STRUCTURE_PALISADE_GATE_11, STRUCTURE_PALISADE_GATE_12,
			STRUCTURE_PALISADE_GATE_13, STRUCTURE_PALISADE_GATE_14, STRUCTURE_PALISADE_GATE_15, STRUCTURE_PALISADE_GATE_16

        };

        public static readonly List<DefenseStructure> TOWER = new List<DefenseStructure>(){

            STRUCTURE_WATCH_TOWER_1, STRUCTURE_WATCH_TOWER_2, STRUCTURE_GUARD_TOWER, STRUCTURE_KEEP

        };

        public static readonly List<CivilStructure> TOWN_CENTER = new List<CivilStructure>() {

            STRUCTURE_TOWN_CENTER_1, STRUCTURE_TOWN_CENTER_2, STRUCTURE_TOWN_CENTER_3, STRUCTURE_TOWN_CENTER_4, STRUCTURE_TOWN_CENTER_5,
            STRUCTURE_TOWN_CENTER_6, STRUCTURE_TOWN_CENTER_7, STRUCTURE_TOWN_CENTER_8, STRUCTURE_TOWN_CENTER_9, STRUCTURE_TOWN_CENTER_10,
            STRUCTURE_TOWN_CENTER_11, STRUCTURE_TOWN_CENTER_12, STRUCTURE_TOWN_CENTER_13, STRUCTURE_TOWN_CENTER_14, STRUCTURE_TOWN_CENTER_15,
            STRUCTURE_TOWN_CENTER_16, STRUCTURE_TOWN_CENTER_17, STRUCTURE_TOWN_CENTER_18, STRUCTURE_TOWN_CENTER_19, STRUCTURE_TOWN_CENTER_20

        };

        public static readonly List<MilitaryStructure> BARRACK = new List<MilitaryStructure>(){

            STRUCTURE_BARRACK_1, STRUCTURE_BARRACK_2, STRUCTURE_BARRACK_3, STRUCTURE_BARRACK_4

        };

        public static readonly List<MilitaryStructure> ARCHERY_RANGE = new List<MilitaryStructure>() {

            STRUCTURE_ARCHERY_RANGE_1, STRUCTURE_ARCHERY_RANGE_2, STRUCTURE_ARCHERY_RANGE_3
        
        };

        public static readonly List<MilitaryStructure> STABLE = new List<MilitaryStructure>() {

            STRUCTURE_STABLE_1, STRUCTURE_STABLE_2

        };

        public static readonly List<MilitaryStructure> DOCK = new List<MilitaryStructure>(){

            STRUCTURE_DOCK_1, STRUCTURE_DOCK_2, STRUCTURE_DOCK_3, STRUCTURE_DOCK_4, STRUCTURE_DOCK_5,
            STRUCTURE_DOCK_6, STRUCTURE_DOCK_7, STRUCTURE_DOCK_8

        };

        public static readonly List<MilitaryStructure> SIEGE_WORKSHOP = new List<MilitaryStructure>(){

            STRUCTURE_SIEGE_WORKSHOP_1, STRUCTURE_SIEGE_WORKSHOP_2

        };

        public static readonly List<MilitaryStructure> MONASTERY = new List<MilitaryStructure>(){

            STRUCTURE_MONASTERY_1, STRUCTURE_MONASTERY_2, STRUCTURE_MONASTERY_3, STRUCTURE_MONASTERY_4

        };

        public static readonly List<MilitaryStructure> BLACKSMITH = new List<MilitaryStructure>(){

            STRUCTURE_BLACKSMITH_1, STRUCTURE_BLACKSMITH_2, STRUCTURE_BLACKSMITH_3, STRUCTURE_BLACKSMITH_4

        };

        public static readonly List<MilitaryStructure> UNIVERSITY = new List<MilitaryStructure>(){

            STRUCTURE_UNIVERSITY_1, STRUCTURE_UNIVERSITY_2

        };

        public static readonly List<CivilStructure> LUMBER_CAMP = new List<CivilStructure>(){

            STRUCTURE_LUMBER_CAMP_1, STRUCTURE_LUMBER_CAMP_2, STRUCTURE_LUMBER_CAMP_3, STRUCTURE_LUMBER_CAMP_4

        };

        public static readonly List<CivilStructure> MINING_CAMP = new List<CivilStructure>(){

            STRUCTURE_MINING_CAMP_1, STRUCTURE_MINING_CAMP_2, STRUCTURE_MINING_CAMP_3, STRUCTURE_MINING_CAMP_4

        };

        public static readonly List<CivilStructure> MILL = new List<CivilStructure>(){

            STRUCTURE_MILL_1, STRUCTURE_MILL_2, STRUCTURE_MILL_3, STRUCTURE_MILL_4

        };

        public static readonly List<CivilStructure> HOUSE = new List<CivilStructure>(){

            STRUCTURE_HOUSE_1, STRUCTURE_HOUSE_2, STRUCTURE_HOUSE_3, STRUCTURE_HOUSE_4

        };

        public static readonly List<CivilStructure> MARKET = new List<CivilStructure>(){

            STRUCTURE_MARKET_1, STRUCTURE_MARKET_2, STRUCTURE_MARKET_3

        };

        public static readonly List<ResourceStructure> RESOURCE_STRUCTURES = new List<ResourceStructure>(){

            STRUCTURE_FARM, STRUCTURE_FISH_TRAP

        };

		// Unit IDs that we might draw on maps
		// GAIA (needed for colours when drawing)
		//public const int GOLDMINE = 66;
		//public const int STONEMINE = 102;
		//public const int CLIFF1 = 264;
		//public const int CLIFF2 = 265;
		//public const int CLIFF3 = 266;
		//public const int CLIFF4 = 267;
		//public const int CLIFF5 = 268;
		//public const int CLIFF6 = 269;
		//public const int CLIFF7 = 270;
		//public const int CLIFF8 = 271;
		//public const int CLIFF9 = 272;
		//public const int CLIFF10 = 273;
		//public const int RELIC = 285;
		//public const int TURKEY = 833;
		//public const int SHEEP = 594;
		//public const int DEER = 65;
		//public const int BOAR = 48;
		//public const int JAVELINA = 822;
		//public const int FORAGEBUSH = 59;
		//// Gates (needed for directions when drawing)
		//public const int GATE = 487;
		//public const int GATE2 = 490;
		//public const int GATE3 = 665;
		//public const int GATE4 = 673;
		//public const int PALISADE_GATE = 792;
		//public const int PALISADE_GATE2 = 796;
		//public const int PALISADE_GATE3 = 800;
		//public const int PALISADE_GATE4 = 804;

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


		// ----------
		// MILITARY STRUCTURE BOOLEAN FUNCTION
        // ----------

		public static bool isBarrack(int id)
		{
			return BARRACK.Any(c => c.id == id);
		}

		public static bool isArcheryRange(int id)
		{
			return ARCHERY_RANGE.Any(c => c.id == id);
		}

		public static bool isStable(int id)
		{
			return STABLE.Any(c => c.id == id);
		}

        public static bool isDock(int id)
        {
            return DOCK.Any(c => c.id == id);
        }

		public static bool isSiegeWorkshop(int id)
		{
			return SIEGE_WORKSHOP.Any(c => c.id == id);
		}

		public static bool isMonastery(int id)
		{
			return MONASTERY.Any(c => c.id == id);
		}

        public static bool isBlacksmith(int id)
        {
            return BLACKSMITH.Any(c => c.id == id);
        }

        public static bool isUniversity(int id)
        {
            return UNIVERSITY.Any(c => c.id == id);
        }

        public static bool isCastle(int id)
        {
            return id == STRUCTURE_CASTLE.id;
        }

		public static bool isMilitaryStructure(int id)
		{
			return isBarrack(id) || isArcheryRange(id) || isStable(id) || isDock(id) || isSiegeWorkshop(id) || isMonastery(id) || isBlacksmith(id) || isUniversity(id) || (id == STRUCTURE_CASTLE.id);
		}


        // ----------
        // DEFENSE STRUCTURE BOOLEAN FUNCTION
        // ----------

        public static bool isTower(int id)
        {
            return TOWER.Any(c => c.id == id);
        }

		public static bool isWall(int id)
		{
			return WALL.Any(c => c.id == id);
		}

        public static bool isDefenseStructure(int id)
        {
            return isWall(id) || isTower(id);
        }

        // ----------
        // CIVIL STRUCTURE BOOLEAN FUNCTION
        // ----------

        public static bool isLumberCamp(int id)
        {
            return LUMBER_CAMP.Any(c => c.id == id);
        }

		public static bool isMiningCamp(int id)
		{
			return MINING_CAMP.Any(c => c.id == id);
		}

        public static bool isMill(int id)
        {
            return MILL.Any(c => c.id == id);
        }

        public static bool isHouse(int id)
        {
            return HOUSE.Any(c => c.id == id);
        }

        public static bool isMarket(int id)
        {
            return MARKET.Any(c => c.id == id);
        }

        public static bool isTownCenter(int id)
        {
            return TOWN_CENTER.Any(c => c.id == id);
        }

        public static bool isCivilStructure(int id)
        {
            return isLumberCamp(id) || isMiningCamp(id) || isMill(id) || isHouse(id) || isTownCenter(id);   
        }

        // ----------
        // RESOURCE STRUCTURE BOOLEAN FUNCTION
        // ----------

        public static bool isFarm(int id)
        {
            return id == STRUCTURE_FARM.id;
        }

        public static bool isFishTrap(int id)
        {
            return id == STRUCTURE_FISH_TRAP.id;
        }

        public static bool isResourceStructure(int id)
        {
            return isFarm(id) || isFishTrap(id);
        }

        // ----------
        // UNIT BOOLEAN FUNCTION
        // ----------

        public static bool isVillager(int id)
        {
            return VILLAGER.Any(c => c.id == id);
        }

        public static bool isSwordsman(int id)
        {
            return SWORDSMAN.Any(c => c.id == id);
        }

        public static bool isSpearman(int id)
        {
            return SPEARMAN.Any(c => c.id == id);
        }

        public static bool isEagle(int id)
        {
            return EAGLE.Any(c => c.id == id);
        }

        public static bool isCondottiero(int id)
        {
            return id == UNIT_CONDOTTIERO.id || id == UNIT_CONDOTTIERO_2.id;
        }

        public static bool isBarrackUnit(int id)
        {
            return isSwordsman(id) || isSpearman(id) || isEagle(id) || isCondottiero(id);
        }

        public static bool isArcher(int id)
        {
            return ARCHERS.Any(c => c.id == id);
        }

        public static bool isSkirmisher(int id)
        {
            return SKIRMISHER.Any(c => c.id == id);
        }

        public static bool isCavalryArcher(int id)
        {
            return CAVALRY_ARCHER.Any(c => c.id == id);
        }

        public static bool isGenitour(int id)
        {
            return GENITOUR.Any(c => c.id == id);
        }

        public static bool isArcheryRangeUnit(int id)
        {
            return isArcher(id) || isSkirmisher(id) || isCavalryArcher(id) || isGenitour(id) || id == UNIT_SLINGER.id || id == UNIT_HAND_CANNONEER.id;
        }

        public static bool isLightCavalry(int id)
        {
            return LIGHT_CAVALRY.Any(c => c.id == id);
        }

        public static bool isHeavyCavalry(int id)
        {
            return HEAVY_CAVALRY.Any(c => c.id == id);
        }

        public static bool isCamel(int id)
        {
            return CAMEL.Any(c => c.id == id);
        }

        public static bool isBattleElephant(int id)
        {
            return BATTLE_ELEPHANT.Any(c => c.id == id);
        }

        public static bool isStableUnit(int id)
        {
            return isLightCavalry(id) || isHeavyCavalry(id) || isCamel(id) || isBattleElephant(id);
        }

        public static bool isRam(int id)
        {
            return RAM.Any(c => c.id == id);
        }

        public static bool isMangonel(int id)
        {
            return MANGONEL.Any(c => c.id == id);
        }

        public static bool isScorpion(int id)
        {
            return SCORPION.Any(c => c.id == id);
        }

        public static bool isSiegeTower(int id)
        {
            return id == UNIT_SIEGE_TOWER.id || id == UNIT_SIEGE_TOWER_2.id;
        }

        public static bool isBombardCannon(int id)
        {
            return id == UNIT_BOMBARD_CANNON.id;
        }

        public static bool isSiegeWorkshopUnit(int id)
        {
            return isRam(id) || isMangonel(id) || isScorpion(id) || isSiegeTower(id) || isBombardCannon(id);
        }

        public static bool isGalley(int id)
        {
            return GALLEY.Any(c => c.id == id);
        }

        public static bool isFireGalley(int id)
        {
            return FIRE_GALLEY.Any(c => c.id == id);
        }

        public static bool isDemolitionShip(int id)
        {
            return DEMOLITION_SHIP.Any(c => c.id == id);
        }

        public static bool isCannonGalleon(int id)
        {
            return CANNON_GALLEON.Any(c => c.id == id);
        }

        public static bool isDockUnit(int id)
        {
            return isGalley(id) || isFireGalley(id) || isDemolitionShip(id) || isCannonGalleon(id) || id == UNIT_LONGBOAT.id || id == UNIT_ELITE_LONGBOAT.id || id == UNIT_TURTLE_SHIP.id || id == UNIT_ELITE_TURTLE_SHIP.id || id == UNIT_CARAVEL.id || id == UNIT_ELITE_CARAVEL.id || id == UNIT_FISHING_SHIP.id || id == UNIT_TRANSPORT_SHIP.id; 
        }

        public static bool isTrebuchet(int id)
        {
            return TREBUCHET.Any(c => c.id == id);
        }

        public static bool isUniqueUnit(int id)
        {
            return UNIQUE_UNIT.Any(c => c.id == id);
        }

        public static bool isEliteUniqueUnit(int id)
        {
            return ELITE_UNIQUE_UNIT.Any(c => c.id == id);
        }

        public static bool isCastleUnit(int id)
        {
            return isUniqueUnit(id) || isEliteUniqueUnit(id) || isTrebuchet(id) || id == UNIT_PETARD.id;
        }

        // ----------
        // SPECIAL BOOLEAN FUNCTION
        // ----------

        public static bool isGatheringPoint(int id)
        {
            return isLumberCamp(id) || isMiningCamp(id) || isMill(id) || isDock(id) || isTownCenter(id);
        }

        public static bool isProductionStructure(int id)
        {
            return isTownCenter(id) || isMarket(id) || isCastle(id) || isBarrack(id) || isArcheryRange(id) || isStable(id) || isSiegeWorkshop(id) || isDock(id) || isMonastery(id);
        }

        public static bool isSiegeUnit(int id)
        {
            return isSiegeWorkshopUnit(id) || isTrebuchet(id);
        }

        //
        //
        //

        public static List<Unit> getAllUnit()
        {
            List<Unit> list = new List<Unit>();
			list.Add(UNIT_ARCHER);
			list.Add(UNIT_HAND_CANNONEER);
			list.Add(UNIT_ELITE_SKIRMISHER);
			list.Add(UNIT_SKIRMISHER);
			list.Add(UNIT_LONGBOWMAN);
			list.Add(UNIT_MANGUDAI);
			list.Add(UNIT_FISHING_SHIP);
			list.Add(UNIT_TRADE_COG);
			list.Add(UNIT_WAR_GALLEY);
			list.Add(UNIT_CROSSBOWMAN);
			list.Add(UNIT_TEUTONIC_KNIGHT);
			list.Add(UNIT_BATTERING_RAM);
			list.Add(UNIT_BOMBARD_CANNON);
			list.Add(UNIT_KNIGHT);
			list.Add(UNIT_CAVALRY_ARCHER);
			list.Add(UNIT_CATAPHRACT);
			list.Add(UNIT_HUSKARL);
			list.Add(UNIT_TREBUCHET_UNPACKED);
			list.Add(UNIT_JANISSARY);
			list.Add(UNIT_WILD_BOAR);
			list.Add(UNIT_FISHERMAN_M);
			list.Add(UNIT_FISHERMAN_F);
			list.Add(UNIT_CHU_KO_NU);
			list.Add(UNIT_MILITIA);
			list.Add(UNIT_MAN_AT_ARMS);
			list.Add(UNIT_LONG_SWORDSMAN);
			list.Add(UNIT_VILLAGER_M);
			list.Add(UNIT_SPEARMAN);
			list.Add(UNIT_BUILDER_M);
			list.Add(UNIT_FORAGER_M);
			list.Add(UNIT_HUNTER_M);
			list.Add(UNIT_LUMBERJACK_M);
			list.Add(UNIT_STONE_MINER_M);
			list.Add(UNIT_MONK);
			list.Add(UNIT_WOLF);
			list.Add(UNIT_TRADE_CART_EMPTY);
			list.Add(UNIT_REPAIRER_M);
			list.Add(UNIT_CONDOTTIERO);
			list.Add(UNIT_SLINGER);
			list.Add(UNIT_TRADE_CART_FULL);
			list.Add(UNIT_IMPERIAL_CAMEL);
			list.Add(UNIT_BUILDER_F);
			list.Add(UNIT_FARMER_F);
			list.Add(UNIT_HUNTER_F);
			list.Add(UNIT_LUMBERJACK_F);
			list.Add(UNIT_STONE_MINER_F);
			list.Add(UNIT_REPAIRER_F);
			list.Add(UNIT_WOAD_RAIDER);
			list.Add(UNIT_LONGBOAT);
			list.Add(UNIT_WAR_ELEPHANT);
			list.Add(UNIT_FARMER_M);
			list.Add(UNIT_SCORPION);
			list.Add(UNIT_MANGONEL);
			list.Add(UNIT_THROWING_AXEMAN);
			list.Add(UNIT_MAMELUKE);
			list.Add(UNIT_CAVALIER);
			list.Add(UNIT_MONK_WITH_RELIC);
			list.Add(UNIT_SAMURAI);
			list.Add(UNIT_VILLAGER_F);
			list.Add(UNIT_LLAMA);
			list.Add(UNIT_CAMEL);
			list.Add(UNIT_HEAVY_CAMEL);
			list.Add(UNIT_TREBUCHET_PACKED);
			list.Add(UNIT_DEER);
			list.Add(UNIT_FORAGER_F);
			list.Add(UNIT_PIKEMAN);
			list.Add(UNIT_HALBERDIER);
			list.Add(UNIT_CANNON_GALLEON);
			list.Add(UNIT_CAPPED_RAM);
			list.Add(UNIT_KING);
			list.Add(UNIT_PETARD);
			list.Add(UNIT_HUSSAR);
			list.Add(UNIT_GALLEON);
			list.Add(UNIT_SCOUT_CAVALRY);
			list.Add(UNIT_TWO_HANDED_SWORDSMAN);
			list.Add(UNIT_HEAVY_CAVALRY_ARCHER);
			list.Add(UNIT_ARBALEST);
			list.Add(UNIT_DEMOLITION_SHIP);
			list.Add(UNIT_HEAVY_DEMOLITION_SHIP);
			list.Add(UNIT_FIRE_SHIP);
			list.Add(UNIT_ELITE_LONGBOWMAN);
			list.Add(UNIT_ELITE_THROWING_AXEMAN);
			list.Add(UNIT_FAST_FIRE_SHIP);
			list.Add(UNIT_ELITE_LONGBOAT);
			list.Add(UNIT_ELITE_WOAD_RAIDER);
			list.Add(UNIT_GALLEY);
			list.Add(UNIT_HEAVY_SCORPION);
			list.Add(UNIT_TRANSPORT_SHIP);
			list.Add(UNIT_LIGHT_CAVALRY);
			list.Add(UNIT_SIEGE_RAM);
			list.Add(UNIT_ONAGER);
			list.Add(UNIT_ELITE_CATAPHRACT);
			list.Add(UNIT_ELITE_TEUTONIC_KNIGHT);
			list.Add(UNIT_ELITE_HUSKARL);
			list.Add(UNIT_ELITE_MAMELUKE);
			list.Add(UNIT_ELITE_JANISSARY);
			list.Add(UNIT_ELITE_WAR_ELEPHANT);
			list.Add(UNIT_ELITE_CHU_KO_NU);
			list.Add(UNIT_ELITE_SAMURAI);
			list.Add(UNIT_ELITE_MANGUDAI);
			list.Add(UNIT_CHAMPION);
			list.Add(UNIT_PALADIN);
			list.Add(UNIT_GOLD_MINER_M);
			list.Add(UNIT_GOLD_MINER_F);
			list.Add(UNIT_GENITOUR);
			list.Add(UNIT_SIEGE_ONAGER);
			list.Add(UNIT_SHEPHERD_F);
			list.Add(UNIT_SHEPHERD_M);
			list.Add(UNIT_SHEEP);
			list.Add(UNIT_ELITE_GENITOUR);
			list.Add(UNIT_ELITE_CANNON_GALLEON);
			list.Add(UNIT_BERSERK);
			list.Add(UNIT_ELITE_BERSERK);
			list.Add(UNIT_JAGUAR_WARRIOR);
			list.Add(UNIT_ELITE_JAGUAR_WARRIOR);
			list.Add(UNIT_EAGLE_SCOUT);
			list.Add(UNIT_ELITE_EAGLE_WARRIOR);
			list.Add(UNIT_EAGLE_WARRIOR);
			list.Add(UNIT_TARKAN);
			list.Add(UNIT_ELITE_TARKAN);
			list.Add(UNIT_HUSKARL_2);
			list.Add(UNIT_ELITE_HUSKARL_2);
			list.Add(UNIT_PLUMED_ARCHER);
			list.Add(UNIT_ELITE_PLUMED_ARCHER);
			list.Add(UNIT_CONQUISTADOR);
			list.Add(UNIT_ELITE_CONQUISTADOR);
			list.Add(UNIT_MISSIONARY);
			list.Add(UNIT_JAGUAR);
			list.Add(UNIT_WAR_WAGON);
			list.Add(UNIT_ELITE_WAR_WAGON);
			list.Add(UNIT_TURTLE_SHIP);
			list.Add(UNIT_ELITE_TURTLE_SHIP);
			list.Add(UNIT_TURKEY);
			list.Add(UNIT_WILD_HORSE);
			list.Add(UNIT_GENOESE_CROSSBOWMAN);
			list.Add(UNIT_ELITE_GENOESE_CROSSBOWMAN);
			list.Add(UNIT_MAGYAR_HUSZAR);
			list.Add(UNIT_ELITE_MAGYAR_HUSZAR);
			list.Add(UNIT_ELEPHANT_ARCHER);
			list.Add(UNIT_ELITE_ELEPHANT_ARCHER);
			list.Add(UNIT_BOYAR);
			list.Add(UNIT_ELITE_BOYAR);
			list.Add(UNIT_KAMAYUK);
			list.Add(UNIT_ELITE_KAMAYUK);
			list.Add(UNIT_CONDOTTIERO_2);
			list.Add(UNIT_WILD_CAMEL);
			list.Add(UNIT_SIEGE_TOWER);
			list.Add(UNIT_TARKAN_2);
			list.Add(UNIT_ELITE_TARKAN_2);
			list.Add(UNIT_CAMEL_GAIA);
			list.Add(UNIT_ELEPHANT);
			list.Add(UNIT_ORGAN_GUN);
			list.Add(UNIT_ELITE_ORGAN_GUN);
			list.Add(UNIT_CARAVEL);
			list.Add(UNIT_ELITE_CARAVEL);
			list.Add(UNIT_CAMEL_ARCHER);
			list.Add(UNIT_ELITE_CAMEL_ARCHER);
			list.Add(UNIT_GENITOUR_2);
			list.Add(UNIT_ELITE_GENITOUR_2);
			list.Add(UNIT_GBETO);
			list.Add(UNIT_ELITE_GBETO);
			list.Add(UNIT_SHOTEL_WARRIOR);
			list.Add(UNIT_ELITE_SHOTEL_WARRIOR);
			list.Add(UNIT_ZEBRA);
			list.Add(UNIT_OSTRICH);
			list.Add(UNIT_LION);
			list.Add(UNIT_CROCODILE);
			list.Add(UNIT_GOAT);
			list.Add(UNIT_FIRE_GALLEY);
			list.Add(UNIT_DEMOLITION_RAFT);
			list.Add(UNIT_SIEGE_TOWER_2);
			list.Add(UNIT_BALLISTA_ELEPHANT);
			list.Add(UNIT_ELITE_BALLISTA_ELEPHANT);
			list.Add(UNIT_KARAMBIT_WARRIOR);
			list.Add(UNIT_ELITE_KARAMBIT_WARRIOR);
			list.Add(UNIT_ARAMBAI);
			list.Add(UNIT_ELITE_ARAMBAI);
			list.Add(UNIT_RATTAN_ARCHER);
			list.Add(UNIT_ELITE_RATTAN_ARCHER);
			list.Add(UNIT_BATTLE_ELEPHANT);
			list.Add(UNIT_ELITE_BATTLE_ELEPHANT);
			list.Add(UNIT_TIGER);
			list.Add(UNIT_IMPERIAL_SKIRMISHER);
			list.Add(UNIT_FARMER_M_2);

            return list;
        }
	}
}
