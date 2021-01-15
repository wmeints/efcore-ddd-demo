namespace Bakery.Domain.Tests.Aggregates.PieAggregate
{
    using System;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Xunit;

    public class PortionsTest
    {
        [Fact]
        public void New_ThrowsForInvalidMinimum()
        {
            Assert.Throws<ArgumentException>(() => new Portions(0, 10));
        }

        [Fact]
        public void New_ThrowsForInvalidMaximum()
        {
            Assert.Throws<ArgumentException>(() => new Portions(10, 10));
            Assert.Throws<ArgumentException>(() => new Portions(11, 10));
        }

        [Fact]
        public void New_ReturnsPortions()
        {
            var portions = new Portions(8, 10);

            Assert.Equal(10, portions.Maximum);
            Assert.Equal(8, portions.Minimum);
        }
    }
}