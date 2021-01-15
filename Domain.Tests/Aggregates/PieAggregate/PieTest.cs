namespace Bakery.Domain.Tests.Aggregates.PieAggregate
{
    using System;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Xunit;

    public class PieTest
    {
        [Fact]
        public void Create_ReturnsAValidPie()
        {
            var pie = Pie.Create("Apple pie", "Awesome apple pie with chunks", new Portions(8, 10));

            Assert.NotNull(pie);
            Assert.Equal("Apple pie", pie.Name);
            Assert.Equal("Awesome apple pie with chunks", pie.Description);
            Assert.Equal(new Portions(8, 10), pie.Portions);
        }

        [Fact]
        public void UpdateIngredients_StoresTheIngredients()
        {
            var pie = Pie.Create("Apple pie", "Awesome apple pie with chunks", new Portions(8, 10));

            var ingredients = new[] 
            {
                new Ingredient("Apples", false, 0.6),
                new Ingredient("Sugar", false, 0.2),
                new Ingredient("Flour", true, 0.1),
                new Ingredient("Cinnamon", false, 0.05),
                new Ingredient("Salt", false, 0.05),
            };

            pie.UpdateIngredients(ingredients);

            Assert.NotEmpty(pie.Ingredients);
        }

        [Fact]
        public void UpdateIngredients_ThrowsForTooHighRelativeAmounts()
        {
            var pie = Pie.Create("Apple pie", "Awesome apple pie with chunks", new Portions(8, 10));

            var ingredients = new[] 
            {
                new Ingredient("Apples", false, 0.6),
                new Ingredient("Sugar", false, 0.2),
                new Ingredient("Flour", true, 0.1),
                new Ingredient("Cinnamon", false, 0.05),
                new Ingredient("Salt", false, 0.1),
            };

            Assert.Throws<ArgumentException>(() => 
            {
                pie.UpdateIngredients(ingredients);
            });
        }

        [Fact]
        public void UpdateIngredients_ThrowsForTooLowRelativeAmounts()
        {
            var pie = Pie.Create("Apple pie", "Awesome apple pie with chunks", new Portions(8, 10));

            var ingredients = new[] 
            {
                new Ingredient("Apples", false, 0.4),
                new Ingredient("Sugar", false, 0.2),
                new Ingredient("Flour", true, 0.1),
                new Ingredient("Cinnamon", false, 0.05),
                new Ingredient("Salt", false, 0.1),
            };

            Assert.Throws<ArgumentException>(() => 
            {
                pie.UpdateIngredients(ingredients);
            });
        }
    }
}