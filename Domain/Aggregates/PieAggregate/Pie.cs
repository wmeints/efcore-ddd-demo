namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;

    public class Pie
    {
        private Guid _id;
        private string _name;
        private string _description;        

        private Pie()
        {

        }

        public Guid Id => _id;
        public string Name => _name;
        public string Description => _description;

        public static Pie Create(string name, string description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));

            return new Pie
            {
                _id = Guid.NewGuid(),
                _name = name,
                _description = description
            };
        }
    }
}