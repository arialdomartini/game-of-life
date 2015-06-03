using FluentAssertions;
using NUnit.Framework;
using System;

namespace Capoccione.Test
{
    public class GolTest
    {
        Gol _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Gol();
        }
		[Test]
	    public void should_be_able_to_find_neighbors()
		{
            var cell = new Cell(2, 3);

            var result = _sut.Neighbors(cell);

            result.Should().Contain(new Cell(1, 2));
            result.Should().Contain(new Cell(1, 3));
            result.Should().Contain(new Cell(1, 4));
            result.Should().Contain(new Cell(2, 2));
            result.Should().Contain(new Cell(2, 4));
            result.Should().Contain(new Cell(3, 2));
            result.Should().Contain(new Cell(3, 3));
            result.Should().Contain(new Cell(3, 4));
		}
    }
}
