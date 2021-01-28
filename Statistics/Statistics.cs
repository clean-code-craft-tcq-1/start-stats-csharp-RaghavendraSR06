using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        readonly Stats result = new Stats();

        public Stats CalculateStatistics(List<double> numbers)
        {

            if (numbers.Any(double.IsNaN))
            {
                return result;
            }
            result.average = numbers.Average();
            result.max = numbers.Max();
            result.min = numbers.Min();
            return result;
        }

    }
}
