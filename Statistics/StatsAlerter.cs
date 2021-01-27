using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics
{
    public class StatsAlerter
    {
        public float MaxThreshold;
        readonly EmailAlert _emailAlert;
        readonly LEDAlert ledAlert;

        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            this.MaxThreshold = maxThreshold;
            this._emailAlert = (Statistics.EmailAlert)alerters[0];
            this.ledAlert = (Statistics.LEDAlert)alerters[1];
        }

        public void checkAndAlert(List<double> doubles)
        {
            foreach (var value in doubles.Where(value => value > MaxThreshold))
            {
                _emailAlert.emailSent = true;
                ledAlert.ledGlows = true;
            }
        }
    }

    public class LEDAlert : IAlerter
    {
        public bool ledGlows = false;
    }

    public class EmailAlert : IAlerter
    {
        public bool emailSent = false;

    }
}
