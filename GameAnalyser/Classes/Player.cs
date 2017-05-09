using System;
using System.Collections.Generic;

namespace GameAnalyser
{
	public class Player
	{
		public int id;
		public string name;
		public int index;
		public int civilisation;
		public int teamListIndex;
		public int teamIndex;
		public int resignTime;
		public bool isHuman;
		public bool isSpectator;
		public bool owner;

		public int colourId;
		public bool isCooping;

		public InitialState initialState;
		public SummaryAchievement summary;
		public MilitaryAchievement military;
		public EconAchievement economy;
		public SocialAchievement society;
		public TechAchievement technology;

		enum Colour
		{
			Blue,
			Red,
			Green,
			Yellow,
			Teal,
			Purple,
			Grey,
			Orange
		}

		public int feudalTime;
		public int castleTime;
		public int imperialTime;

		private List<Command> commands;
		private List<GameUnit> units;
		private List<ResearchCommand> researches;
		private List<TrainCommand> trainings;
		private List<BuildCommand> builds;

		public Player()
		{
			this.initialState = new InitialState();
			this.resignTime = -1;
			researches = new List<ResearchCommand>();
			trainings = new List<TrainCommand>();
			builds = new List<BuildCommand>();
		}

		public Player(string name)
		{
			this.name = name;
			this.initialState = new InitialState();
		}

		internal string getName()
		{
			return name;
		}

		public void setTeamIndex(int v)
		{
			teamIndex = v;
		}

		public int getTeamIndex()
		{
			return teamIndex;
		}

		public void setCivilisation(int civId)
		{
			this.civilisation = civId;
		}

		public void setColour(int colour)
		{
			this.colourId = colour;
		}

		public void setInitialFood(int food)
		{
			initialState.setFood(food);
		}

		public void setInitialWood(int wood)
		{
			initialState.setWood(wood);
		}

		public void setInitialGold(int gold)
		{
			initialState.setGold(gold);
		}

		public void setInitialStone(int stone)
		{
			initialState.setStone(stone);
		}

		public void setInitialHeadRoom(int headRoom)
		{
			initialState.setHeadRoom(headRoom);
		}

		public void setInitialPopulation(int population)
		{
			initialState.setPopulation(population);
		}

		public void setInitialCivilianPopulation(int civilianPopulation)
		{
			initialState.setCivilianPopulation(civilianPopulation);
		}

		public void setInitialMilitaryPopulation(int militaryPopulation)
		{
			initialState.setMilitaryPopulation(militaryPopulation);
		}

		public void setInitialCameraLocation(double x, double y)
		{
			initialState.setCameraLocation(x, y);
		}

		public void setInitialAge(int startingAge)
		{
			initialState.setAge(startingAge);
		}

		public void setFeudalTime(int currentTime)
		{
			feudalTime = currentTime + (civilisation == Civilisation.MALAY ? (int)Math.Round(ResearchType.FEUDAL_DURATION / 1.8) : ResearchType.FEUDAL_DURATION);
		}

		public void setCastleTime(int currentTime)
		{
			castleTime = currentTime + (civilisation == Civilisation.PERSIANS ? (int)Math.Round(ResearchType.CASTLE_DURATION / 1.1) : (civilisation == Civilisation.MALAY ? (int)Math.Round(ResearchType.CASTLE_DURATION / 1.8) : ResearchType.CASTLE_DURATION));

	    }

		public void setImperialTime(int currentTime)
		{
			imperialTime = currentTime + (civilisation == Civilisation.PERSIANS ? (int)Math.Round(ResearchType.IMPERIAL_DURATION / 1.15) : (civilisation == Civilisation.MALAY ? (int)Math.Round(ResearchType.IMPERIAL_DURATION / 1.8) : ResearchType.IMPERIAL_DURATION));
		}

		public void setSummaryAchievement(SummaryAchievement summary)
		{
			this.summary = summary;
		}

		public void setMilitaryAchievement(MilitaryAchievement military)
		{
			this.military = military;
		}

		public void setEconAchievement(EconAchievement econ)
		{
			this.economy = econ;
		}

		public void setSocialAchievement(SocialAchievement social)
		{
			this.society = social;
		}

		public void setTechAchievement(TechAchievement tech)
		{
			this.technology = tech;
		}

		public void addResearch(int researchId, int currentTime)
		{
			researches.Add(new ResearchCommand(index, researchId, currentTime));
		}

		public void addTraining(int unitType, int amount, int currentTime)
		{
			trainings.Add(new TrainCommand(index, unitType, amount, currentTime));
		}

		public void addBuild(int buildingId, int currentTime)
		{
			builds.Add(new BuildCommand(index, buildingId, currentTime));
		}
	}
}
