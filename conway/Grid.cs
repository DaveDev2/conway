using System;

namespace conway
{
    public class Grid
    {
		readonly bool[,] life;

		public Grid(int width, int height)
		{
			life = new bool[width, height];
		}

		public int Width
		{
			get{ return life.GetLength(0); }
		}

		public int Height
		{
			get{ return life.GetLength(1); }
		}

		public Grid Iterate()
		{
			var newLife = new Grid(Width, Height);
			var random = new Random();
			for (int iix = 0; iix < Width; iix++)
			{
				for(int iiy = 0; iiy < Height; iiy++)
				{
					var neighbourCount = GetNeighbourCount(iix, iiy);
					var cell = new LifeCell(IsOccupied(iix, iiy), neighbourCount);
					//if (cell.WillIBeOccupied() || random.Next(100)>98) newLife.SetOccupied(iix, iiy);
					if (cell.WillIBeOccupied()) newLife.SetOccupied(iix, iiy);
				}
			}
			return newLife;
		}

		int GetNeighbourCount(int x, int y)
		{
			int neighbourCount = 0;

			if (IsOccupied(x, y - 1)) neighbourCount++;
			if (IsOccupied(x + 1, y - 1)) neighbourCount++;
			if (IsOccupied(x + 1, y)) neighbourCount++;
			if (IsOccupied(x + 1, y + 1)) neighbourCount++;
			if (IsOccupied(x, y + 1)) neighbourCount++;
			if (IsOccupied(x - 1, y + 1)) neighbourCount++;
			if (IsOccupied(x - 1, y)) neighbourCount++;
			if (IsOccupied(x - 1, y - 1)) neighbourCount++;

			return neighbourCount;
		}

		public bool IsOccupiedOld(int x, int y)
		{
			if (x < 0 || x >= Width) return false;
			if (y < 0 || y >= Height) return false;
			return life[x, y];
		}

		// this does wrap around
		public bool IsOccupied(int x, int y)
		{
			if (x < 0) x = Width - 1;
			if (x >= Width) x = 0;
			if (y < 0) y = Height - 1;
			if (y >= Height) y = 0;
			return life[x, y];
		}

		public void SetOccupied(int i, int i2)
		{
			life[i, i2] = true;
		}
    }
}

