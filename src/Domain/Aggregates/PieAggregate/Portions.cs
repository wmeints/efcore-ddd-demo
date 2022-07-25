namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;

    public record Portions
    {
        public int Minimum { get; }
        public int Maximum { get; }

        private Portions()
        {
            // This constructor exists so EF Core knows how to instantiate the entity.
        }
        
        public Portions(int minimum, int maximum)
        {
            if(minimum < 1) throw new ArgumentException("Minimum must be above zero.", nameof(minimum));
            if(maximum < 1) throw new ArgumentException("Maximum must be above zero.", nameof(maximum));
            if(maximum <= minimum) throw new ArgumentException("Maximum must be above minimum.", nameof(maximum));

            Minimum = minimum;
            Maximum = maximum;
        }
    }
}