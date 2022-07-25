namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pie
    {
        private List<Ingredient> _ingredients = new();

        private Pie()
        {
            Ingredients = _ingredients.AsReadOnly();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Portions Portions { get; private set; }
        public IReadOnlyCollection<Ingredient> Ingredients { get; }
        public Guid CategoryId { get; private set; }

        public static Pie Create(string name, string description, Portions portions)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (portions == null)
            {
                throw new ArgumentNullException(nameof(portions));
            }

            return new Pie
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Portions = portions
            };
        }

        public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            if (!ingredients.Any())
            {
                throw new ArgumentException("Must specify at least one ingredient.", nameof(ingredients));
            }

            if (ingredients.Sum(x => x.RelativeAmount) != 1.0)
            {
                throw new ArgumentException("The relative amount of all ingredients combined must add up to 1.0");
            }

            _ingredients.Clear();
            _ingredients.AddRange(ingredients);
        }
    }
}
