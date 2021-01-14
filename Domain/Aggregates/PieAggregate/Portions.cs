namespace Bakery.Domain.Aggregates.PieAggregate
{
    using System;
    
    public class Portions
    {
        private int _min;
        private int _max;

        public Portions(int minimum, int maximum)
        {
            if(minimum < 1) throw new ArgumentException("Minimum must be greater or equal to 1", nameof(minimum));
            if(maximum < 1) throw new ArgumentException("Maximum must be greater or equal to 1", nameof(maximum));
            if(minimum >= maximum) throw new ArgumentException("Maximum must be above minimum", nameof(maximum));

            _min = minimum;
            _max = maximum;
        }

        public int Minimum => _min;
        public int Maximum => _max;
    }
}