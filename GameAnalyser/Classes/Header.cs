using System;
using System.Collections.Generic;
using System.Text;

namespace GameAnalyser
{
	public class Header
	{

		public Header()
		{
			gameSetting = new GameSetting();
			players = new Dictionary<int, Player>();
			teams = new List<Team>();
			victorySetting = new VictorySetting();
			map = new Map();
			map.id = -1;
			pregameChat = new List<ChatMessage>();
		}

		private int version;

		public void setVersion(int value)
		{
			version = value;
		}

		private double subVersion;

		public void setSubVersion(double value)
		{
			subVersion = value;
		}

		public int getSubVersion()
		{
			return version;
		}

		GameSetting gameSetting;
		VictorySetting victorySetting;
		public int triggerInfoPos;
		public int gameSettingsPos;

		public List<ChatMessage> pregameChat;

		public Dictionary<int, Player> players;
		public List<Team> teams;

		public int scenarioHeaderPos;
		private Map map;

		public void setCheats(int aegis, int cheats)
		{
			gameSetting.setCheats(aegis, cheats);
		}

		public void setGameMode(int gameMode)
		{
			gameSetting.setGameMode(gameMode);
			victorySetting.setGameMode(gameMode);
		}

		public void setGameSpeed(int gameSpeed)
		{
			gameSetting.setGameSpeed(gameSpeed);
		}

		public void setGameType(int gameType)
		{
			gameSetting.setGameType(gameType);
		}

		public void setTimeLimit(int timeLimit)
		{
			victorySetting.setTimeLimit(timeLimit);
		}

		public void setRelicVictory(int relicCount)
		{
			victorySetting.setRelicVictory(relicCount);
		}

		public void setExplorartionVictory(int explorationPercent)
		{
			victorySetting.setExplorationVictory(explorationPercent);
		}

		public void setCustomVictory(int customVictory)
		{
			victorySetting.setCustomVictory(customVictory);
		}

		public void setConquestVictory(int conquestVictory)
		{
			victorySetting.setConquestVictory();
		}

		public void setScoreLimit(int score)
		{
			victorySetting.setScoreLimit(score);
		}

		public void setPopLimit(int popLimit)
		{
			gameSetting.setPopLimit(popLimit);
		}

		public void setMapId(int mapId)
		{
			map.id = mapId;
		}

		public void setMapVisibility(int mapVisibility)
		{
			gameSetting.setMapVisibility(mapVisibility);
			map.setMapVisibility(mapVisibility);
		}

		public void setMapSize(int mapSize)
		{
			gameSetting.setMapSize(mapSize);
			map.setMapSize(mapSize);
		}

		public void setMapXSize(int xSize)
		{
			map.xSize = xSize;
		}

		public void setMapYSize(int ySize)
		{
			map.ySize = ySize;
		}

		public void setMapTiles()
		{
			if (map.xSize > 10000 || map.ySize > 10000 || map.xSize <= 0 || map.ySize <= 0)
			{
				throw new Exception("Invalid Map Size.");
			}

			//map.tiles = new Tile[map.xSize, map.ySize];
		}

		public void setMapTile(int x, int y, int terrain, int elevation)
		{
			map.setTile(x, y, terrain, elevation);
		}

}
}
