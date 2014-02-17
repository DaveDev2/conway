using NUnit.Framework;
using System;
using conway;

namespace conwaytests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
		[TestCase(0, false)]
		[TestCase(1, false)]
		[TestCase(2, true)]
		[TestCase(3, true)]
		[TestCase(4, false)]
		[TestCase(4, false)]
		[TestCase(4, false)]
		[TestCase(4, false)]
		public void Occupied_cell_should_survive_given_neighbour_count(int neighbourCount, bool shouldSurvive)
        {
			LifeCell occupiedCell = new LifeCell(true, neighbourCount);
			Assert.AreEqual(shouldSurvive, occupiedCell.WillIBeOccupied());
        }

		[Test()]
		[TestCase(0, false)]
		[TestCase(1, false)]
		[TestCase(2, false)]
		[TestCase(3, true)]
		[TestCase(4, false)]
		public void UnOccupied_cell_should_spawn_given_neighbour_count(int neighbourCount, bool shouldSurvive)
		{
			LifeCell unoccupiedCell = new LifeCell(false, neighbourCount);
			Assert.AreEqual(shouldSurvive, unoccupiedCell.WillIBeOccupied());
		}

		[Test]
		public void Given_empty_grid_should_get_empty_grid_for_next_iteration()
		{
			var firstGeneration = new Grid(2, 2);
			var secondGeneration = firstGeneration.Iterate();
			Assert.IsFalse(secondGeneration.IsOccupied(0, 0));
			Assert.IsFalse(secondGeneration.IsOccupied(0, 1));
			Assert.IsFalse(secondGeneration.IsOccupied(1, 0));
			Assert.IsFalse(secondGeneration.IsOccupied(1, 1));
		}

		[Test]
		public void Given_example_returns_known()
		{
			var firstGeneration = new Grid(2, 2);
			firstGeneration.SetOccupied(0, 0);
			firstGeneration.SetOccupied(0, 1);
			firstGeneration.SetOccupied(1, 1);
			var secondGeneration = firstGeneration.Iterate();
			Assert.IsTrue(secondGeneration.IsOccupied(0, 0));
			Assert.IsTrue(secondGeneration.IsOccupied(0, 1));
			Assert.IsTrue(secondGeneration.IsOccupied(1, 0));
			Assert.IsTrue(secondGeneration.IsOccupied(1, 1));

		}
    }
}

