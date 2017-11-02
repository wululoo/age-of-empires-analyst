using System;
using System.Collections.Generic;
using System.Text;

namespace AgeOfEmpiresLibrary.Classes
{
    public static class Parser
    {

        public static GameRoom getGameRoomWK(byte[] headerByteArray)
        {

            // Temp variables
            // ----------
            Player player = new Player();
            int playerId;
            int playerHuman;
            int playerTeamId;
            int playerColour;
            int playerCivilisation;
            string playerName;
            string playerName2;
            byte[] tempByteArray;
            int length;
            int mapSize;
            // ----------

            GameRoom room = new GameRoom();

            int position = 0;

            string versionString = Encoding.UTF8.GetString(headerByteArray, 0, 8).Trim();
            position += 8;
            versionString = versionString.Substring(versionString.Length - 1) == "\0" ? versionString.Substring(0, versionString.Length - 1) : versionString;
            double subVersionConstant = Math.Round(BitConverter.ToSingle(headerByteArray, position), 2);
            position += 4;
            int versionConstant = GameVersion.getVersionConstant(versionString, subVersionConstant);
            room.setVersion(versionConstant, subVersionConstant);

            room.setAI(BitConverter.ToInt32(headerByteArray, position) == 1);
            position += 4;

            // UNKNOWN
            position += 4 * 4;

            // A2-45-36-3E-00-00-00-00-00-E4-3F
            position += 12;

            // UNKNOWN
            position += 5;

            // FE-FF-FF-FF
            position += 4;

            // UNKNOWN
            position += 8;

            // UNKNOWN SWITCH * 2
            position += 2;

            // PLAYER COUNT
            // -1 for GAIA
            room.setPlayerCount(headerByteArray[position] - 1);

            // UNKNOWN SWITCH * 4
            // POSSIBLY AEGIS, CHEAT, AND GAME MODE
            position += 4;

            // FF-FF-FF-FF-FF-FF-FF-FF-FF-FF-FF-FF
            position += 12;

            // 00-00-00-00-00-00-01-00-00-00-00-00-00-00
            position += 14;

            // UNKNOWN
            // B2-00-00-00 for player ???
            position += 32;

            // MAP SIZE X & Y
            position += 8;

            int triggerInfoPos = Utility.IndexOf(headerByteArray, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length;

            int gameSettingsPos = Utility.LastIndexOf(Utility.SubArray(headerByteArray, 0, triggerInfoPos), GameConstants.SEPARATOR2) + GameConstants.SEPARATOR2.Length;

            byte[] scenarioSeparator = GameConstants.SCENARIO_CONSTANT;

            int scenarioHeaderPos = Utility.LastIndexOf(Utility.SubArray(headerByteArray, 0, gameSettingsPos), scenarioSeparator) + 4;

            position = scenarioHeaderPos;

            // MAP ID

            position += 4;

            // DIFFICULTIES
            room.setDifficulty(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // LOCK TEAMS
            room.setDiplomacyLock(BitConverter.ToInt32(headerByteArray, position) == 1);
            position += 4;

            // 9 PLAYERS
            // 1st POV
            //     index (4)
            //     human (4)
            //     length of name (4)
            //     name (var)

            playerId = BitConverter.ToInt32(headerByteArray, position);
            position += 4;
            playerHuman = BitConverter.ToInt32(headerByteArray, position);
            position += 4;
            length = BitConverter.ToInt32(headerByteArray, position);
            position += 4;
            // POV
            playerName2 = Encoding.Unicode.GetString(
                headerByteArray, position, length).Trim();

            position += length;

            for (int i = 0; i < 8; i ++)
            {
                playerId = BitConverter.ToInt32(headerByteArray, position);
                position += 4;
                playerHuman = BitConverter.ToInt32(headerByteArray, position);
                position += 4;
                length = BitConverter.ToInt32(headerByteArray, position);
                position += 4;
                playerName = Encoding.Unicode.GetString(
                    headerByteArray, position, length).Trim();

                position += length;

                if (length > 1 && playerHuman == 2)
                {
                    room.addPlayer(new Player(playerId, playerName, playerId, 0, 0, 0));
                }
            }

            position = triggerInfoPos;

            // HERE EXIST 5 SWITCHES
            position += 5;

            // HERE EXIST 8 SWITCHES
            // PLAYER TEAMS
            position += 8;

            // MAY BE MULTIPLAYER TAG?
            room.setMultiplayer(headerByteArray[position] == 1);
            position++;

            // HERE EXIST 2 * 4 BYTES SWITCHES
            position += 2 * 4;

            // MAP SIZE
            position += 4;

            // HERE EXIST 1 * 4 BYTES SWITCH
            // WHAT CAN 08-00-00-00 BE?
            position += 4;

            // HERE EXIST 2 SWITCHES, PROBABLY SIZE, AND VISIBILITY OF MAP
            position += 2;

            // MESSAGE COUNT + 1
            position += 4;

            // 00-00-00-00
            position += 4;
            
            // MESSAGES
            //     length (4)
            //     message (var)
            //     end with 00

            return null;


        }

        public static GameRoom getGameRoom(byte[] headerByteArray, string fileFormat)
        {
            // Temp variables
            // ----------
            Player player = new Player();
            int playerId;
            int playerTeamId;
            int playerColour;
            int playerCivilisation;
            string playerName;
            byte[] tempByteArray;
            Createable playerUnit;
            int length;
            int count;
            // ----------

            // Version variables
            // ----------
            bool isMgx = GameVersion.isMgx(fileFormat);
            bool isMgl = GameVersion.isMgl(fileFormat);
            bool isMgz = GameVersion.isMgz(fileFormat);
            bool isMsx = GameVersion.isMsx(fileFormat);
            // ----------

            GameRoom room = new GameRoom();

            int position = 0;

            string versionString = Encoding.UTF8.GetString(headerByteArray, 0, 8).Trim();
            position += 8;
            versionString = versionString.Substring(versionString.Length - 1) == "\0" ? versionString.Substring(0, versionString.Length - 1) : versionString;
            double subVersionConstant = Math.Round(BitConverter.ToSingle(headerByteArray, position), 2);
            position += 4;
            int versionConstant = GameVersion.getVersionConstant(versionString, subVersionConstant);
            room.setVersion(versionConstant, subVersionConstant);
            //position = 8;

            position = 20;

            if (BitConverter.ToInt32(headerByteArray, position) != 1)
                position += 4 * 4;
            else
                position += 28;

            // Difficulty Level
            room.setDifficulty(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // Map Size
            // MAP ID
            // Map Visibility

            room.setMap(BitConverter.ToInt32(headerByteArray, position + 4), 
                        BitConverter.ToInt32(headerByteArray, position),
                        BitConverter.ToInt32(headerByteArray, position + 8));

            position += 12;

            // Victory Condition
            int victoryCondition = BitConverter.ToInt32(headerByteArray, position);
            position += 4;

            // Starting Resources
            room.setResourceLevel(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // Start Age
            room.setStartAge(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // End Age
            room.setEndAge(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // Game Type
            room.setGameType(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;
            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

            // Game Speed
            room.setSpeed((int)(100 * BitConverter.ToSingle(headerByteArray, position)));
            position += 4;

            // Treaty Length
            room.setTreatyLength(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // Pop Limit
            room.setPopulationLimit(BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            // Player Count
            int playerCount = BitConverter.ToInt32(headerByteArray, position);
            position += 4;

            // Unknwon
            position += 4;

            // Time Limit OR Score Limit
            room.setVictorySetting(victoryCondition, BitConverter.ToInt32(headerByteArray, position));
            position += 4;

            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

            // Unknown
            position++;

            // Unknown
            position++;

            // Team Together
            room.setTeamTogether(headerByteArray[position] == 0);
            position++;

            // All Tech
            room.setAllTech(headerByteArray[position] == 1);
            position++;

            // Unknown
            position++;

            // Lock Team
            room.setDiplomacyLock(headerByteArray[position] == 1);
            position++;

            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

            int human;
            for (int i = 0; i < 8; i++)
            {
                if (BitConverter.ToInt32(headerByteArray, position) == 3)
                {
                    position += 4;

                    // Colour
                    playerColour = BitConverter.ToInt32(headerByteArray, position) + 1;
                    position += 4;

                    // FF
                    position++;

                    // Team Index
                    playerTeamId = headerByteArray[position] - 1;
                    position++;


                    position += 9;

                    // Civilisation ID
                    playerCivilisation = headerByteArray[position];
                    position++;

                    position += 3;

                    length = (int)BitConverter.ToUInt16(headerByteArray, position);
                    position += 4; // length + 60 0A

                    position += length + 1;

                    length = (int)BitConverter.ToUInt16(headerByteArray, position);
                    position += 4; // length + 60 0A

                    position += length;

                    length = (int)BitConverter.ToUInt16(headerByteArray, position);

                    position += 2;

                    // -60-0A
                    position += 2;
                    playerName = Encoding.UTF8.GetString(headerByteArray, position, length).Trim();

                    position += length;

                    human = BitConverter.ToInt32(headerByteArray, position);
                    position += 4;

                    // Unknown, probably position
                    position += 8;

                    // Index

                    room.addPlayer(
                        BitConverter.ToInt32(headerByteArray, position), 
                        playerName, playerColour, playerTeamId, 
                        playerCivilisation, human);

                    position += 4;
                }
                else
                {
                    //-03-00-00-00-07-00-00-00-FF-01-00-00-00-00-00-01-00-00-00-0F-00-00-00-00-00-60-0A-00-00-00-60-0A-00-00-60-0A-01-00-00-00-00-00-00-00-00-00-00-00-FF-FF-FF-FF
                    position += 52;
                }
            }

            // Unknown -00-00-00-00-00-00-00-00-00-01-01-01
            //position += 12;

            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR.Length;

            // Unknown 12 "00" bytes "60 0A"
            //position += 14;

            //position += 8;
            room.setRanked(headerByteArray[position] == 1);
            position += 10;

            length = (int)BitConverter.ToUInt16(headerByteArray, position);
            position += 2;

            // -60-0A
            position += 2;

            position += length;

            position += 8;

            length = (int)BitConverter.ToUInt16(headerByteArray, position);
            position += 2;

            // -60-0A
            position += 2;

            position += length;

            position += 12;

            position += 24;

            length = (int)BitConverter.ToUInt16(headerByteArray, position);
            position += 2;

            // -60-0A
            position += 2;

            // Lobby Name
            room.setName(Encoding.UTF8.GetString(headerByteArray, position, length).Trim());
            position += length;

            // -00-00-60-0A
            //position += 4;

            position = Utility.IndexOf(headerByteArray, GameConstants.AOE2_RECORD_HEADER_SEPARATOR_2, position) + GameConstants.AOE2_RECORD_HEADER_SEPARATOR_2.Length;

            position += 4;

            // Skip AI Script
            if (BitConverter.ToInt32(headerByteArray, position) > 0)
            {
                position += 1040846;
            }

            // Miscel + Game Speed + Miscel
            position += 49;

            // Owner
            room.setOwner((int)BitConverter.ToUInt16(headerByteArray, position) - 1);
            position += 2;

            // Player Count
            //int numPlayers = headerByteArray[position++] - 1; // #0 is GAIA
            position += 2;

            // all 00 bytes
            position += 61;

            // Map
            int mapSizeX = BitConverter.ToInt32(headerByteArray, position);
            position += 4;
            int mapSizeY = BitConverter.ToInt32(headerByteArray, position);
            position += 4;

            room.setMapDimension(mapSizeX, mapSizeY);

            int numMapZones = BitConverter.ToInt32(headerByteArray, position);
            position += 4;

            for (int i = 0; i < numMapZones; i++)
            {
                position += 2048 + mapSizeX * mapSizeY * 2;

                //int numFloats = BitConverter.ToInt32(headerByteArray, position);
                //position += 4;
                position += BitConverter.ToInt32(headerByteArray, position) * 4 + 4 + 4;
            }

            // Map Visibility, Fog of War
            position += 2;

            // Get Map Terrain and Elevation
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    room.setMapTile(x, y, headerByteArray[position], headerByteArray[position + 1]);
                    position += 2;
                }
            }

            // Unknown
            int numData = BitConverter.ToInt32(headerByteArray, position);
            position += 4;
            position += BitConverter.ToInt32(headerByteArray, position) * 4;
            position += 4;
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

            if (!(headerByteArray[position + 8] == 146 && headerByteArray[position + 9] == 11))
            {

                //Player GAIA = new Player("GAIA");

                for (int i = -1; i < playerCount; i++) // starts with GAIA
                {
                    // -01-0B-03
                    position += 3;

                    // (player count) bytes + 00 00 00 00
                    position += playerCount + 4;

                    // diplomacy table
                    position += 4 * 8;

                    // 00 00 00 00 and ?? byte
                    position += 4;

                    // skip playername
                    length = (int)BitConverter.ToUInt16(headerByteArray, position);
                    position += 2;
                    position += length;

                    position += 1; // always 22?
                    int numResources = BitConverter.ToInt32(headerByteArray, position);
                    position += 4;
                    position += 1; // always 33?
                    int resourcesEnd = position + 4 * numResources;

                    Resources initialRes = new Resources(
                        (int)BitConverter.ToSingle(headerByteArray, position + 4),
                        (int)BitConverter.ToSingle(headerByteArray, position),
                        (int)BitConverter.ToSingle(headerByteArray, position + 12),
                        (int)BitConverter.ToSingle(headerByteArray, position + 8)
                    );
                    position += 16;

                    int initialHeadRoom = ((int)BitConverter.ToSingle(headerByteArray, position)); // Housing - Pop
                    position += 4;

                    position += 4;

                    int initialAge = ((int)BitConverter.ToSingle(headerByteArray, position));
                    position += 4;

                    int initialPopulation = ((int)BitConverter.ToSingle(headerByteArray, position));
                    position += 4;

                    int initialCivilianPopulation = ((int)BitConverter.ToSingle(headerByteArray, position));
                    position += 4;

                    int initialMilitaryPopulation = ((int)BitConverter.ToSingle(headerByteArray, position));
                    position += 4;

                    position = resourcesEnd + 1;

                    double initialX = Math.Round(BitConverter.ToSingle(headerByteArray, position), 2);
                    double initialY = Math.Round(BitConverter.ToSingle(headerByteArray, position + 4), 2);
                    position += 8;

                    if (i >= 0)
                        room.setPlayerInitialState(i, initialRes, initialAge, initialHeadRoom, initialPopulation,
                                                initialCivilianPopulation, initialMilitaryPopulation);

                    // Getting exist object positions
                    int existObjectPos = Utility.IndexOf(headerByteArray, GameConstants.EXIST_OBJECT_SEPARATOR, position);
                    if (existObjectPos < 0)
                        throw new Exception("Could not find existObjectSeparator");
                    position = existObjectPos + GameConstants.EXIST_OBJECT_SEPARATOR.Length;

                    // PlayerObjectListAnalser
                    bool done = false;
                    int separatorPos;
                    while (!done)
                    {
                        playerUnit = new Createable();
                        int objectType = headerByteArray[position];
                        int owner = objectType == 0 ? 0 : headerByteArray[position + 1];
                        position += 2;

                        int id = (int)BitConverter.ToUInt16(headerByteArray, position);
                        position += 2;

                        int gameObjectId = BitConverter.ToInt32(headerByteArray, position + 14);

                        switch (objectType)
                        {
                            case UnitType.UT_EYECANDY:

                                position += 19;

                                playerUnit.setPosition(Math.Round(BitConverter.ToSingle(headerByteArray, position)), Math.Round(BitConverter.ToSingle(headerByteArray, position + 4)));

                                position -= 19;
                                //gaiaUnits.Add(tempUnit);

                                if (headerByteArray[position] == 0)
                                    // testing
                                    position += 37;

                                position += 66;
                                //recordedGame.units.Add(tempUnit);

                                room.addPlayerObject(owner, playerUnit);
                                break;

                            case UnitType.UT_FLAG:

                                if (GameVersion.isHDEdition(versionConstant))
                                    position += 3;

                                position += 59;

                                if (isMgx)
                                {
                                    position += headerByteArray[position] == 2 ? 39 : 5;
                                }
                                else
                                    position += 40;

                                //recordedGame.units.Add(tempUnit);
                                break;

                            case UnitType.UT_DEAD_OR_FISH:
                                // TODO: details needed
                                if (headerByteArray[position] != 0)
                                {
                                    position += 80;
                                    if (headerByteArray[position] != UnitType.UT_EYECANDY && headerByteArray[position] != UnitType.UT_FLAG && headerByteArray[position] != UnitType.UT_DEAD_OR_FISH && headerByteArray[position] != UnitType.UT_BIRD && headerByteArray[position] != UnitType.UT_UNKNOWN && headerByteArray[position] != UnitType.UT_PROJECTILE && headerByteArray[position] != UnitType.UT_CREATABLE && headerByteArray[position] != UnitType.UT_BUILDING)
                                        position += 17;
                                }
                                else
                                    position += 140;

                                //position += headerByteArray[position] == 0 ? 140 : 80;
                                //position += headerByteArray[position] == 0 ? 140 : 97;
                                if (headerByteArray[position] == UnitType.UT_PROJECTILE)
                                    position += 128;

                                //recordedGame.units.Add(tempUnit);
                                break;

                            // TODO: Object Type 40 and 50 not included

                            case UnitType.UT_PROJECTILE:
                                // readProjectile not implemented
                                //position += 23;
                                position += 124;
                                break;

                            case UnitType.UT_CREATABLE:
                                if (UnitType.isGaiaUnit(id))
                                {
                                    position += 19;
                                    playerUnit.setPosition(
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position)),
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position + 4))
                                    );
                                    position += 8;

                                    //gaiaUnits.Add(tempUnit);
                                }
                                else if (playerUnit.owner != 0)
                                {
                                    position += 19;
                                    playerUnit.setPosition(
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position)),
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position + 4))
                                    );
                                    position += 8;

                                    //playerUnits.Add(tempUnit);
                                }

                                if (isMgx)
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

                                //recordedGame.units.Add(tempUnit);
                                break;

                            case UnitType.UT_BUILDING:
                                if (playerUnit.owner > 0)
                                {
                                    position += 19;
                                    playerUnit.setPosition(
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position)),
                                        Math.Round(BitConverter.ToSingle(headerByteArray, position + 4))
                                    );
                                    position += 8;

                                    //playerUnits.Add(tempUnit);
                                }

                                if (isMgx)
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

                                if (GameVersion.isHDPatch4(versionConstant, subVersionConstant))
                                    position -= 3;

                                //recordedGame.units.Add(tempUnit);
                                break;

                            case 00:
                                position -= 4;
                                if (Utility.IndexOf(headerByteArray, GameConstants.GAIA_INFO_END_SEPARATOR, position) == 0)
                                {
                                    position += GameConstants.GAIA_INFO_END_SEPARATOR.Length;
                                    done = true;
                                    break;
                                }
                                else if (Utility.IndexOf(headerByteArray, GameConstants.PLAYER_INFO_END_SEPARATOR, position) == 0)
                                {
                                    position += GameConstants.PLAYER_INFO_END_SEPARATOR.Length;
                                    done = true;
                                    break;
                                }
                                else if (Utility.IndexOf(headerByteArray, GameConstants.OBJECT_MID_SEPARATOR_GAIA, position) == 0)
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

                    int triggerInfoPos = Utility.IndexOf(headerByteArray, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length;

                    int gameSettingsPos = Utility.LastIndexOf(Utility.SubArray(headerByteArray, 0, triggerInfoPos), GameConstants.SEPARATOR) + GameConstants.SEPARATOR.Length;

                    byte[] scenarioSeparator = GameVersion.isAoK(versionConstant) ? 
                                                          GameConstants.AOK_SEPARATOR : GameVersion.isAoe2Record(fileFormat) ? 
                                                          GameConstants.AOE2_RECORD_SCENARIO_SEPARATOR : GameConstants.SCENARIO_CONSTANT;

                    position = Utility.LastIndexOf(
                        Utility.SubArray(headerByteArray, 0, gameSettingsPos), scenarioSeparator
                    ) + 4455;

                    //// 4096 00 bytes
                    //position += 4096;
                    //// 16 -FE-FF-FF-FF
                    //position += 16 * 4;
                    //// String Table, 16 rows, 4 Int each
                    //position += 16 * 4 * 4;
                    //// -01-00-00-00-00-00-00-00-00-00-00
                    //position += 11;
                    //// 6 -FE-FF-FF-FF
                    //position += 6 * 4;

                    if (!BitConverter.IsLittleEndian)
                        continue;
                    else
                        length = (int)BitConverter.ToUInt16(headerByteArray, position);
                    position += 2;

                    tempByteArray = Utility.SubArray(
                        headerByteArray, position, length);
                    
                    int temp1;
                    int temp2 = 0;
                    string key;
                    string value;

                    temp1 = Utility.IndexOf(tempByteArray, new byte[] { 0x3A });
                    while (temp1 > 0)
                    {
                        key = Encoding.UTF8.GetString(tempByteArray, temp2, temp1 - temp2).Trim();
                        temp2 = temp1 + 1;
                        temp1 = Utility.IndexOf(tempByteArray, new byte[] { 0x0A }, temp2);
                        temp1 = temp1 == -1 ? length - 1 : temp1;
                        value = Encoding.UTF8.GetString(tempByteArray, temp2, temp1 - temp2).Trim();
                        temp2 = temp1 + 1;
                        //introMessages[key] = value;

                        temp1 = Utility.IndexOf(tempByteArray, new byte[] { 0x3A }, temp2);
                    }

                    position = Utility.IndexOf(headerByteArray, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
                    position = Utility.IndexOf(headerByteArray, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
                    position = Utility.IndexOf(headerByteArray, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;
                    position = Utility.IndexOf(headerByteArray, GameConstants.SEPARATOR, position) + GameConstants.SEPARATOR.Length;

                    position += 36;

                    //// 8 Integers
                    //position += 32;

                    //// 01-00-00-00
                    //position += 4;

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

                    position += 2471;

                    //// 36 00 bytes
                    //position += 36;
                    //// player count
                    //position += 4;
                    //// 85-EB-91-3F
                    //position += 4;
                    //// -00-00-00-00-00-00-3C
                    //position += 7;
                    //// 2420 00 bytes
                    //position += 2420;

                    // Victory Settings
                    // 01-00-00-00
                    position += 4;
                    //recordedGame.setVictory(BitConverter.ToInt32(headerByteArray, position), victoryCondition);
                    position += 4;
                    //recordedGame.setRelicVictory(BitConverter.ToInt32(headerByteArray, position));
                    position += 4;

                    position = Utility.LastIndexOf(headerByteArray, GameConstants.CONSTANT) + GameConstants.CONSTANT.Length + 5;

                    // Read Teams
                    for (int i = 0; i < 8; i++)
                    {
                        //if (players.ContainsKey(i + 1))
                        //players[i + 1].setTeamIndex(headerByteArray[position]);

                        position++;
                    }

                    //recordedGame.setMapVisibility(BitConverter.ToInt32(headerByteArray, position));

                    position += 8;

                    //recordedGame.setMapSize(BitConverter.ToInt32(headerByteArray, position));

                    position += 4;

                    //recordedGame.setPopLimit(BitConverter.ToInt32(headerByteArray, position));

                    position += 4;

                    //recordedGame.setGameType(headerByteArray[position]);

                    position++;

                    //recordedGame.setGameMode(headerByteArray[position]);

                    position += 6;

                    string chat = "";
                    count = BitConverter.ToInt32(headerByteArray, position) - 1;
                    //position += 8;
                    position += 4;

                    //for (int i = 0; i < messageCount - 1; i++)
                    //{
                    //  length = BitConverter.ToInt32(headerByteArray, position);
                    //  position += 4;

                    //  if (length > 0)
                    //  {
                    //      chat = Encoding.ASCII.GetString(headerByteList.GetRange(position, length - 1).ToArray()).Trim();
                    //      position += length;

                    //      string target = "";
                    //      if (chat[3] == '<' && (chat.IndexOf('>') <= 8))
                    //          target = chat.Substring(4, (chat.IndexOf('>') - 4));

                    //      // pre-game chat messages are stored as "@#%dPlayerName: Message",
                    //      // where %d is a digit from 1 to 8 indicating player's index (or
                    //      // colour)

                    //      if (int.TryParse(chat[2].ToString(), out playerIndex))
                    //      {
                    //          if (chat.Substring(0, 2) == "@#" && playerIndex >= 1 && playerIndex <= 8)
                    //          {
                    //              pregameChat.Add(new ChatMessage(-1, playerIndex, chat.Substring(chat.IndexOf(':') + 2).Trim(), target));
                    //          }
                    //      }
                    //  }
                    //}

                    //recordedGame.addPreGameChat(pregameChat);
                }
            }
            return room;
        }
    }
}
