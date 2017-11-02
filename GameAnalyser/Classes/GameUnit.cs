namespace GameAnalyser
{
	public class GameUnit
	{
		public int objectType;

		public int owner = 0;

		public int id = 0;

        public string name = "";

        public int gameObjectId = 0;

		public double positionX;

		public double positionY;

		public GameUnit() { }

		public GameUnit(int id)
		{
			this.id = id;
		}
	}
}