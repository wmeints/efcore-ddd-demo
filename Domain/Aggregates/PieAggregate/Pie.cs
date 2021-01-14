namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;
    
    public class Pie
    {
        private Pie()
        {
            
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public static Pie Create(string name, string description)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if(string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));

            return new Pie 
            { 
                Id = Guid.NewGuid(),
                Name = name, 
                Description = description 
            };
        }
    }
}