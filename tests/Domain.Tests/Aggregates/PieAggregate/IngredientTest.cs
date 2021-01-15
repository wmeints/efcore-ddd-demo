namespace Bakery.Domain.Tests.Aggregates.PieAggregate
{
    using System;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Xunit;

    public class IngredientTest
    {
        [Fact]
        public void New_ThrowsForMissingName()
        {
            Assert.Throws<ArgumentNullException>(() => new Ingredient("", false, 1.0));
        }

        [Fact]
        public void New_ThrowsForInvalidRelativeAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Ingredient("Apples", false, 1.1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Ingredient("Apples", false, 0.0));
        }

        [Fact]
        public void New_ReturnsIngredient()
        {
            var ingredient = new Ingredient("Flower", true, 1.0);

            Assert.Equal("Flower", ingredient.Name);
            Assert.Equal(true, ingredient.IsAllergen);
            Assert.Equal(1.0, ingredient.RelativeAmount);
        }
    }
}