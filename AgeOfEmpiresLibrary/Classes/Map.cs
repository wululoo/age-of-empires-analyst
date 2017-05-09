using System;
namespace AgeOfEmpiresLibrary
{
	public class Map
	{
		public int id;
		public string fileName;
		public string name;
		public int size;
		public int visibility;

		public int xSize;
		public int ySize;

		private Tile[,] tiles;

		public Map()
		{
		}

		public void setMapFileName(string name)
		{
			fileName = name;
		}

		public void setTile(int x, int y, int terrain, int elevation)
		{
			tiles[x, y] = new Tile(x, y, terrain, elevation);
		}

		public void setMapSize(int mapSize)
		{
			this.size = mapSize;
		}

		public void setMapVisibility(int v)
		{
			visibility = v;
		}

		public void setMapTiles()
		{
			if (xSize > 0 && ySize > 0)
				tiles = new Tile[xSize, ySize];
		}
	}
}
