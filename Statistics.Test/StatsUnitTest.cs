using System;
using Xunit;
using System.Collections.Generic;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        
        [Fact]
        public void ReportsAverageMinMax()
        {
            var statsComputer = new StatsComputer();
            var listValues = new List<double>{ 1.5, 8.9, 3.2, 4.5 };
            var computedStats = statsComputer.CalculateStatistics(listValues);
            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }

        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            var list = new List<double> { 1.5, 8.9, 3.2, 4.5, double.NaN };
            var computedStats =  statsComputer.CalculateStatistics(list);
            Assert.True(double.IsNaN(computedStats.average));
            Assert.True(double.IsNaN(computedStats.min));
            Assert.True(double.IsNaN(computedStats.max));
        }

        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            var emailAlert = new EmailAlert();
            var ledAlert = new LEDAlert();
            IAlerter[] alerters = { emailAlert, ledAlert };

            const float maxThreshold = 10.2F;
            var statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.checkAndAlert(new List<double> { 0.2, 11.9, 4.3, 8.5 });

            Assert.True(emailAlert.emailSent);
            Assert.True(ledAlert.ledGlows);
        }
    }

}
