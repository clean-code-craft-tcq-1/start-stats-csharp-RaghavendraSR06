using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        Stats result = new Stats();

        public Stats CalculateStatistics(List<double> numbers)
        {
            _ = numbers ?? throw new ArgumentNullException();
            if (numbers.Any(doubleValue => Double.IsNaN(doubleValue)))
            {
                return null;
            }
            result.average = numbers.Average();
            result.min = numbers.Min();
            result.max = numbers.Max();
            return result;
        }

    }
}
