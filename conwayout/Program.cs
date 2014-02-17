using System;
using conway;
using System.Threading;

namespace conwayout
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			var grid = new Grid(200, 55);

			var random = new Random();
			for (int i = 0; i < grid.Width; i++)
			{
				for (int j = 0; j < grid.Height; j++) {
					if (random.Next(100) > 90) grid.SetOccupied(i, j);
                }
			}

			grid.SetOccupied(4, 5);
			grid.SetOccupied(4, 4);
			grid.SetOccupied(5, 5);
			grid.SetOccupied(5, 6);
			grid.SetOccupied(6, 6);

			int iteration = 0;
			while (true)
			{
				OutputGrid(grid, iteration++);
				Thread.Sleep(50);
				grid = grid.Iterate();
			}
        }

		private static void OutputGrid(Grid grid, int iteration)
		{
			Console.Clear();

			Console.WriteLine(iteration);

			for (int h = 0; h < grid.Height; h++)
			{
				for (int w = 0; w < grid.Width; w++) {
					Console.Write(grid.IsOccupied(w, h) ? "*" : " ");
                }
				Console.WriteLine();
			}
		}
    }
}
