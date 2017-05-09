namespace GameAnalyser
{
	public class Command
	{
		public int id;
		public int playerId;
		public int type;
		public int time;

		public Command()
		{
		}
	}

	public static class CommandType
	{
		public const int OP_DEFEATED = 0x00;
		/**
		 * Operation ID of in-game commands.
		 *
		 * @var int
		 */
		public const int OP_COMMAND = 0x01;
		/**
         * Operation ID of sync packets.
         *
         * @var int
         */
		public const int OP_SYNC = 0x02;
		/**
         * Operation ID of "meta" operations like the start of the game or chat
         * messages.
         *
         * @var int
         */
		public const int OP_META = 0x03;
		/**
         * Same as OP_META, but not quite?
         *
         * @var int
         */
		public const int OP_META2 = 0x04;

		/**
         * Game start identifier.
         *
         * @var int
         */
		public const int META_GAME_START = 0x01F4;
		/**
         * Chat message identifier.
         *
         * @var int
         */
		public const int META_CHAT = -1;

		/**
         * Resignation command ID.
         *
         * @var int
         */
		public const int COMMAND_RESIGN = 0x0B;
		/**
         * Research command ID.
         *
         * @var int
         */
		public const int COMMAND_RESEARCH = 0x65;
		/**
         * Unit training command ID.
         *
         * @var int
         */
		public const int COMMAND_TRAIN = 0x81;
		/**
         * Unit training command ID (used by AIs).
         *
         * @var int
         */
		public const int COMMAND_TRAIN_SINGLE = 0x64;
		/**
         * Building command ID.
         *
         * @var int
         */
		public const int COMMAND_BUILD = 0x66;
		/**
         * Tribute command ID.
         *
         * @var int
         */
		public const int COMMAND_TRIBUTE = 0x6C;
		/**
         * UserPatch post-game lobby data command ID.
         *
         * @var int
         */
		public const int COMMAND_POSTGAME = 0xFF;
	}
}