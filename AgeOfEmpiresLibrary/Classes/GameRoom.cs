using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AgeOfEmpiresLibrary
{
	/// <summary>
	/// Game room object.
	/// stores admin metadata of a game, including game settings, player info, game status (e.g. desynced, saved, ended)
	/// </summary>
	public class GameRoom
	{
		private DateTime date;
		private int gameTime;
        private Player gaia;
		private List<Player> players;
		private List<Player> spectators;
		private List<int> teams;

		private Map map;

        private string name;

        private int gameVersion;
        private double gameSubVersion;

        private int owner;
		private int gameMode;
        private int gameType;
		private Tuple<int, int> victorySetting;
		private int difficulty;
		private int resourceLevel;
		private int treatyLength;
		private int startAge;
		private int endAge;
		private int speed;
		private int populationLimit;
        private int playerCount;

		private bool teamTogether;
		private bool allTech;
		private bool diplomacyLock;
		private bool allowCheat;
        private bool isRanked;

        private bool multiplayer;

		public GameRoom()
		{
            players = new List<Player>();
            spectators = new List<Player>();
            teams = new List<int>();
            map = new Map();
            gaia = new Player();
		}

        public void setAI(bool hasAI)
        {
            
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public void setGameTime(int gameTime)
        {
            this.gameTime = gameTime;
        }

        public void setMultiplayer (bool multiplayer)
        {
            this.multiplayer = multiplayer;
        }

        public void addPlayer(Player p)
        {
            if (p.isValid() && !players.Contains(p) && !spectators.Contains(p))
            {
                players.Add(p);
            }
        }

		public void addPlayer(int id, string name, int colour, int team, int civ, int state)
		{
            Player p = new Player(id, name, colour, team, civ, state);

            switch (state)
            {
                case PlayerSetting.STATE_HUMAN:
                    players.Add(p);
                    break;

                case PlayerSetting.STATE_SPECTATOR:
                    spectators.Add(p);
                    break;

                default:
                    break;
            }
		}

        public void addPlayerObject(int playerId, Createable playerUnit)
        {

        }

        public void addPlayerObject(int playerId, int unitId, double positionX, double positionY)
        {
            
        }

        public void addPlayerObject(int id, Unit unit)
        {
            
        }

        public void addPlayerStructure(int id, Structure structure)
        {
            
        }

		public void addSpectator(Player p)
		{
			if (p.isValid() && !players.Contains(p) && !spectators.Contains(p))
			{
				spectators.Add(p);
			}
		}

        public void addTeam(int t)
        {
            if (t >= 0 && !teams.Contains(t))
            {
                teams.Add(t);
            }
        }

        public void setGameMode(int mode)
        {
            if (GameSetting.isValidMode(mode))
                this.gameMode = mode;
        }

        public void setVictorySetting(int victory, int amount = 0)
        {
            if (GameSetting.isValidVictory(victory))
                this.victorySetting = new Tuple<int, int>(victory, amount);
        }

		public void setDifficulty(int difficulty)
		{
            if (GameSetting.isValidDifficulty(difficulty))
                this.difficulty = difficulty;
		}

        public void setResourceLevel(int resource)
        {
            if (GameSetting.isValidResourceLevel(resource))
                this.resourceLevel = resource;
        }

        public void setTreatyLength(int length)
        {
            if (length > 0)
                this.treatyLength = length;
        }

        public void setStartAge(int age)
        {
            if (GameSetting.isValidAge(age))
                this.startAge = age;
        }

        public void setEndAge(int age)
        {
            if (GameSetting.isValidAge(age))
                this.endAge = age;
        }

        public void setSpeed(int speed)
        {
            if (GameSetting.isValidSpeed(speed))
                this.speed = speed;
        }

        public void setPopulationLimit(int population)
        {
            if (population > 0)
                this.populationLimit = population;
        }

        public void setAllTech(bool allTech)
        {
            this.allTech = allTech;
        }

        public void setAllowCheat(bool allowCheat)
        {
            this.allowCheat = allowCheat;
        }

        public void setTeamTogether(bool teamTogether)
        {
            this.teamTogether = teamTogether;
        }

        public void setDiplomacyLock(bool diplomacyLock)
        {
            this.diplomacyLock = diplomacyLock;
        }

        public void setPlayerTeam(int pid, int team)
        {
            if (players.Count > pid && teams.Contains(team))
                players[pid].setTeam(team);
        }

        public void setMap(int id, int size, int visibility)
        {
            if (MapSetting.isValidMap(id) && MapSetting.isValidSize(size) && MapSetting.isValidVisibility(visibility))
                this.map = new Map(id, size, visibility);
        }

        public void setGameType(int type)
        {
            if (GameSetting.isValidType(type))
                this.gameType = type;
        }

        public void setPlayerCount(int count)
        {
            if (players.Count == 0)
                this.playerCount = count;

            else if (players.Count == count)
                this.playerCount = count;
        }

        public void setVersion(int version, double subversion)
        {
            this.gameVersion = version;
            this.gameSubVersion = subversion;
        }

        public void setRanked(bool isRanked)
        {
            this.isRanked = isRanked;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setOwner(int owner)
        {
            if (players.Exists(p => p.getId() == owner))
                this.owner = owner;
        }

        public void setMapDimension(int x, int y)
        {
            map.setMapDimension(x, y);
        }

        public void setMapTile(int x, int y, int terrain, int elevation)
        {
			map.setTile(x, y, terrain, elevation);
		}

		public void setPlayerInitialState(int id, Resources initialRes, int initialAge, int initialHeadRoom,
                                          int initialPopulation, int initialCivilianPopulation,
                                          int initialMilitaryPopulation)
        {
            if (players.Count > id && Age.isValidAge(initialAge) && initialHeadRoom > 0 &&
               initialPopulation > 0 && initialCivilianPopulation > 0 && initialMilitaryPopulation > 0 &&
               initialPopulation == initialMilitaryPopulation + initialCivilianPopulation &&
               initialRes.isValid())
            {
                
            }
        }

        public string exportJSON()
        {
			Dictionary<string, object> data = new Dictionary<string, object>();
			//data.Add("id", id);
			data.Add("version", gameVersion);
			data.Add("subVersion", gameSubVersion);
			data.Add("lobbyName", name);
			data.Add("gameType", GameSetting.getGameTypeName(gameType));
			data.Add("gameMode", GameSetting.getGameModeName(gameMode));
			data.Add("difficultyLevel", GameSetting.getDifficultyName(difficulty));
			data.Add("gameSpeed", GameSetting.getSpeedName(speed));
			data.Add("mapVisibility", MapSetting.getVisibilityName(map.visibility));
			data.Add("mapSize", MapSetting.getSizeName(map.size));
			data.Add("mapId", map.id);
            data.Add("mapName", MapSetting.getNameFromId(map.id));

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
	}
}
