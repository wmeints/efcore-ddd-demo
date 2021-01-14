namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;

    public class Pie
    {
        private Guid _id;
        private string _name;
        private string _description;
        private Portions _portions;

        private Pie()
        {

        }

        public Guid Id => _id;
        public string Name => _name;
        public string Description => _description;
        public Portions Portions => _portions;

        public static Pie Create(string name, string description, Portions portions)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if (portions == null) throw new ArgumentNullException(nameof(portions));

            return new Pie
            {
                _id = Guid.NewGuid(),
                _name = name,
                _description = description,
                _portions = portions
            };
        }
    }
}