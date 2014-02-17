using System;

namespace conway
{
	public class LifeCell
    {
		private readonly int neighbourCount;
		private readonly bool occupiedCell;

		public LifeCell(bool occupied, int neighbourCount)
		{
			occupiedCell = occupied;
			this.neighbourCount= neighbourCount;
		}


		public bool WillIBeOccupied()
		{
			return (occupiedCell && (neighbourCount == 2)) || (neighbourCount == 3);
		}
    }
}

