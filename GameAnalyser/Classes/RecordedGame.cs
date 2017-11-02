using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GameAnalyser
{
	public class RecordedGame
	{
		public string id;

		public string filename;

		public string fileFormat;

		public int version;

		public double subVersion;

		public string lobbyName;

        public bool isRanked;

		public Map map;

		public Dictionary<int, Player> players;

		public List<Player> spectators;

		public List<Team> teams;

        public List<GameUnit> units;

		public GameSetting gameSetting;

		public VictorySetting victorySetting;

		public List<ChatMessage> chatMessages;

		public List<ChatMessage> preGameChat;

		public List<int> winners;

		public RecordedGame()
		{
			players = new Dictionary<int, Player>();

			gameSetting = new GameSetting();
			victorySetting = new VictorySetting();
			map = new Map();
			teams = new List<Team>();
			chatMessages = new List<ChatMessage>();
			winners = new List<int>();
			spectators = new List<Player>();
            units = new List<GameUnit>();

			id = Guid.NewGuid().ToString();
		}

		public RecordedGame(string filename)
		{
			this.filename = filename;

			//fileContent = File.ReadAllBytes(filename);

			fileFormat = Path.GetExtension(filename);

			//stream = new StreamExtractor(fileContent);

			players = new Dictionary<int, Player>();
			spectators = new List<Player>();

			gameSetting = new GameSetting();
			victorySetting = new VictorySetting();
			map = new Map();
			teams = new List<Team>();
			chatMessages = new List<ChatMessage>();
			winners = new List<int>();
			units = new List<GameUnit>();
		}

		public void addWinner(int i)
		{
			winners.Add(i);
		}

		public void setAllTech(bool allTech)
		{
			gameSetting.setAllTech(allTech);
		}

		public void setLobbyName(string name)
		{
			lobbyName = name;
		}

		public void setCheats(int aegis, int cheats)
		{
			gameSetting.setCheats(aegis, cheats);
		}

		public void setGameMode(int gameMode)
		{
			gameSetting.setGameMode(gameMode);
		}

		public void setGameSpeed(int gameSpeed)
		{
			gameSetting.setGameSpeed(gameSpeed);
		}

		public void setGameType(int gameType)
		{
			switch (gameType)
			{
				case GameType.TYPE_CAPTURETHERELIC:
					victorySetting.setRelicVictory(1);
					this.setVictory(GameType.VICTORY_STANDARD);
					break;
					
				case GameType.TYPE_DEFENSEOFTHEWONDER:
					this.setVictory(GameType.VICTORY_STANDARD);
					break;
					
				case GameType.TYPE_WONDERRACE:
					this.setVictory(GameType.VICTORY_STANDARD);
					break;
					
				case GameType.TYPE_REGICIDE:
					this.setVictory(GameType.VICTORY_CONQUEST);
					break;

				default:
					break;
			}

			gameSetting.setGameType(gameType);
		}

		public void setTimeLimit(int timeLimit)
		{
			victorySetting.setTimeLimit(timeLimit);
		}

		public void setTeamTogether(bool teamTogether)
		{
			gameSetting.setTeamTogether(teamTogether);
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

		public void setConquestVictory()
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

		public void setMapFileName(string name)
		{
			map.setMapFileName(name);
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

			map.setMapTiles();
		}

		public void setMapTile(int x, int y, int terrain, int elevation)
		{
			map.setTile(x, y, terrain, elevation);
		}

		public void setDifficultyLevel(int difficulty)
		{
			gameSetting.setDifficultyLevel(difficulty);
		}

		public void setEndingAge(int age)
		{
			gameSetting.setEndingAge(age);
		}

		public void setLockDiplomacy(bool lockDiplo)
		{
			gameSetting.setLockDiplomacy(lockDiplo);
		}

		public void setTreatyLength(int length)
		{
			gameSetting.setTreatyLength(length);
		}

		public void setVictory(int victory, int victoryCondition = 0)
		{
			switch (victory)
			{
				case GameType.VICTORY_STANDARD:
					break;
				case GameType.VICTORY_CONQUEST:
					this.setConquestVictory();
					break;
				case GameType.VICTORY_TIMELIMIT:
					this.setTimeLimit(victoryCondition);
					break;
				case GameType.VICTORY_SCORELIMIT:
					this.setScoreLimit(victoryCondition);
					break;
				case GameType.VICTORY_CUSTOM:
				case GameType.VICTORY_LASTMANSTANDING:
					
					break;
				default:
					throw new Exception("Unrecognised Victory Setting.");
			}
		}

		public void setRelicCount(int relicCount)
		{
			
		}

		public void setResourceLevel(int level)
		{
			gameSetting.setResourceLevel(level);
		}

		public void setStartingAge(int age)
		{
			gameSetting.setStartingAge(age);
		}

		public void setVersion(int value)
		{
			version = value;
		}

		public void setSubVersion(double value)
		{
			subVersion = value;
		}

		public int getVersion()
		{
			return version;
		}

		public double getSubVersion()
		{
			return subVersion;
		}

		//public byte[] getHeaderByteArray()
		//{
		//	return stream.getHeaderByteArray();
		//}

		//public byte[] getBodyByteArray()
		//{
		//	return stream.getBodyByteArray();
		//}

		//public string getHeaderContent()
		//{
		//	return stream.getHeaderContent();
		//}

		//public string getBodyContent()
		//{
		//	return stream.getBodyContent();
		//}

		//public List<byte> getHeaderByteList()
		//{
		//	return stream.getHeaderByteList();
		//}

		//public List<byte> getBodyByteList()
		//{
		//	return stream.getBodyByteList();
		//}

		public string getFileExtension()
		{
			return fileFormat;
		}

		public string getFileName()
		{
			return filename;
		}

		public void addChatMessage(ChatMessage message)
		{
			if (message != null)
				chatMessages.Add(message);
		}

		public void setPlayerResign(int playerIndex, int currentTime)
		{
			if (players.ContainsKey(playerIndex) && players[playerIndex].resignTime < 0)
			{
				players[playerIndex].resignTime = currentTime;
			}
		}

		public bool isPlayer(int index)
		{
			return players.ContainsKey(index);
		}

		public bool isPlayerResigned(int index)
		{
			if (isPlayer(index))
			{
				return players[index].resignTime >= 0;
			}
			return false;
		}

		public string getPlayerName(int index)
		{
			if (isPlayer(index))
				return players[index].getName();
			else
				return "";
		}

		public void setPlayerFeudalTime(int index, int currentTime)
		{
			if (isPlayer(index))
				players[index].setFeudalTime(currentTime);
		}

		public void setPlayerCastleTime(int index, int currentTime)
		{
			if (isPlayer(index))
				players[index].setCastleTime(currentTime);
		}

		public void setPlayerImperialTime(int index, int currentTime)
		{
			if (isPlayer(index))
				players[index].setImperialTime(currentTime);
		}

		public void setPlayerSummaryAchievement(int index, SummaryAchievement summary)
		{
			if (isPlayer(index))
				players[index].setSummaryAchievement(summary);
		}

		public void setPlayerMilitaryAchievement(int index, MilitaryAchievement military)
		{
			if (isPlayer(index))
				players[index].setMilitaryAchievement(military);
		}

		public void setPlayerEconAchievement(int index, EconAchievement economy)
		{
			if (isPlayer(index))
				players[index].setEconAchievement(economy);
		}

		public void setPlayerSocialAchievement(int index, SocialAchievement society)
		{
			if (isPlayer(index))
				players[index].setSocialAchievement(society);
		}

		public void setPlayerTechAchievement(int index, TechAchievement technology)
		{
			if (isPlayer(index))
				players[index].setTechAchievement(technology);
		}

		public void setVictors()
		{
			int count = teams.Count(t => t.defeated == false);

			if (count == 1)
				winners = teams.First(t => t.defeated == false).playersStatus.Keys.ToList();
		}

		public void addPlayerResearch(int index, int researchId, int currentTime)
		{
			if (isPlayer(index))
				players[index].addResearch(researchId, currentTime);
		}

		public void addTrainCommand(int index, int unitType, int amount, int currentTime)
		{
			if (isPlayer(index))
				players[index].addTraining(unitType, amount, currentTime);
		}

		public void addBuildCommand(int index, int buildingId, int currentTime)
		{
			if (isPlayer(index))
				players[index].addBuild(buildingId, currentTime);
		}

		public void addPreGameChat(List<ChatMessage> msgs)
		{
			preGameChat = msgs;
		}

		public int getPlayerIndex(string name)
		{
			foreach (Player p in players.Values)
			{
				if (p.name == name)
					return p.index;
			}
			return -1;
		}

		public int getPlayerTeam(int playerIndex)
		{
			if (isPlayer(playerIndex))
				return players[playerIndex].teamListIndex;
			return -1;
		}

		public string exportMainJSON()
		{
			Dictionary<string, object> data = new Dictionary<string, object>();
			data.Add("id", id);
			data.Add("version", getVersion());
			data.Add("subVersion", getSubVersion());
			data.Add("lobbyName", lobbyName);
			data.Add("gameType", gameSetting.gameType);
			data.Add("gameMode", gameSetting.gameMode);
			data.Add("difficultyLevel", gameSetting.difficultyLevel);
			data.Add("gameSpeed", gameSetting.gameSpeed);
			data.Add("mapVisibility", gameSetting.mapVisibility);
			data.Add("mapSize", gameSetting.mapSize);
			data.Add("mapId", map.id);
			//data.Add("popLimit", gameSetting.popLimit);
			//data.Add("treatyLength", gameSetting.treatyLength);
			//data.Add("resourceLevel", gameSetting.resourceLevel);
			//data.Add("startingAge", gameSetting.startingAge);
			//data.Add("endingAge", gameSetting.endingAge);
			//data.Add("lockDiplomacy", gameSetting.lockDiplomacy);
			//data.Add("lockSpeed", gameSetting.lockSpeed);
			//data.Add("allowCheat", gameSetting.allowCheat);
			//data.Add("aegisEnabled", gameSetting.aegisEnabled);
			//data.Add("allTech", gameSetting.allTech);
			//data.Add("teamTogether", gameSetting.teamTogether);
			//data.Add("timeLimit", victorySetting.timeLimit);
			//data.Add("scoreLimit", victorySetting.scoreLimit);
			//data.Add("victoryCondition", victorySetting.mode);
			//data.Add("relicCount", victorySetting.customRelic);

			Dictionary<string, object> temp = new Dictionary<string, object>();
			Dictionary<string, object> temp1 = new Dictionary<string, object>();
			Dictionary<string, object> temp2 = new Dictionary<string, object>();

			foreach (Player p in players.Values)
			{
				temp1 = new Dictionary<string, object>();
				temp1.Add("name", p.name);
				temp1.Add("civilisation", p.civilisation);
				temp1.Add("teamListIndex", p.teamListIndex);
				temp1.Add("teamIndex", p.teamIndex);
                temp1.Add("resignTime", string.Format("{0:0.0000000}", (p.resignTime / (24.0*3600000.0))));
				//temp1.Add("isHuman", p.isHuman);
				//temp1.Add("isSpectator", p.isSpectator);
				//temp1.Add("isCooping", p.isCooping);
				temp1.Add("colourId", p.colourId);
                temp1.Add("averageDistanceFromRelic", p.averageRelicDistance);

				//temp2 = new Dictionary<string, object>();
				//temp2.Add("food", p.initialState.food);
				//temp2.Add("wood", p.initialState.wood);
				//temp2.Add("gold", p.initialState.gold);
				//temp2.Add("stone", p.initialState.stone);
				//temp2.Add("startingAge", p.initialState.startingAge);
				//temp2.Add("x", p.initialState.position[0]);
				//temp2.Add("y", p.initialState.position[1]);

				//temp1.Add("initialState", temp2);
                temp1.Add("feudalTime", string.Format("{0:0.0000000}", (p.feudalTime / (24.0 * 3600000.0))));
                temp1.Add("castleTime", string.Format("{0:0.0000000}", (p.castleTime / (24.0 * 3600000.0))));
                temp1.Add("imperialTime", string.Format("{0:0.0000000}", (p.imperialTime / (24.0 * 3600000.0))));

				temp.Add(p.index.ToString(), temp1);
			}

			data.Add("players", temp);

			temp = new Dictionary<string, object>();
			for (int i = 0; i < teams.Count; i++)
			{
				Team p = teams[i];
				temp1 = new Dictionary<string, object>();
				temp1.Add("index", p.index);
				temp1.Add("defeated", p.defeated);
				temp1.Add("playerStatus", p.playersStatus);

				temp.Add(i.ToString(), temp1);
			}

			data.Add("teams", temp);

			temp = new Dictionary<string, object>();
			for (int i = 0; i < chatMessages.Count; i++)
			{
				temp.Add(i.ToString(), chatMessages[i]);
			}

			data.Add("chatMessages", temp);

			//temp = new Dictionary<string, object>();
			//for (int i = 0; i < preGameChat.Count; i++)
			//{
			//	temp.Add(i.ToString(), preGameChat[i]);
			//}
			//data.Add("preGameChat", preGameChat);

			temp = new Dictionary<string, object>();
			foreach (int p in winners)
			{
				temp.Add(players[p].name, p);
			}
			data.Add("winners", temp);

			temp = new Dictionary<string, object>();
			for (int i = 0; i < units.Count; i++)
			{
				GameUnit p = units[i];
				temp1 = new Dictionary<string, object>();
				temp1.Add("index", p.gameObjectId);
				temp1.Add("id", p.id);
				temp1.Add("owner", p.owner);
				temp1.Add("objectType", p.objectType);
				temp1.Add("positionX", p.positionX);
				temp1.Add("positionY", p.positionY);

				temp.Add(i.ToString(), temp1);
			}

			data.Add("units", temp);

			return JsonConvert.SerializeObject(data, Formatting.Indented);
		}
	}
}
