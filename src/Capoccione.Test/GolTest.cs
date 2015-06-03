using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Capoccione.Test
{
    public class GolTest
    {
		[Test]
	    public void should_be_able_to_find_neighbors()
		{
            var cell = new Cell(2, 3);

            var result = cell.Neighbors();

            result.Should().Contain(new Cell(1, 2));
            result.Should().Contain(new Cell(1, 3));
            result.Should().Contain(new Cell(1, 4));
            result.Should().Contain(new Cell(2, 2));
            result.Should().Contain(new Cell(2, 4));
            result.Should().Contain(new Cell(3, 2));
            result.Should().Contain(new Cell(3, 3));
            result.Should().Contain(new Cell(3, 4));
		}


        [Test]
        public void count_the_number_of_alive_neighbors()
        {
            var world = new World(new List<Cell>(){
                new Cell(1, 1), new Cell(2, 1) , new Cell(3, 1),
                new Cell(1, 2), new Cell(2, 2)
            });

            world.CountNeighbors(new Cell(2, 2)).Should().Be(4);
        }

        [Test]
        public void Should_tell_if_a_cell_is_alive()
        {
            var cell = new Cell(1, 22);

            var sut = new World(new List<Cell>(){ cell });

            sut.Contains(cell).Should().BeTrue();
        }

        [Test]
        public void a_cell_alone_dies()
        {
            var cell = new Cell(10, 10);
            var world = new World(new List<Cell>());

            world.ShouldDie(cell).Should().BeTrue();
        }

        [Test]
        public void evolve_test()
        {
            var cell = new Cell(10, 10);
            var world = new World(new List<Cell>());

            world.Evolve();

            world.Contains(cell).Should().BeFalse();
        }
    }
}
