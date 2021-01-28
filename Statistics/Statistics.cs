using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {

        public double average = double.NaN;
        public double max = double.NaN;
        public double min = double.NaN;

        public void CalculateStatistics(List<double> numbers)
        {

            if (numbers.Any(double.IsNaN))
            {
                return;
            }
            average = numbers.Average();
            max = numbers.Max();
            min = numbers.Min();
        }

    }
}
