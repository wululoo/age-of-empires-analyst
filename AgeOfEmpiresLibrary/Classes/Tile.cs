using System;
namespace AgeOfEmpiresLibrary
{
	public class Tile
	{
		public int x;
		public int y;
		public int terrain;
		public int elevation;

		public Tile()
		{
		}

		public Tile(int x, int y, int terrain, int elevation)
		{
			this.x = x;
			this.y = y;
			this.terrain = terrain;
			this.elevation = elevation;
		}
	}
}
