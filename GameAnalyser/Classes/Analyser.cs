using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace GameAnalyser
{
	public class Analyser
	{
		public Analyser()
		{

		}

		public static RecordedGame analyseGame(List<byte> headerByteList, List<byte> bodyByteList, string fileName, string fileFormat)
		{
			int operationType;
			int playerIndex; // multipurpose
			int currentTime = 0;
			int unitType; // multipurpose
			byte[] tempByteArray; // multipurpose

			// Body Analyser variables
			byte[] bodyByteArray = bodyByteList.ToArray();
			List<TrainCommand> trainingOrdersAI = new List<TrainCommand>();
			List<TributeCommand> tributeOrders = new List<TributeCommand>();
			SummaryAchievement summary;
			EconAchievement economy;
			SocialAchievement society;
			TechAchievement technology;
			MilitaryAchievement military;

			List<Team> teams = new List<Team>();
			Dictionary<int, Player> players = new Dictionary<int, Player>();
			byte[] headerByteArray = headerByteList.ToArray();
			Dictionary<string, string> introMessages = new Dictionary<string, string>();

			int position = 0;

			RecordedGame recordedGame = new RecordedGame();

			int length = headerByteList.Count;

			string versionString = Encoding.ASCII.GetString(headerByteList.GetRange(0, 8).ToArray()).Trim();
			position += 8;
			versionString = versionString.Substring(versionString.Length - 1) == "\0" ? versionString.Substring(0, versionString.Length - 1) : versionString;
			double subVersionConstant = Math.Round(BitConverter.ToSingle(headerByteArray, position), 2);
			position += 4;
			int versionConstant = GameVersion.getVersionConstant(versionString, subVersionConstant);
			recordedGame.setSubVersion(subVersionConstant);
			recordedGame.setVersion(versionConstant);
			position = 8;


			int triggerInfoPos = Utility.IndexOf(headerByteList, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length;

			int gameSettingsPos = Utility.LastIndexOf(headerByteList.GetRange(0, triggerInfoPos), GameConstants.SEPARATOR) + GameConstants.SEPARATOR.Length;

			byte[] scenarioSeparator = isAoK(versionConstant) ? GameConstants.AOK_SEPARATOR : isAoe2Record(fileFormat) ? GameConstants.AOE2_RECORD_SCENARIO_SEPARATOR : GameConstants.SCENARIO_CONSTANT;

			int scenarioHeaderPos = Utility.LastIndexOf(headerByteList.GetRange(0, gameSettingsPos), scenarioSeparator) + 4;

			position = gameSettingsPos + 8;

			if (subVersionConstant >= 12.3)
				position += 16;

			if (!isAoK(versionConstant))
			{
				recordedGame.setMapId(BitConverter.ToInt32(headerByteArray, position));
				position += 4;
			}

			recordedGame.setDifficultyLevel(BitConverter.ToInt32(headerByteArray, position));
			position += 4;
			recordedGame.setLockDiplomacy((int)BitConverter.ToUInt32(headerByteArray, position) > 0);
			position += 4;

			Player player;
			int human;


			length = 0;
			for (int i = 0; i < 8; i++)
			{
				if (BitConverter.ToInt32(headerByteArray, position) < 0)
					break;
				
				player = new Player();
				player.index = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				human = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				length = (int)BitConverter.ToUInt32(headerByteArray, position);
				position += 4;
				if (length > 0 && Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim() != "")
				{
					player.name = Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray());
					position += (int)length;
				}
				else
				{
					player.name = "";
				}

				player.isHuman = human == 0x02;
				player.isSpectator = human == 0x06;

				if (human != 0 && human != 1)
				{
					players[player.index] = player;
				}
			}

			position = triggerInfoPos + 1;

			// Skipping Trigger Info Block
			int conditionSize = 11 * 4 + 4 * 4 + 3 * 4;

			conditionSize = isHDPatch4(versionConstant, subVersionConstant) ? conditionSize + 2 * 4 : conditionSize;

			int triggerCount = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			int count = 0;
			int count2 = 0;
			int descriptionLength;
			int nameLength;
			int effectCount;
			int selectedObjectsCount;
			int textLength;
			int soundFileLength;
			int conditionsCount;

			while (count < triggerCount)
			{
				position += 4 + 2 * 1 + 3 * 4; // int, 2 bool, 3 int
				descriptionLength = BitConverter.ToInt32(headerByteArray, position);
				position += 4;

				if (descriptionLength > 0)
				{
					position += descriptionLength;
				}

				nameLength = BitConverter.ToInt32(headerByteArray, position);
				position += 4;

				if (nameLength > 0)
				{
					position += nameLength;
				}

				effectCount = BitConverter.ToInt32(headerByteArray, position);
				position += 4;

				while (count2 < effectCount)
				{
					position += 6 * 4; // 6 int

					selectedObjectsCount = BitConverter.ToInt32(headerByteArray, position);
					position += 4;

					if (selectedObjectsCount == -1)
						selectedObjectsCount = 0;

					position += (
						9 * 4 + // 9 int
						2 * 4 + // location (2 int)
						4 * 4 + // area (2 locations)
						3 * 4   // 3 int
					);

					if (isHDPatch4(versionConstant, subVersionConstant))
					{
						position += 4; // Attack Stance effect
					}

					textLength = BitConverter.ToInt32(headerByteArray, position);
					position += 4;
					position += textLength > 0 ? textLength : 0;

					soundFileLength = BitConverter.ToInt32(headerByteArray, position);
					position += 4;
					position += soundFileLength > 0 ? soundFileLength : 0;

					position += selectedObjectsCount * 4; // unit IDs, 1 int each

					count2++;
				}
				position += effectCount * 4; // list of effect, 1 int each
				conditionsCount = BitConverter.ToInt32(headerByteArray, position);
				position += 4;

				position += conditionsCount * conditionSize; // conditions
				position += conditionsCount * 4; // list of condition order, 1 int each

				count++;
			}

			position += triggerCount > 0 ? triggerCount * 4 : 0;

			for (int i = 0; i < 8; i++)
			{
				if (players.ContainsKey(i + 1))
				{
					players[i + 1].setTeamIndex(headerByteList[position + i] - 1);
				}
			}
			position += 8;

			if (subVersionConstant < 12.3)
				position++;

			recordedGame.setMapVisibility(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// what is this?
			position += 4;

			recordedGame.setMapSize(BitConverter.ToInt32(headerByteArray, position));
			position += 4;
			recordedGame.setPopLimit(isUserPatch(versionConstant) ? BitConverter.ToInt32(headerByteArray, position) * 25 : BitConverter.ToInt32(headerByteArray, position)); // User Patch store pop as pop / 25
			position += 4;

			if (isMgx(fileFormat))
			{
				recordedGame.setGameType(headerByteList[position] < 0 ? headerByteList[position] : scenarioHeaderPos > 0 ? GameType.TYPE_SCENARIO : -1);
				position += 2;
			}
			else 
			{
				recordedGame.setGameType(scenarioHeaderPos > 0 ? GameType.TYPE_SCENARIO : -1);
			}

			if (subVersionConstant >= 11.96)
			{
				position++;
			}

			// problem here
			// what if someone chat and then quit game
			int messageCount = 0;
			List<ChatMessage> pregameChat = new List<ChatMessage>();
			if (!isMgx(fileFormat))
			{
				position += 6;
			}
			string chat = "";
			messageCount = BitConverter.ToInt32(headerByteArray, position) - 1;
			position += 8;

			for (int i = 0; i < messageCount - 1; i++)
			{
				length = BitConverter.ToInt32(headerByteArray, position);
				position += 4;

				if (length > 0)
				{
					chat = Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim();
					position += length;

					// pre-game chat messages are stored as "@#%dPlayerName: Message",
					// where %d is a digit from 1 to 8 indicating player's index (or
					// colour)

					if (int.TryParse(chat[2].ToString(), out playerIndex))
					{
						if (chat.Substring(0, 2) == "@#" && playerIndex >= 1 && playerIndex <= 8)
						{
							pregameChat.Add(new ChatMessage(-1, playerIndex, chat.Substring(3, chat.IndexOf(':') - 3), chat.Substring(chat.IndexOf(':') + 1)));
						}
					}
				}
			}

			if (isAoe2Record(fileFormat))
			{

				position = 12;

				int separatorCount = subVersionConstant >= 12.50 ? 4 : 6;

				for (int i = 0; i < separatorCount; i++)
				{
					position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position);
					if (position == -1)
						throw new Exception("Unrecognised AOE2RECORD Header Format");
					
					position += GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;
				}

				position += 10; // unknown
			}
			else
				position = 12;

			int includeAI = (int)BitConverter.ToUInt32(headerByteArray, position);
			position += 4;

			if (includeAI != 0 && subVersionConstant < 12)
			{
				position += 2;

				tempByteArray = headerByteList.GetRange(position, 2).ToArray();
				if (!BitConverter.IsLittleEndian)
					Array.Reverse(tempByteArray);
				int numAIString = (int)BitConverter.ToUInt16(tempByteArray, 0);
				position += 2;
				position += 4;

				for (int i = 0; i < numAIString; i++)
				{
					length = BitConverter.ToInt32(headerByteArray, position);
					position += 4;

					position += length;
				}

				position += 6;

				int actionSize = 4 + 2 + 2 + 4 * 4; // int, id, unknown, params
				int ruleSize = 12 + 1 + 1 + 2 + actionSize * 16; // unknown, #facts, #facts + actions, unknown

				if (isHDPatch4(versionConstant, subVersionConstant))
				{
					ruleSize += 0x180;
				}

				for (int i = 0; i < 8; i++)
				{
					position += (
						4 + // int unknown
						4 + // int seq
						2 // max rules, constant
					);

					tempByteArray = headerByteList.GetRange(position, 2).ToArray();
					if (!BitConverter.IsLittleEndian)
						Array.Reverse(tempByteArray);
					int numRules = (int)BitConverter.ToUInt16(tempByteArray, 0);
					position += 2;
					position += 4;
					for (int j = 0; j < numRules; j++)
					{
						position += ruleSize;
					}
				}
				position += 104; // unknown
				position += 10 * 4 * 8; // timers: 10 ints * 8 players
				position += 256 * 4; // shared goals: 256 ints
				position += 4096; // ???

				if (subVersionConstant >= 11.96)
					position += 1280;

				if (subVersionConstant >= 12.3)
				{
					// The 4 bytes here are likely actually somewhere in between one
					// of the skips above.
					position += 4;
				}
			}

			position += 4;
			recordedGame.setGameSpeed(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// These bytes contain the game speed again several times over, as ints
			// and as floats (On normal speed: 150, 1.5 and 0.15). Why?!

			position += 37;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			int pov = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;
			if (players.ContainsKey(pov))
				players[pov].owner = true;

			int numPlayers = headerByteArray[position++] - 1; // #0 is GAIA

			if (isMgx(fileFormat))
			{
				recordedGame.setCheats(headerByteArray[position], headerByteArray[position + 1]);
				position += 2;
			}

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			recordedGame.setGameMode((int)BitConverter.ToUInt16(tempByteArray, 0));
			position += 2;

			position += 60;

			int mapSizeX = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			int mapSizeY = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			if (mapSizeX > 10000 || mapSizeY > 10000 || mapSizeX < 0 || mapSizeY < 0)
			{
				throw new Exception("Invalid Map Size.");
			}

			recordedGame.setMapXSize(mapSizeX);
			recordedGame.setMapYSize(mapSizeY);
			recordedGame.setMapTiles();

			int numMapZones = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			for (int i = 0; i < numMapZones; i++)
			{
				if (subVersionConstant >= 11.93)
				{
					position += 2048 + mapSizeX * mapSizeY * 2;
				}
				else
				{
					position += 1275 + mapSizeX * mapSizeY;
				}

				int numFloats = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				position += numFloats * 4 + 4;
			}

			position += 2; // Map visibility & Fog of war flags

			// Get Map Terrain and Elevation
			for (int x = 0; x < mapSizeX; x++)
			{
				for (int y = 0; y < mapSizeY; y++)
				{
					recordedGame.setMapTile(x, y, headerByteArray[position], headerByteArray[position + 1]);
					position += 2;
				}
			}

			int numData = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			position += numData * 4;
			position += 4; // testing
			for (int i = 0; i < numData; i++)
			{
				int numObstructions = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				position += numObstructions * 8;
			}

			// Visibility Map
			int mapSizeX2 = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			int mapSizeY2 = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			position += mapSizeX2 * mapSizeY2 * 4; // map data
			position += 4;

			numData = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			position += numData * 27;
			position += 4;

			// Continue to Migrate PlayerInfoBlock Analyser, then back to Header Analyser

			numPlayers++; // Add GAIA
			Player GAIA = new Player("GAIA");

			for (int i = -1; i < players.Count; i++) // starts with GAIA
			{
				if (i == -1)
					player = GAIA;
				else if (players.ContainsKey(i))
					player = players[i];
				else
					player = new Player();

				if (isTrial(versionConstant))
				{
					position += 4;
				}

				position += numPlayers + 43;

				// skip playername
				tempByteArray = headerByteList.GetRange(position, 2).ToArray();
				if (!BitConverter.IsLittleEndian)
					Array.Reverse(tempByteArray);
				int playerNameLen = (int)BitConverter.ToUInt16(tempByteArray, 0);
				position += 2;
				position += playerNameLen;


				position += 1; // always 22?
				int numResources = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				position += 1; // always 33?
				int resourcesEnd = position + 4 * numResources;

				if (player != null)
				{
					player.setInitialFood((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialWood((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialGold((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialStone((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialHeadRoom((int)BitConverter.ToSingle(headerByteArray, position)); // Housing - Pop
					position += 4;

					position += 4;

					// Post-Imperial Age
					player.setInitialAge((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialCivilianPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialMilitaryPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					position = resourcesEnd + 1;

					player.setInitialCameraLocation(Math.Round(BitConverter.ToSingle(headerByteArray, position), 2), Math.Round(BitConverter.ToSingle(headerByteArray, position + 4), 2));
					position += 8;

					position += isMgx(fileFormat) ? 9 : 5;

					player.setCivilisation(headerByteArray[position] >= 1 ? headerByteArray[position] : 1);
					position++;

					position += 3;

					player.setColour(headerByteArray[position++]);
				}
				else
				{
					position = resourcesEnd + 1;
					position += isMgx(fileFormat) ? 9 : 5;
					position += 1 + 3 + 1;
				}


				if (isTrial(versionConstant))
					position += 4;

				position += numPlayers + 70;
				position += isMgx(fileFormat) ? (792 + 41249) : (756 + 34277);
				position += mapSizeX * mapSizeY;

				// Getting exist object positions
				int existObjectPos = Utility.IndexOf(headerByteList, GameConstants.EXIST_OBJECT_SEPARATOR, position);
				if (existObjectPos < 0)
					throw new Exception("Could not find existObjectSeparator");
				position = existObjectPos + GameConstants.EXIST_OBJECT_SEPARATOR.Length;

				// PlayerObjectListAnalser
				bool done = false;
				int separatorPos;
				GameUnit tempUnit = new GameUnit();
				List<GameUnit> gaiaUnits = new List<GameUnit>();
				List<GameUnit> playerUnits = new List<GameUnit>();
				while (!done)
				{
					tempUnit = new GameUnit();
					int objectType = headerByteArray[position];
					tempUnit.objectType = objectType;
					tempUnit.owner = objectType == 0 ? 0 : headerByteArray[position + 1];
					position += 2;

					tempByteArray = headerByteList.GetRange(position, 2).ToArray();
					if (!BitConverter.IsLittleEndian)
						Array.Reverse(tempByteArray);
					tempUnit.id = (int)BitConverter.ToUInt16(tempByteArray, 0);
					position += 2;

					switch (objectType)
					{
						case UnitType.UT_EYECANDY:
							if (AoEResourcePack.isGaiaUnit(tempUnit.id))
							{
								int restore = position;
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								position = restore;
								gaiaUnits.Add(tempUnit);
							}
							position += 63 - 4;

							// TODO: details needed
							if (isHDEdition(versionConstant))
								position += 3;

							if (isMgl(fileFormat))
								position++;

							break;

						case UnitType.UT_FLAG:
							if (isHDEdition(versionConstant))
								position += 3;

							if (isMgx(fileFormat))
							{
								position += 59;
								position += headerByteArray[position] == 2 ? 39 : 5;
							}
							else
								position += 103 - 4;

							break;

						case UnitType.UT_DEAD_OR_FISH:
							// TODO: details needed
							if (isHDEdition(versionConstant))
							{
								position += 3;
							}
							if (isMgx(fileFormat))
							{
								position += 1;
							}

							position += headerByteArray[position + 59] == 2 ? 17 + 204 - 4 : 204 - 4;

							if (isHDPatch4(versionConstant, subVersionConstant))
								position++;

							break;

						// TODO: Object Type 40 and 50 not included

						case UnitType.UT_PROJECTILE:
							// readProjectile not implemented
							break;

						case UnitType.UT_CREATABLE:
							if (AoEResourcePack.isGaiaUnit(tempUnit.id))
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								gaiaUnits.Add(tempUnit);
							}
							else if (tempUnit.owner != 0)
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								playerUnits.Add(tempUnit);
							}

							if (isMgx(fileFormat))
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.AOK_OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.AOK_OBJECT_END_SEPARATOR.Length;
							}
							else 
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.OBJECT_END_SEPARATOR.Length;
							}

							if (separatorPos < 0)
								throw new Exception("Could not find OBJECT_END_SEPARATOR");


							break;

						case UnitType.UT_BUILDING:
							if (tempUnit.owner > 0)
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								playerUnits.Add(tempUnit);
							}

							if (isMgx(fileFormat))
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.AOK_OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.AOK_OBJECT_END_SEPARATOR.Length;
								position++;
							}
							else
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.OBJECT_END_SEPARATOR.Length;
							}

							if (separatorPos < 0)
								throw new Exception("Could not find OBJECT_END_SEPARATOR");


							position += 126;

							if (isHDPatch4(versionConstant, subVersionConstant))
								position -= 3;

							break;

						case 00:
							position -= 4;
							if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.GAIA_INFO_END_SEPARATOR) == 0)
							{
								position += GameConstants.GAIA_INFO_END_SEPARATOR.Length;
								done = true;
								break;
							}
							else if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.PLAYER_INFO_END_SEPARATOR) == 0)
							{
								position += GameConstants.PLAYER_INFO_END_SEPARATOR.Length;
								done = true;
								break;
							}
							else if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_MID_SEPARATOR_GAIA) == 0)
							{
								position += GameConstants.OBJECT_MID_SEPARATOR_GAIA.Length;
							}
							else
							{
								throw new Exception("Could not find GAIA object separator");
							}

							break;
						default:
							throw new Exception("Unknown object type " + objectType.ToString());
					}
				}
				//player.units = playerUnits;
			}

			if (scenarioHeaderPos > 0)
			{
				position = scenarioHeaderPos;
				position += 4;
				position += 4;
				position += 16 * 256; // Players Names
				position += 16 * 4; // Player Names (string table)
				position += 16 * (4 + 4 + 4 + 4); // bool isActive, bool isHuman, int civilistion, const 0x00000004
				position += 5;

				// Elapsed time, 'f' 4
				position += 4;

				// Possible string IDs for message
				position += isMgl(fileFormat) ? 22 : 18;
			}

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("Introduction", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += length;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("Hints", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += length;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("Victory", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += length;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("Loss", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += length;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("History", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += length;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			introMessages.Add("Scout", Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
			position += (int)length;

			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position);
			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position + 4);

			// Victory Setting Analyser
			position += 4;

			//recordedGame.setConquestVictory((int)BitConverter.ToUInt32(headerByteArray, position));
			position += 4;
			position += 4; // zero

			recordedGame.setRelicVictory(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			recordedGame.setExplorartionVictory(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			recordedGame.setCustomVictory((int)BitConverter.ToUInt32(headerByteArray, position));
			position += 4;

			//victorySetting = new VictorySetting();
			//victorySetting.mode = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			recordedGame.setTimeLimit(BitConverter.ToInt32(headerByteArray, position));
			position += 4;
			recordedGame.setScoreLimit(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			//victorySetting.customRelic = customRelic;
			//victorySetting.customPercentExplored = customPercentExplored;
			//victorySetting.customAll = customAll;

			// Team Building
			teams = new List<Team>();
			Team team = new Team(); // temp
 			foreach (Player p in players.Values)
			{
				bool found;
				// Team = 0 for own team / cooping
				if (p.teamIndex == 0)
				{
					found = false;

					// Not a Cooping player
					if (!found)
					{
						team = new Team();
						team.setIndex(0);
						team.addPlayer(p.index);
						teams.Add(team);
					}
				}
				else
				{
					if (teams.Exists(t => t.getIndex() == p.teamIndex))
					{
						teams.First(t => t.getIndex() == p.teamIndex).addPlayer(p.index);
					}
					else
					{
						team = new Team();
						team.setIndex(p.teamIndex);
						team.addPlayer(p.index);
						teams.Add(team);
					}
				}
			}

			recordedGame.teams = teams;
			recordedGame.players = players;

			//gameSetting = new GameSetting();
			//gameSetting.gameType = header.gameType;
			//gameSetting.gameSpeed = gameSpeed;
			//gameSetting.difficultyLevel = header.difficulty;

			//body section

			position = 0;
			int next = -1;

			while (position < bodyByteArray.Length - 3)
			{
				operationType = 0;
				if (isMgl(fileFormat) && position == 0)
					operationType = CommandType.OP_META2;
				else
				{
					operationType = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;
				}

				if (operationType == CommandType.OP_META || operationType == CommandType.OP_META2)
				{
					int command = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;

					if (command == CommandType.META_GAME_START)
					{
						position += isMgl(fileFormat) ? 32 : 20;
					}
					else if (operationType == CommandType.META_CHAT)
					{
						length = BitConverter.ToInt32(bodyByteArray, position);
						position += 4;

						if (length > 0)
						{
							chat = Encoding.ASCII.GetString(bodyByteList.GetRange(position, length).ToArray()).Trim();
							position += length;

							if (int.TryParse(chat[2].ToString(), out playerIndex))
							{
								if (chat.Substring(0, 2) == "@#" && playerIndex >= 1 && playerIndex <= 8)
								{
									/*
                                    if (chat.Substring(3,2) == "--" && chat.Substring(chat.Length - 2) == "--")
                                    {
                                        // --Warning: You are under attack --
                                    }
                                    else if (players.Exists(p => p.index == playerIndex))
                                    {

                                    }
                                    */
									recordedGame.addChatMessage(new ChatMessage(-1, playerIndex, chat.Substring(3, chat.IndexOf(':') - 3), chat.Substring(chat.IndexOf(':') + 1)));
								}
							}
						}
					}
				}
				else if (operationType == CommandType.OP_SYNC)
				{
					currentTime = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;
					if (BitConverter.ToInt32(bodyByteArray, position) == 0)
					{
						position += 28;
					}
					position += 12 + 4; // 4 for the if condition checking
				}
				else if (operationType == CommandType.OP_COMMAND)
				{
					length = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;
					next = position + length;
					int command = bodyByteArray[position];
					position++;

					switch (command)
					{
						case CommandType.COMMAND_RESIGN:
							playerIndex = bodyByteArray[position];
							//playerNumber = bodyByteArray[position + 1];
							//disconnected = bodyByteArray[position + 2];
							position += 3;
							if (recordedGame.isPlayer(playerIndex))
							{
								recordedGame.setPlayerResign(playerIndex, currentTime);
								recordedGame.addChatMessage(new ChatMessage(currentTime, playerIndex, recordedGame.getPlayerName(playerIndex), recordedGame.getPlayerName(playerIndex) + " resigned"));
							}
							break;

						case CommandType.COMMAND_RESEARCH:
							position += 3;
							int buildingId = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							playerIndex = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							int researchId = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							//tempPlayer = players[playerIndex];
							if (recordedGame.isPlayer(playerIndex))
							{
								switch (researchId)
								{
									case ResearchType.RESEARCH_FEUDAL:
										recordedGame.setPlayerFeudalTime(playerIndex, currentTime);
										break;

									case ResearchType.RESEARCH_CASTLE:
										recordedGame.setPlayerCastleTime(playerIndex, currentTime);
										break;

									case ResearchType.RESEARCH_IMPERIAL:
										recordedGame.setPlayerImperialTime(playerIndex, currentTime);
										break;
								}

								recordedGame.addPlayerResearch(playerIndex, researchId, currentTime);
							}

							break;

						// Train Unit
						case CommandType.COMMAND_TRAIN:
							position += 3;
							buildingId = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							unitType = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							int amount = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							recordedGame.addTrainCommand(-1, unitType, amount, currentTime);
							break;

						// Train Single Unit (AI)
						case CommandType.COMMAND_TRAIN_SINGLE:
							position += 9;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							unitType = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							trainingOrdersAI.Add(new TrainCommand(-1, unitType, 1, currentTime));
							break;

						// Building
						case CommandType.COMMAND_BUILD:
							position++;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							playerIndex = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							position += 8;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							buildingId = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							buildingId = AoEResourcePack.normaliseUnit(buildingId);

							recordedGame.addBuildCommand(playerIndex, buildingId, currentTime);
							break;

						// Tribute
						case CommandType.COMMAND_TRIBUTE:
							playerIndex = bodyByteArray[position];
							int payeeId = bodyByteArray[position + 1];
							int resourceId = bodyByteArray[position + 2];
							position += 3;

							if (recordedGame.isPlayer(playerIndex) && recordedGame.isPlayer(payeeId))
							{
								amount = (int)Math.Round(BitConverter.ToSingle(bodyByteArray, position));
								position += 4;
								int tax = (int)Math.Round(BitConverter.ToSingle(bodyByteArray, position));
								position += 4;

								tributeOrders.Add(new TributeCommand(playerIndex, payeeId, resourceId, amount, tax, currentTime));
							}
							else
								position += 8;

							break;

						// Multiplayer postgame data in UP1.4 RC2+
						case CommandType.COMMAND_POSTGAME:

							position += 3; // skip body command metadata
							position += 32; // scenariofilename from bodyString
							numPlayers = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;
							int gameDuration = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;
							bool allowCheat = bodyByteArray[position++] == 1;
							bool isCompleted = bodyByteArray[position++] == 1;
							position += 10; // zeros
							double u0 = Math.Round(BitConverter.ToSingle(bodyByteArray, position));
							position += 4;
							int mapSize = bodyByteArray[position++];
							int mapId = bodyByteArray[position++];
							int populationLimit = bodyByteArray[position++];
							position++;
							position += 1; // victory
							position += 1; // starting age
							int resources = bodyByteArray[position++];
							bool allTech = bodyByteArray[position++] == 1;
							bool teamTogether = bodyByteArray[position++] == 1;
							bool isDeathMatch = bodyByteArray[position++] == 1;
							bool isRegicide = bodyByteArray[position++] == 1;
							int u1 = bodyByteArray[position++];
							bool lockTeam = bodyByteArray[position++] == 1;
							bool lockSpeed = bodyByteArray[position++] == 1;
							int u2 = bodyByteArray[position++];

							// Postgame Data
							for (int i = 0; i < 8; i++)
							{
								summary = new SummaryAchievement();
								military = new MilitaryAchievement();
								economy = new EconAchievement();
								society = new SocialAchievement();
								technology = new TechAchievement();
								playerIndex = recordedGame.getPlayerIndex(Encoding.ASCII.GetString(bodyByteList.GetRange(position, 16).ToArray()).Trim());
								summary.playerName = Encoding.ASCII.GetString(bodyByteList.GetRange(position, 16).ToArray()).Trim();
								position += 16;

								for (int j = 0; j < 8; j++)
								{
									//tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									//if (!BitConverter.IsLittleEndian)
									//	Array.Reverse(tempByteArray);
									//tempAchievement.totalScores[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								summary.isVictory = bodyByteArray[position++] == 1;
								summary.civId = bodyByteArray[position++];
								summary.colourId = bodyByteArray[position++];
								summary.teamIndex = bodyByteArray[position++];
								summary.alliesCount = bodyByteArray[position++];
								position++; // -1
								summary.isMVP = bodyByteArray[position++] == 1;
								position += 3; // Padding
								summary.result = bodyByteArray[position++];
								position += 3; // Padding

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								summary.militaryScore = (int)BitConverter.ToUInt16(tempByteArray, 0);
								military.score = summary.militaryScore;
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsKilled = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.hitPointsKilled = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsLost = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.buildingsRazed = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.hitPointsRazed = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.buildingsLost = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsConverted = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									military.playerUnitsKilled[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									military.playerBuildingsRazed[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.U0 = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								economy.foodCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.woodCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.stoneCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.goldCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tributeSent = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tributeReceived = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tradeProfit = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.relicGold = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									economy.playerTributeSent[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								technology.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								technology.U0 = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								technology.feudalTime = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								technology.castleTime = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								technology.imperialTime = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								technology.mapExploration = bodyByteArray[position++];

								technology.researchCount = bodyByteArray[position++];

								technology.researchPercent = bodyByteArray[position++];

								position++; // padding

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								society.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								society.wonderCount = bodyByteArray[position++];

								society.castleCount = bodyByteArray[position++];

								society.relicCaptured = bodyByteArray[position++];

								society.U0 = bodyByteArray[position++];

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								society.villagerHigh = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								position += 84; // Padding

								recordedGame.setPlayerSummaryAchievement(playerIndex, summary);
								recordedGame.setPlayerEconAchievement(playerIndex, economy);
								recordedGame.setPlayerSocialAchievement(playerIndex, society);
								recordedGame.setPlayerTechAchievement(playerIndex, technology);
							}

							break;
					}

					position = next + 4;
				}
			}

			return recordedGame;
		}

		public static bool  isTrial(int versionConstant)
		{
			return GameVersion.isTrial(versionConstant);
		}

		public static bool  isAoK(int versionConstant)
		{
			return GameVersion.isAoK(versionConstant);
		}

		public static bool  isAoC(int versionConstant)
		{
			return GameVersion.isAoC(versionConstant);
		}

		public static bool  isUserPatch(int versionConstant)
		{
			return GameVersion.isUserPatch(versionConstant);
		}

		public static bool  isHDEdition(int versionConstant)
		{
			return GameVersion.isHDEdition(versionConstant);
		}

		public static bool  isHDPatch4(int versionConstant, double subVersion)
		{
			return GameVersion.isHDPatch4(versionConstant, subVersion);
		}

		public static bool  isMgl(string fileFormat)
		{
			return fileFormat == ".mgl";
		}

		public static bool  isMgx(string fileFormat)
		{
			return fileFormat == ".mgx";
		}

		public static bool  isMgz(string fileFormat)
		{
			return fileFormat == ".mgz";
		}

		public static bool  isMsx(string fileFormat)
		{
			return fileFormat == ".msx";
		}

		public static bool  isAoe2Record(string fileFormat)
		{
			return fileFormat == ".aoe2record";
		}

		public static RecordedGame analyseGameROR(List<byte> headerByteList, List<byte> bodyByteList, string fileName, string fileFormat)
		{
			int operationType;
			int playerIndex; // multipurpose
			int currentTime = 0;
			int unitType; // multipurpose
			byte[] tempByteArray; // multipurpose
			int messageCount;
			Player player;
			Team team;
			List<ChatMessage> pregameChat = new List<ChatMessage>();

			// Body Analyser variables
			byte[] bodyByteArray = bodyByteList.ToArray();
			List<TrainCommand> trainingOrdersAI = new List<TrainCommand>();
			List<TributeCommand> tributeOrders = new List<TributeCommand>();
			SummaryAchievement summary;
			EconAchievement economy;
			SocialAchievement society;
			TechAchievement technology;
			MilitaryAchievement military;

			List<Team> teams = new List<Team>();
			Dictionary<int, Player> players = new Dictionary<int, Player>();
			byte[] headerByteArray = headerByteList.ToArray();
			Dictionary<string, string> introMessages = new Dictionary<string, string>();

			int position = 0;

			RecordedGame recordedGame = new RecordedGame();

			int length = headerByteList.Count;

			string versionString = Encoding.ASCII.GetString(headerByteList.GetRange(0, 8).ToArray()).Trim();
			position += 8;
			versionString = versionString.Substring(versionString.Length - 1) == "\0" ? versionString.Substring(0, versionString.Length - 1) : versionString;
			double subVersionConstant = Math.Round(BitConverter.ToSingle(headerByteArray, position), 2);
			position += 4;
			int versionConstant = GameVersion.getVersionConstant(versionString, subVersionConstant);
			recordedGame.setSubVersion(subVersionConstant);
			recordedGame.setVersion(versionConstant);
			position = 8;


			int triggerInfoPos = Utility.IndexOf(headerByteList, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length;

			int gameSettingsPos = Utility.LastIndexOf(headerByteList.GetRange(0, triggerInfoPos), GameConstants.SEPARATOR) + GameConstants.SEPARATOR.Length;

			byte[] scenarioSeparator = isAoK(versionConstant) ? GameConstants.AOK_SEPARATOR : isAoe2Record(fileFormat) ? GameConstants.AOE2_RECORD_SCENARIO_SEPARATOR : GameConstants.SCENARIO_CONSTANT;

			int scenarioHeaderPos = Utility.LastIndexOf(headerByteList.GetRange(0, gameSettingsPos), scenarioSeparator) + 4;

			position = 20;

			if (BitConverter.ToInt32(headerByteArray, position) != 1)
				position += 4 * 4;
			else
				position += 28;

			// Difficulty Level
			recordedGame.setDifficultyLevel(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Map Size
			recordedGame.setMapSize(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// MAP ID
			//recordedGame.setMapId(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Map Visibility
			recordedGame.setMapVisibility(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Victory Condition
			int victoryCondition = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			// Starting Resources
			recordedGame.setResourceLevel(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Starting Age
			recordedGame.setStartingAge(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Ending Age
			recordedGame.setEndingAge(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Game Type
			recordedGame.setGameType(BitConverter.ToInt32(headerByteArray, position));
			position += 4;


			position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;
			position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

			// Game Speed
			recordedGame.setGameSpeed((int)(100 * BitConverter.ToSingle(headerByteArray, position)));
			position += 4;

			// Treaty Length
			recordedGame.setTreatyLength(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Pop Limit
			recordedGame.setPopLimit(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Player Count
			int playerCount = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			// Unknwon
			position += 4;

			// Time Limit OR Score Limit
			int victoryAmount = BitConverter.ToInt32(headerByteArray, position);
			recordedGame.setVictory(victoryCondition, victoryAmount);
			position += 4;

			position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

			// Unknown
			position++;

			// Unknown
			position++;

			// Team Together
			recordedGame.setTeamTogether(headerByteArray[position] == 0);
			position++;

			// All Tech
			recordedGame.setAllTech(headerByteArray[position] == 1);
			position++;

			// Unknown
			position++;

			// Lock Team
			recordedGame.setLockDiplomacy(headerByteArray[position] == 1);
			position++;

			// Unknown 6 bytes

			position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

			int human;
			for (int i = 0; i < 8; i++)
			{
				if (BitConverter.ToInt32(headerByteArray, position) == 3 && BitConverter.ToInt32(headerByteArray, position + 10) != 0)
				{
					position += 4;

					player = new Player();

					// Colour
					player.colourId = BitConverter.ToInt32(headerByteArray, position) + 1;
					position += 4;

					// FF
					position++;

					player.teamIndex = headerByteArray[position] - 1;
					position++;
							

					position += 9;

					player.setCivilisation(headerByteArray[position]);
					position++;

					position += 12;

					tempByteArray = headerByteList.GetRange(position, 2).ToArray();
					if (!BitConverter.IsLittleEndian)
						Array.Reverse(tempByteArray);
					length = (int)BitConverter.ToUInt16(tempByteArray, 0);
					position += 2;

					// -60-0A
					position += 2;

					if (length > 0 && Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim() != "")
					{
						player.name = Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray());
						position += (int)length;
					}
					else
					{
						player.name = "";
					}

					human = BitConverter.ToInt32(headerByteArray, position);
					position += 4;

					// Unknown, probably position
					position += 8;

					// Index
					player.index = BitConverter.ToInt32(headerByteArray, position);
					position += 4;

					player.isHuman = human == 0x02;
					player.isSpectator = human == 0x06;

					if (human != 0 && human != 1)
					{
						if (!player.isSpectator)
						{
							if (player.teamIndex != 0)
							{
								if (recordedGame.teams == null)
								{
									recordedGame.teams = new List<Team>();
									team = new Team();
									team.index = player.teamIndex;
									team.addPlayer(player.index);
									recordedGame.teams.Add(team);
								}
								else if (recordedGame.teams.Exists(t => t.index == player.teamIndex))
									recordedGame.teams.First(t => t.index == player.teamIndex).addPlayer(player.index);
								else
								{
									team = new Team();
									team.index = player.teamIndex;
									team.addPlayer(player.index);
									recordedGame.teams.Add(team);
								}
							}
							else
							{
								team = new Team();
								team.index = player.teamIndex;
								team.addPlayer(player.index);
								recordedGame.teams.Add(team);
							}

							player.teamListIndex = recordedGame.teams.Count - 1;
							players[player.index] = player;
						}
						else
						{
							recordedGame.spectators.Add(player);
						}
					}
				}
				else
				{
					//-03-00-00-00-07-00-00-00-FF-01-00-00-00-00-00-01-00-00-00-0F-00-00-00-00-00-60-0A-00-00-00-60-0A-00-00-60-0A-01-00-00-00-00-00-00-00-00-00-00-00-FF-FF-FF-FF
					position += 52;
				}
			}

			// Unknown -00-00-00-00-00-00-00-00-00-01-01-01
			//position += 12;

			position = Utility.IndexOf(headerByteList, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

			// Unknown 12 "00" bytes "60 0A"
			position += 14;

			position += 8;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			// -60-0A
			position += 2;

			// Map File Name
			if (length > 0 && Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim() != "")
			{
				recordedGame.setMapFileName(Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
				position += length;
			}

			position += 12;

			position += 24;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			// -60-0A
			position += 2;

			// Lobby Name
			if (length > 0 && Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim() != "")
			{
				recordedGame.setLobbyName(Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim());
				position += (int)length;
			}

			// -00-00-60-0A
			position += 4;

			position += 12;

			// Miscel + Game Speed + Miscel
			position += 53;

			// Owner
			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			int pov = (int)BitConverter.ToUInt16(tempByteArray, 0) - 1;
			position += 2;
			if (players.ContainsKey(pov))
				players[pov].owner = true;

			// Player Count
			//int numPlayers = headerByteArray[position++] - 1; // #0 is GAIA
			position += 2;

			// Game Mode
			//tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			//if (!BitConverter.IsLittleEndian)
			//	Array.Reverse(tempByteArray);
			//recordedGame.setGameMode((int)BitConverter.ToUInt16(tempByteArray, 0));
			//position += 2;

			// all 00 bytes
			position += 61;
			//position += 29;
			// Map
			int mapSizeX = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			int mapSizeY = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			if (mapSizeX >= 10000 || mapSizeY >= 10000 || mapSizeX <= 0 || mapSizeY <= 0)
			{
				position -= 8;
				position += 29;
				mapSizeX = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				mapSizeY = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				if (mapSizeX >= 10000 || mapSizeY >= 10000 || mapSizeX <= 0 || mapSizeY <= 0)
				{
					throw new Exception("Invalid Map Size.");
				}
			}

			recordedGame.setMapXSize(mapSizeX);
			recordedGame.setMapYSize(mapSizeY);
			recordedGame.setMapTiles();

			int numMapZones = BitConverter.ToInt32(headerByteArray, position);
			position += 4;

			for (int i = 0; i < numMapZones; i++)
			{
				position += 2048 + mapSizeX * mapSizeY * 2;

				int numFloats = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				position += numFloats * 4 + 4;
			}

			// Map Visibility, Fog of War
			position += 2;

			// Get Map Terrain and Elevation
			for (int x = 0; x < mapSizeX; x++)
			{
				for (int y = 0; y < mapSizeY; y++)
				{
					recordedGame.setMapTile(x, y, headerByteArray[position], headerByteArray[position + 1]);
					position += 2;
				}
			}

			// Unknown
			int numData = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			position += numData * 4;
			position += 4; // testing
			for (int i = 0; i < numData; i++)
			{
				position += BitConverter.ToInt32(headerByteArray, position) * 8 + 4;
			}

			// Visibility Map
			int mapSizeX2 = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			int mapSizeY2 = BitConverter.ToInt32(headerByteArray, position);
			position += 4;
			position += mapSizeX2 * mapSizeY2 * 4; // map data
			position += 4;

			position += 8;
			//position += 8;

			Player GAIA = new Player("GAIA");

			for (int i = -1; i < players.Count; i++) // starts with GAIA
			{
				if (i == -1)
					player = GAIA;
				else if (players.ContainsKey(i + 1))
					player = players[i + 1];
				else
					player = new Player();

				// -01-0B-03
				position += 3;

				// (player count) bytes + 00 00 00 00
				position += players.Count + 4;

				// diplomacy table
				position += 4 * 8;

				// 00 00 00 00 and ?? byte
				position += 4;
				// skip playername
				tempByteArray = headerByteList.GetRange(position, 2).ToArray();
				if (!BitConverter.IsLittleEndian)
					Array.Reverse(tempByteArray);
				int playerNameLen = (int)BitConverter.ToUInt16(tempByteArray, 0);
				position += 2;
				position += playerNameLen;


				position += 1; // always 22?
				int numResources = BitConverter.ToInt32(headerByteArray, position);
				position += 4;
				position += 1; // always 33?
				int resourcesEnd = position + 4 * numResources;

				if (player != null)
				{
					player.setInitialFood((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialWood((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialStone((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialGold((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialHeadRoom((int)BitConverter.ToSingle(headerByteArray, position)); // Housing - Pop
					position += 4;

					position += 4;

					// Post-Imperial Age
					player.setInitialAge((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialCivilianPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					player.setInitialMilitaryPopulation((int)BitConverter.ToSingle(headerByteArray, position));
					position += 4;

					position = resourcesEnd + 1;

					player.setInitialCameraLocation(Math.Round(BitConverter.ToSingle(headerByteArray, position), 2), Math.Round(BitConverter.ToSingle(headerByteArray, position + 4), 2));
					position += 8;
				}
				else
				{
					position = resourcesEnd + 1;
					position += 5;
					position += 1 + 3 + 1;
				}


				if (isTrial(versionConstant))
					position += 4;

				// Getting exist object positions
				int existObjectPos = Utility.IndexOf(headerByteList, GameConstants.EXIST_OBJECT_SEPARATOR, position);
				if (existObjectPos < 0)
					throw new Exception("Could not find existObjectSeparator");
				position = existObjectPos + GameConstants.EXIST_OBJECT_SEPARATOR.Length;

				// PlayerObjectListAnalser
				bool done = false;
				int separatorPos;
				GameUnit tempUnit = new GameUnit();
				List<GameUnit> gaiaUnits = new List<GameUnit>();
				List<GameUnit> playerUnits = new List<GameUnit>();
				while (!done)
				{
					tempUnit = new GameUnit();
					int objectType = headerByteArray[position];
					tempUnit.objectType = objectType;
					tempUnit.owner = objectType == 0 ? 0 : headerByteArray[position + 1];
					position += 2;

					tempByteArray = headerByteList.GetRange(position, 2).ToArray();
					if (!BitConverter.IsLittleEndian)
						Array.Reverse(tempByteArray);
					tempUnit.id = (int)BitConverter.ToUInt16(tempByteArray, 0);
					position += 2;

					switch (objectType)
					{
						case UnitType.UT_EYECANDY:
							if (AoEResourcePack.isGaiaUnit(tempUnit.id))
							{
								int restore = position;
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								position = restore;
								gaiaUnits.Add(tempUnit);
							}
							if (headerByteArray[position] == 0)
								// testing
								position += 37;

							position += 66;

							break;

						case UnitType.UT_FLAG:
							if (isHDEdition(versionConstant))
								position += 3;

							if (isMgx(fileFormat))
							{
								position += 59;
								position += headerByteArray[position] == 2 ? 39 : 5;
							}
							else
								position += 103 - 4;

							break;

						case UnitType.UT_DEAD_OR_FISH:
							// TODO: details needed
							if (headerByteArray[position] != 0)
							{
								if (headerByteArray[position + 80] == UnitType.UT_EYECANDY || headerByteArray[position + 80] == UnitType.UT_FLAG || headerByteArray[position + 80] == UnitType.UT_DEAD_OR_FISH || headerByteArray[position + 80] == UnitType.UT_BIRD || headerByteArray[position + 80] == UnitType.UT_UNKNOWN || headerByteArray[position + 80] == UnitType.UT_PROJECTILE || headerByteArray[position + 80] == UnitType.UT_CREATABLE || headerByteArray[position + 80] == UnitType.UT_BUILDING)
									position += 80;
								else
									position += 97;
							}
							else
								position += 140;

							//position += headerByteArray[position] == 0 ? 140 : 80;
							//position += headerByteArray[position] == 0 ? 140 : 97;
							break;

						// TODO: Object Type 40 and 50 not included

						case UnitType.UT_PROJECTILE:
							// readProjectile not implemented
							//position += 23;
							position += 124;
							break;

						case UnitType.UT_CREATABLE:
							if (AoEResourcePack.isGaiaUnit(tempUnit.id))
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								gaiaUnits.Add(tempUnit);
							}
							else if (tempUnit.owner != 0)
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								playerUnits.Add(tempUnit);
							}

							if (isMgx(fileFormat))
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.AOK_OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.AOK_OBJECT_END_SEPARATOR.Length;
							}
							else
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.OBJECT_END_SEPARATOR.Length;
							}

							if (separatorPos < 0)
								throw new Exception("Could not find OBJECT_END_SEPARATOR");


							break;

						case UnitType.UT_BUILDING:
							if (tempUnit.owner > 0)
							{
								position += 19;
								tempUnit.positionX = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								tempUnit.positionY = Math.Round(BitConverter.ToSingle(headerByteArray, position));
								position += 4;

								playerUnits.Add(tempUnit);
							}

							if (isMgx(fileFormat))
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.AOK_OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.AOK_OBJECT_END_SEPARATOR.Length;
								position++;
							}
							else
							{
								separatorPos = Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_END_SEPARATOR);
								position += separatorPos + GameConstants.OBJECT_END_SEPARATOR.Length;
							}

							if (separatorPos < 0)
								throw new Exception("Could not find OBJECT_END_SEPARATOR");


							position += 126;

							if (isHDPatch4(versionConstant, subVersionConstant))
								position -= 3;

							break;

						case 00:
							position -= 4;
							if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.GAIA_INFO_END_SEPARATOR) == 0)
							{
								position += GameConstants.GAIA_INFO_END_SEPARATOR.Length;
								done = true;
								break;
							}
							else if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.PLAYER_INFO_END_SEPARATOR) == 0)
							{
								position += GameConstants.PLAYER_INFO_END_SEPARATOR.Length;
								done = true;
								break;
							}
							else if (Utility.IndexOf(headerByteList.GetRange(position, headerByteList.Count - position), GameConstants.OBJECT_MID_SEPARATOR_GAIA) == 0)
							{
								position += GameConstants.OBJECT_MID_SEPARATOR_GAIA.Length;
							}
							else
							{
								throw new Exception("Could not find GAIA object separator");
							}

							break;
						default:
							throw new Exception("Unknown object type " + objectType.ToString());
					}
				}
				//player.units = playerUnits;
			}

			position = scenarioHeaderPos;
			// 4096 00 bytes
			position += 4096;
			// 16 -FE-FF-FF-FF
			position += 16 * 4;
			// String Table, 16 rows, 4 Int each
			position += 16 * 4 * 4;
			// -01-00-00-00-00-00-00-00-00-00-00
			position += 11;
			// 6 -FE-FF-FF-FF
			position += 6 * 4;

			tempByteArray = headerByteList.GetRange(position, 2).ToArray();
			if (!BitConverter.IsLittleEndian)
				Array.Reverse(tempByteArray);
			length = (int)BitConverter.ToUInt16(tempByteArray, 0);
			position += 2;

			tempByteArray = headerByteList.GetRange(position, length).ToArray();

			int temp1;
			int temp2 = 0;
			string key;
			string value;

			temp1 = Utility.IndexOf(tempByteArray.ToList(), new byte[] { 0x3A });
			while (temp1 > 0)
			{
				key = Encoding.ASCII.GetString(tempByteArray.ToList().GetRange(temp2, temp1 - temp2).ToArray()).Trim();
				temp2 = temp1 + 1;
				temp1 = Utility.IndexOf(tempByteArray.ToList(), new byte[] { 0x0A }, temp2);
				temp1 = temp1 == -1 ? length - 1 : temp1;
				value = Encoding.ASCII.GetString(tempByteArray.ToList().GetRange(temp2, temp1 - temp2).ToArray()).Trim();
				temp2 = temp1 + 1;
				introMessages[key] = value;

				temp1 = Utility.IndexOf(tempByteArray.ToList(), new byte[] { 0x3A }, temp2);
			}

			if (introMessages.ContainsKey("Location"))
				recordedGame.setMapId(MapType.getIdByName(introMessages["Location"].ToUpper()));

			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
			position = Utility.IndexOf(headerByteList, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;

			// 8 Integers
			position += 32;

			// 01-00-00-00
			position += 4;

			// Game Lobby
			for (int i = 0; i < 9; i++)
			{
				if (BitConverter.ToInt32(headerByteArray, position) < 0)
					position += 18;
				else
				{
					// index, isHuman?
					position += 8;
					length = BitConverter.ToInt32(headerByteArray, position);
					position += 4;
					if (length > 0)
						position += length;
				}
			}

			// 36 00 bytes
			position += 36;
			// player count
			position += 4;
			// 85-EB-91-3F
			position += 4;
			// -00-00-00-00-00-00-3C
			position += 7;
			// 2420 00 bytes
			position += 2420;

			// Victory Settings
			// 01-00-00-00
			position += 4;
			//recordedGame.setVictory(BitConverter.ToInt32(headerByteArray, position), victoryCondition);
			position += 4;
			recordedGame.setRelicVictory(BitConverter.ToInt32(headerByteArray, position));
			position += 4;

			// Initialise Players

			position = gameSettingsPos + 32;


			// Skip GAIA
			//position += 20;

			//for (int i = 0; i < 8; i++)
			//{
			//	if (BitConverter.ToInt32(headerByteArray, position) < 0)
			//	{
			//		position += (12 + 6);
			//	}
			//	else {

			//		player = new Player();
			//		player.index = BitConverter.ToInt32(headerByteArray, position);
			//		position += 4;
			//		human = BitConverter.ToInt32(headerByteArray, position);
			//		position += 4;
			//		length = (int)BitConverter.ToUInt32(headerByteArray, position);
			//		position += 4;
			//		if (length > 0 && Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray()).Trim() != "")
			//		{
			//			player.name = Encoding.ASCII.GetString(headerByteList.GetRange(position, length).ToArray());
			//			position += (int)length;
			//		}
			//		else
			//		{
			//			player.name = "";
			//		}

			//		player.isHuman = human == 0x02;
			//		player.isSpectator = human == 0x06;

			//		if (human != 0 && human != 1)
			//		{
			//			players[player.index] = player;
			//		}
			//	}
			//}

			// Skip to Ending Blocks
			position = Utility.LastIndexOf(headerByteList, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length;
			position += 5;

			// Read Teams
			for (int i = 0; i < 8; i++)
			{
				//if (players.ContainsKey(i + 1))
					//players[i + 1].setTeamIndex(headerByteArray[position]);
				
				position++;
			}

			recordedGame.setMapVisibility(BitConverter.ToInt32(headerByteArray, position));

			position += 8;

			recordedGame.setMapSize(BitConverter.ToInt32(headerByteArray, position));

			position += 4;

			recordedGame.setPopLimit(BitConverter.ToInt32(headerByteArray, position));

			position += 4;

			//recordedGame.setGameType(headerByteArray[position]);

			position++;

			recordedGame.setGameMode(headerByteArray[position]);

			position += 6;

			string chat = "";
			messageCount = BitConverter.ToInt32(headerByteArray, position) - 1;
			//position += 8;
			position += 4;

			//for (int i = 0; i < messageCount - 1; i++)
			//{
			//	length = BitConverter.ToInt32(headerByteArray, position);
			//	position += 4;

			//	if (length > 0)
			//	{
			//		chat = Encoding.ASCII.GetString(headerByteList.GetRange(position, length - 1).ToArray()).Trim();
			//		position += length;

			//		string target = "";
			//		if (chat[3] == '<' && (chat.IndexOf('>') <= 8))
			//			target = chat.Substring(4, (chat.IndexOf('>') - 4));

			//		// pre-game chat messages are stored as "@#%dPlayerName: Message",
			//		// where %d is a digit from 1 to 8 indicating player's index (or
			//		// colour)

			//		if (int.TryParse(chat[2].ToString(), out playerIndex))
			//		{
			//			if (chat.Substring(0, 2) == "@#" && playerIndex >= 1 && playerIndex <= 8)
			//			{
			//				pregameChat.Add(new ChatMessage(-1, playerIndex, chat.Substring(chat.IndexOf(':') + 2).Trim(), target));
			//			}
			//		}
			//	}
			//}

			//recordedGame.addPreGameChat(pregameChat);

			recordedGame.players = players;

			//body section

			position = 0;
			int next = -1;

			while (position < bodyByteArray.Length - 3)
			{
				operationType = 0;

				operationType = BitConverter.ToInt32(bodyByteArray, position);
				position += 4;

				if (operationType == CommandType.OP_META || operationType == CommandType.OP_META2)
				{
					int command = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;

					if (command == CommandType.META_GAME_START)
					{
						position += isMgl(fileFormat) ? 32 : 20;
					}
					else if (command == CommandType.META_CHAT)
					{
						length = BitConverter.ToInt32(bodyByteArray, position);
						position += 4;

						if (length > 0)
						{
							//chat = Encoding.ASCII.GetString(bodyByteList.GetRange(position, length).ToArray()).Trim();
							position += length;

							//if (int.TryParse(chat[2].ToString(), out playerIndex))
							//{
							//	if (chat.Substring(0, 2) == "@#" && playerIndex >= 1 && playerIndex <= 8)
							//	{
							//		string target = "";
							//		if (chat[3] == '<' && (chat.IndexOf('>') <= 8))
							//			target = chat.Substring(4, (chat.IndexOf('>') - 4));
							//		/*
							//                             if (chat.Substring(3,2) == "--" && chat.Substring(chat.Length - 2) == "--")
							//                             {
							//                                 // --Warning: You are under attack --
							//                             }
							//                             else if (players.Exists(p => p.index == playerIndex))
							//                             {

							//                             }
							//                             */
							//		recordedGame.addChatMessage(new ChatMessage(currentTime, playerIndex, chat.Substring(chat.IndexOf(':') + 2), target));
							//	}
							//}
						}
					}
				}
				else if (operationType == CommandType.OP_SYNC)
				{
					currentTime = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;
					if (BitConverter.ToInt32(bodyByteArray, position) == 0)
					{
						position += 28;
					}
					position += 12 + 4; // 4 for the if condition checking
				}
				else if (operationType == CommandType.OP_DEFEATED)
				{

				}
				else if (operationType == CommandType.OP_COMMAND)
				{
					length = BitConverter.ToInt32(bodyByteArray, position);
					position += 4;
					next = position + length;
					int command = bodyByteArray[position];
					position++;

					switch (command)
					{
						case CommandType.COMMAND_RESIGN:
							playerIndex = bodyByteArray[position++];
							position += 2;
							//playerNumber = bodyByteArray[position + 1];
							//disconnected = bodyByteArray[position + 2];
							currentTime = BitConverter.ToInt32(bodyByteArray, position);
							if (recordedGame.isPlayer(playerIndex))
							{
								if (!recordedGame.isPlayerResigned(playerIndex))
								{
									recordedGame.setPlayerResign(playerIndex, currentTime);
									recordedGame.addChatMessage(new ChatMessage(currentTime, playerIndex, recordedGame.getPlayerName(playerIndex) + " resigned", "All"));
									recordedGame.teams[recordedGame.getPlayerTeam(playerIndex)].updatePlayer(playerIndex, false);
								}
							}
							break;

						case CommandType.COMMAND_RESEARCH:
							position += 3;
							int buildingId = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							playerIndex = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							int researchId = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							// FFFFFFFF
							position += 4;

							currentTime = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;

							//tempPlayer = players[playerIndex];
							if (recordedGame.isPlayer(playerIndex))
							{
								switch (researchId)
								{
									case ResearchType.RESEARCH_FEUDAL:
										recordedGame.setPlayerFeudalTime(playerIndex, currentTime);
										break;

									case ResearchType.RESEARCH_CASTLE:
										recordedGame.setPlayerCastleTime(playerIndex, currentTime);
										break;

									case ResearchType.RESEARCH_IMPERIAL:
										recordedGame.setPlayerImperialTime(playerIndex, currentTime);
										break;
								}

								recordedGame.addPlayerResearch(playerIndex, researchId, currentTime);
							}

							break;

						// Train Unit
						case CommandType.COMMAND_TRAIN:
							playerIndex = bodyByteArray[position++];
							//position += 3;
							//buildingId = BitConverter.ToInt32(bodyByteArray, position);
							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							buildingId = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							int amount = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							unitType = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							position += 6;
							currentTime = BitConverter.ToInt32(bodyByteArray, position);

							recordedGame.addTrainCommand(-1, unitType, amount, currentTime);
							break;

						// Train Single Unit (AI)
						case CommandType.COMMAND_TRAIN_SINGLE:
							position += 9;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							unitType = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							trainingOrdersAI.Add(new TrainCommand(-1, unitType, 1, currentTime));
							break;

						// Building
						case CommandType.COMMAND_BUILD:
							position++;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							playerIndex = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							position += 8;

							tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
							if (!BitConverter.IsLittleEndian)
								Array.Reverse(tempByteArray);
							buildingId = (int)BitConverter.ToUInt16(tempByteArray, 0);
							position += 2;

							buildingId = AoEResourcePack.normaliseUnit(buildingId);

							recordedGame.addBuildCommand(playerIndex, buildingId, currentTime);
							break;

						// Tribute
						case CommandType.COMMAND_TRIBUTE:
							playerIndex = bodyByteArray[position];
							int payeeId = bodyByteArray[position + 1];
							int resourceId = bodyByteArray[position + 2];
							position += 3;

							if (recordedGame.isPlayer(playerIndex) && recordedGame.isPlayer(payeeId))
							{
								amount = (int)Math.Round(BitConverter.ToSingle(bodyByteArray, position));
								position += 4;
								int tax = (int)Math.Round(BitConverter.ToSingle(bodyByteArray, position));
								position += 4;
								currentTime = BitConverter.ToInt32(headerByteArray, position);
								tributeOrders.Add(new TributeCommand(playerIndex, payeeId, resourceId, amount, tax, currentTime));
							}
							else
								position += 8;

							break;

						// Multiplayer postgame data in UP1.4 RC2+
						case CommandType.COMMAND_POSTGAME:

							position += 3; // skip body command metadata
							position += 32; // scenariofilename from bodyString
							playerCount = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;
							int gameDuration = BitConverter.ToInt32(bodyByteArray, position);
							position += 4;
							bool allowCheat = bodyByteArray[position++] == 1;
							bool isCompleted = bodyByteArray[position++] == 1;
							position += 10; // zeros
							double u0 = Math.Round(BitConverter.ToSingle(bodyByteArray, position));
							position += 4;
							int mapSize = bodyByteArray[position++];
							//int mapId = bodyByteArray[position++];
							int populationLimit = bodyByteArray[position++];
							position++;
							position += 1; // victory
							position += 1; // starting age
							int resources = bodyByteArray[position++];
							bool allTech = bodyByteArray[position++] == 1;
							bool teamTogether = bodyByteArray[position++] == 1;
							bool isDeathMatch = bodyByteArray[position++] == 1;
							bool isRegicide = bodyByteArray[position++] == 1;
							int u1 = bodyByteArray[position++];
							bool lockTeam = bodyByteArray[position++] == 1;
							bool lockSpeed = bodyByteArray[position++] == 1;
							int u2 = bodyByteArray[position++];

							// Postgame Data
							for (int i = 0; i < 8; i++)
							{
								summary = new SummaryAchievement();
								military = new MilitaryAchievement();
								economy = new EconAchievement();
								society = new SocialAchievement();
								technology = new TechAchievement();
								playerIndex = recordedGame.getPlayerIndex(Encoding.ASCII.GetString(bodyByteList.GetRange(position, 16).ToArray()).Trim());
								summary.playerName = Encoding.ASCII.GetString(bodyByteList.GetRange(position, 16).ToArray()).Trim();
								position += 16;

								for (int j = 0; j < 8; j++)
								{
									//tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									//if (!BitConverter.IsLittleEndian)
									//	Array.Reverse(tempByteArray);
									//tempAchievement.totalScores[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								summary.isVictory = bodyByteArray[position++] == 1;
								if (summary.isVictory)
								{
									recordedGame.addWinner(i);
								}
								summary.civId = bodyByteArray[position++];
								summary.colourId = bodyByteArray[position++];
								summary.teamIndex = bodyByteArray[position++];
								summary.alliesCount = bodyByteArray[position++];
								position++; // -1
								summary.isMVP = bodyByteArray[position++] == 1;
								position += 3; // Padding
								summary.result = bodyByteArray[position++];
								position += 3; // Padding

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								summary.militaryScore = (int)BitConverter.ToUInt16(tempByteArray, 0);
								military.score = summary.militaryScore;
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsKilled = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.hitPointsKilled = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsLost = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.buildingsRazed = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.hitPointsRazed = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.buildingsLost = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								military.unitsConverted = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									military.playerUnitsKilled[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									military.playerBuildingsRazed[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.U0 = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								economy.foodCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.woodCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.stoneCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								economy.goldCollected = BitConverter.ToInt32(bodyByteArray, position);
								position += 4;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tributeSent = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tributeReceived = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.tradeProfit = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								economy.relicGold = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								for (int j = 0; j < 8; j++)
								{
									tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
									if (!BitConverter.IsLittleEndian)
										Array.Reverse(tempByteArray);
									economy.playerTributeSent[j] = (int)BitConverter.ToUInt16(tempByteArray, 0);
									position += 2;
								}

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								technology.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								technology.U0 = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								technology.feudalTime = BitConverter.ToInt32(bodyByteArray, position);
								recordedGame.setPlayerFeudalTime(i, BitConverter.ToInt32(bodyByteArray, position));
								position += 4;

								technology.castleTime = BitConverter.ToInt32(bodyByteArray, position);
								recordedGame.setPlayerCastleTime(i, BitConverter.ToInt32(bodyByteArray, position));
								position += 4;

								technology.imperialTime = BitConverter.ToInt32(bodyByteArray, position);
								recordedGame.setPlayerImperialTime(i, BitConverter.ToInt32(bodyByteArray, position));
								position += 4;

								technology.mapExploration = bodyByteArray[position++];

								technology.researchCount = bodyByteArray[position++];

								technology.researchPercent = bodyByteArray[position++];

								position++; // padding

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								society.score = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								society.wonderCount = bodyByteArray[position++];

								society.castleCount = bodyByteArray[position++];

								society.relicCaptured = bodyByteArray[position++];

								society.U0 = bodyByteArray[position++];

								tempByteArray = bodyByteList.GetRange(position, 2).ToArray();
								if (!BitConverter.IsLittleEndian)
									Array.Reverse(tempByteArray);
								society.villagerHigh = (int)BitConverter.ToUInt16(tempByteArray, 0);
								position += 2;

								position += 84; // Padding

								recordedGame.setPlayerSummaryAchievement(playerIndex, summary);
								recordedGame.setPlayerEconAchievement(playerIndex, economy);
								recordedGame.setPlayerSocialAchievement(playerIndex, society);
								recordedGame.setPlayerTechAchievement(playerIndex, technology);
							}

							break;
							
						//case 0x81:
							//position += 13;
							//currentTime = BitConverter.ToInt32(bodyByteArray, position);
							//break;
							
						default:
							break;
					}

					position = next + 4;
				}
				else
				{
					;
				}
			}

			recordedGame.setVictors();

			return recordedGame;
		}

	}
}
