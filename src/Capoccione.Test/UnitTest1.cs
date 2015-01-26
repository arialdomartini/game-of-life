using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Capoccione.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldPass()
        {
            "friends".Should().Be("friends");
        }
    }
}
