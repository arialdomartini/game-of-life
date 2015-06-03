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
            var world = new World(new List<Cell>()
            {
                new Cell(12, 10)
            });

            world.ShouldDie(cell).Should().BeTrue();
        }

        [Test]
        public void a_cell_can_die_of_loniness_with_only_1_neighbor()
        {
            var cell = new Cell(10, 10);
            var world = new World(new List<Cell>()
            {
                new Cell(10, 9)
            });

            world.ShouldDie(cell).Should().BeTrue();
        }

        [Test]
        public void a_cell_survive_with_2_neighbors()
        {
            var cell = new Cell(10, 10);
            var world = new World(new List<Cell>()
            {
                new Cell(10, 9),
                new Cell(9, 10)
            });

            world.ShouldDie(cell).Should().BeFalse();
        }

        [Test]
        public void a_cell_survive_suffocated_by_3_neighbors_dies()
        {
            var cell = new Cell(10, 10);
            var world = new World(new List<Cell>()
                {
                    new Cell(9, 9),
                    new Cell(10, 9),
                    new Cell(11, 9),
                });

            world.ShouldDie(cell).Should().BeTrue();
        }


        [Test]
        public void an_already_alive_cell_should_not_get_to_life_again()
        {
            var world = new World(new List<Cell>()
                {
                    new Cell(9, 9),
                    new Cell(10, 9),
                    new Cell(11, 9),
                });

            world.ShouldGetToLife(new Cell(9, 9)).Should().BeFalse();
        }


        [Test]
        public void an_isolated_point_should_not_bring_life_to_a_cell()
        {
            var world = new World(new List<Cell>()
                {
                    new Cell(9, 9),
                    new Cell(10, 9),
                    new Cell(11, 9),
                });

            world.ShouldGetToLife(new Cell(100, 100)).Should().BeFalse();
        }

        [Test]
        public void a_point_surrounded_by_3_cells_should_get_to_life()
        {
            var world = new World(new List<Cell>()
                {
                    new Cell(9, 9),
                    new Cell(10, 9),
                    new Cell(11, 9),
                });

            world.ShouldGetToLife(new Cell(10, 10)).Should().BeTrue();
        }

        [Test]
        public void evolve_test()
        {
            var world = new World(new List<Cell>()
                {
                    new Cell(10, 8),
                    new Cell(10, 9),
                    new Cell(10, 10),
                });
            var expected = new World(new List<Cell>()
                {
                    new Cell(9, 9), new Cell(10, 9), new Cell(11, 9)
                });

            world.Evolve();

            world.Should().Be(expected);
            expected.Should().Be(world);
        }
    }
}
