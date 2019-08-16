using System;
using System.Collections.Generic;
using System.Linq;

namespace KartRacing.Domain.Entities
{
    public class Race
    {
        #region Attributes
        private readonly IList<Pilot> _pilots;
        #endregion

        #region Constructor
        public Race()
        {
            _pilots = new List<Pilot>();
        }
        #endregion


        #region Properties
        public IReadOnlyCollection<Pilot> Pilots => _pilots.ToArray();
        public TimeSpan BestLap => _pilots.Min(pilot => pilot.BestLap);
        #endregion

        #region Methods
        public void AddPilot(Pilot pilot)
        {
            _pilots.Add(pilot);
        }

        public void SetPositions()
        {
            Pilot[] pilotsPosition = _pilots
                                     .OrderByDescending(p => p.TotalLaps)
                                     .ThenBy(p => p.TotalTime)
                                     .ToArray();

            TimeSpan winnersTime = pilotsPosition
                                     .Select(t => t.TotalTime)
                                     .FirstOrDefault();


            for (int i = 0; i < pilotsPosition.Length; i++)
            {
                var pilot = pilotsPosition[i];

                pilot.SetPosition(i + 1);
                pilot.SetTimeAfterWinner(winnersTime);
            }
        }
        #endregion
    }
}
