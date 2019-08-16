using System;
using System.Collections.Generic;
using System.Linq;

namespace KartRacing.Domain.Entities
{
    public class Pilot
    {
        #region Attributes
        private readonly IList<Lap> _laps;
        #endregion

        #region Constructor
        public Pilot(int code, string name)
        {
            _laps = new List<Lap>();
            this.Code = code;
            this.Name = name;
        }
        #endregion

        #region Properties
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Position { get; private set; }
        public int TotalLaps => _laps.Max(lap => lap.Number);
        public TimeSpan TotalTime => new TimeSpan(_laps.Sum(lap => lap.Duration.Ticks));
        public TimeSpan BestLap => _laps.Min(lap => lap.Duration);
        public double AverageSpeed => _laps.Average(lap => lap.AverageSpeed);
        public TimeSpan TimeAfterWinner { get; private set; }
        public IReadOnlyCollection<Lap> Laps => _laps.ToArray();
        #endregion

        #region Methods
        public void AddLap(Lap lap)
        {
            _laps.Add(lap);
        }
        public void SetPosition(int position)
        {
            this.Position = position;
        }
        public void SetTimeAfterWinner(TimeSpan time)
        {
            this.TimeAfterWinner = this.TotalTime.Subtract(time);
        }
        #endregion
    }
}
