using FluentAssertions;
using NUnit.Framework;

namespace Capoccione.Test
{
    public class Class1
    {
		[Test]
	    public void Should_pass()
		{
			"friends".Should().Be("friends");
		}
    }
}
