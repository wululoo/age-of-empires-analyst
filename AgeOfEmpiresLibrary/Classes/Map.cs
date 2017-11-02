using System;
using Urho.Urho2D;

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
        private TileMap2D tilemap;

		public Map()
		{
		}

        public Map(int id, int size, int visibility)
        {
            this.id = id;
            this.size = size;
            this.visibility = visibility;

            this.name = MapSetting.getNameFromId(id);
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

		public void setMapDimension(int x, int y)
		{
            if (x > 0 && y > 0)
            {
                tiles = new Tile[x, y];
                xSize = x;
                ySize = y;
            }
		}
	}
}
