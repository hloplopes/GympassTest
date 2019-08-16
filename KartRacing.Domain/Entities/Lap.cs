using System;

namespace KartRacing.Domain.Entities
{
    public class Lap
    {
        #region Constructor
        public Lap(int number, double averageSpeed, TimeSpan duration, TimeSpan hour)
        {
            this.Number = number;
            this.AverageSpeed = averageSpeed;
            this.Duration = duration;
            this.Hour = hour;
        }
        #endregion

        #region Properties
        public int Number { get; private set; }
        public double AverageSpeed { get; private set; }
        public TimeSpan Duration { get; private set; }
        public TimeSpan Hour { get; private set; }
        #endregion
    }
}
