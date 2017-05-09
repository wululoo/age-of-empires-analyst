using System;
namespace GameAnalyser
{
	public class GameSetting
	{
		public GameSetting()
		{
		}

		public int gameType;

		public int gameMode;

		public int difficultyLevel;

		public int gameSpeed;

		public int mapVisibility;

		public int mapSize;

		public int mapId;

		public int popLimit;

		public int treatyLength;

		public int resourceLevel;

		public int startingAge;

		public int endingAge;

		public bool lockDiplomacy;

		public bool lockSpeed = true;

		public bool allowCheat;

		public bool aegisEnabled;

		public bool allTech;

		public bool teamTogether;

		public GameSetting(int diff, int speed, int reveal, int type, int size, int mapid, int pop, bool diplo)
		{
			difficultyLevel = diff;
			gameSpeed = speed;
			mapVisibility = reveal;
			gameType = type;
			mapSize = size;
			mapId = mapid;
			popLimit = pop;
			lockDiplomacy = diplo;
		}

		public void setAllTech(bool allTech)
		{
			this.allTech = allTech;
		}

		public void setCheats(int aegis, int cheats)
		{
			aegisEnabled = aegis != 0;
			allowCheat = (aegis + cheats) != 0;
		}

		public void setPopLimit(int popLimit)
		{
			this.popLimit = popLimit;
		}

		public void setGameSpeed(int gameSpeed)
		{
			this.gameSpeed = gameSpeed;
		}

		public void setGameType(int gameType)
		{
			this.gameType = gameType;
		}

		public void setGameMode(int gameMode)
		{
			this.gameMode = gameMode;
		}

		public void setDifficultyLevel(int difficulty)
		{
			this.difficultyLevel = difficulty;
		}

		public void setLockDiplomacy(bool lockDiplo)
		{
			this.lockDiplomacy = lockDiplo;
		}

		public void setMapVisibility(int mapVisibility)
		{
			this.mapVisibility = mapVisibility;
		}

		public int getMapVisibility()
		{
			return mapVisibility;
		}

		public void setMapSize(int mapSize)
		{
			this.mapSize = mapSize;
		}

		public void setResourceLevel(int level)
		{
			resourceLevel = level;
		}

		public void setTeamTogether(bool teamTogether)
		{
			this.teamTogether = teamTogether;
		}

		public void setTreatyLength(int length)
		{
			this.treatyLength = length;
		}

		public void setStartingAge(int age)
		{
			this.startingAge = age;
		}

		public void setEndingAge(int age)
		{
			this.endingAge = age;
		}

		public int getPopLimit()
		{
			return popLimit;
		}

		public bool getLockDiplomacy()
		{
			return lockDiplomacy;
		}

	}
}
